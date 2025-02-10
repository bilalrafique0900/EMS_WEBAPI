using EmployeeSystem.Application.Contracts.AppSettings;
using EmployeeSystem.Application.Contracts.MapperConfiguration;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Extentions;
using EmployeeSystem.Infra;
using EmployeeSystem.Infra.MySql;
using EmployeeSystem.Infra.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Serilog;
using StackExchange.Profiling.Storage;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var SqlServerConnection = configuration.GetConnectionString("ServerConnection");
var MySqlConnection = configuration.GetConnectionString("MySql");
var RedisConnection = configuration.GetSection("redis:ConnectionStrings").Value;
var RedisKey = configuration.GetSection("redis:ApplicationKey").Value;
string policyName = "AllowAngularOrigins";
builder.Services.AddControllers();

builder.Services.AddDbContext<EmployeeDBContext>(option => option.UseSqlServer(SqlServerConnection));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = RedisConnection;
    options.InstanceName = RedisKey;
});

//builder.Services.AddTransient<MySqlConnection>(_ =>
//    new MySqlConnection(MySqlConnection));

builder.Services.AddSingleton<IMysql>(x =>
    ActivatorUtilities.CreateInstance<MySql>(x, MySqlConnection)
);
//Serilog 
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
     .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//End Serilog


builder.Services.AddSignalR(hubOptions =>
{
    // hubOptions.EnableDetailedErrors = true;
    // hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(10);
    hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(60);
});
builder.Services.AddCors(builder =>
{
    builder.AddPolicy(policyName,
        builder => builder.WithOrigins(configuration.GetSection("Cors").GetValue<string>("AllowedOrigins"))
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed((hosts) => true)
        );
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024;
});

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddControllers();

//builder.Services
//    .AddControllers(config =>
//    {
//    })
//    .AddNewtonsoftJson(option =>
//    {
//        //option.UseMemberCasing();//for use pascal case output format
//    });

//builder.Services.AddResponseCaching(x => x.MaximumBodySize = 1024);
//Swagger Configuration
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Education_System",
        Version = "v2",
        Description = "Education_System",
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "bearer",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {{new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }},new List<string>()}});
});
builder.Services.AddJwtAuthentication(configuration);
builder.Services.InjectPersistenceDependencies(configuration);
builder.Services.AddAuthorization(option =>
{
    option.FallbackPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .Build();
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Mapping));

//Mini Profiler
//if (Convert.ToBoolean(configuration["MiniProfiler:IsEnabled"]))
//{
//    builder.Services.AddMiniProfiler(options =>
//    {
//        options.RouteBasePath = "/profiler";

//        options.ColorScheme = StackExchange.Profiling.ColorScheme.Light;
//        options.PopupRenderPosition = StackExchange.Profiling.RenderPosition.BottomLeft;
//        options.PopupShowTimeWithChildren = true;
//        options.PopupShowTrivial = true;
//        options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
//        options.Storage = new SqlServerStorage(SqlServerConnection);
//    }).AddEntityFramework();
//}
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
builder.Services.Configure<FirebaseSettings>(builder.Configuration.GetSection("Firebase"));



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiniProfiler();
app.UseSwagger();
app.UseSwaggerUI();
//if (app.Environment.IsDevelopment())
//{
//    app.UseResponseCaching();
//    app.Use(async (context, next) =>
//    {
//        context.Response.GetTypedHeaders().CacheControl =
//            new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
//            {
//                Public = true,
//                MaxAge = TimeSpan.FromDays(10)
//            };

//        context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] = new string[] { "Accept-Encoding" };
//        await next();
//    });

//}

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider
//        .GetRequiredService<EmployeeDBContext>();
//    dbContext.Database.Migrate();
//    DbInitializer Initializer = new();
//    Initializer.Initialize(dbContext);
//}

//app.UseStaticFiles(new StaticFileOptions()
//{
//    OnPrepareResponse = ctx =>
//    {
//        ctx.Context.Response.Headers.Append("Access-Control-Allow-Origin", "*");
//        ctx.Context.Response.Headers.Append("Access-Control-Allow-Headers",
//          "Origin, X-Requested-With, Content-Type, Accept");
//    },

//});

//app.UseFileServer(new FileServerOptions
//{
//    FileProvider = new PhysicalFileProvider(
//           Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
//    RequestPath = "/wwwroot",
//    EnableDirectoryBrowsing = true
//});

//app.UseHttpsRedirection();

app.UseAuthentication();

//app.MapControllers();
//global exception handling use one from both at the same time
app.UseCors(policyName);
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHub<NotificationHub>("/communication");
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapHub<NotificationHub>("/notification");
//});

app.ConfigureDefaultExceptionMiddleware();
app.Run();

