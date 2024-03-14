using EmployeeSystem.EntityFrameworkCore.DBContext;
using Hangfire;
using HangfireJob.IServices;
using HangfireJob.Services;
using Microsoft.EntityFrameworkCore;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.Repositories.Attendance;
using EmployeeSystem.Infra.MySql;
using EmployeeSystem.Infra.IRepositories.IAttendance;
using EmployeeSystem.Application.Contracts.MapperConfiguration;
using EmployeeSystem.Infra.Services;
using EmployeeSystem.Infra.IServices;
using EmployeeSystem.Infra.Repositories.UserManagement;
using EmployeeSystem.Infra.IRepositories.IUserManagement;
using EmployeeSystem.Application.Contracts.AppSettings;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
var SqlServerConnection = configuration.GetConnectionString("ServerConnection");
var MySqlConnection = configuration.GetConnectionString("MySql");

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<EmployeeDBContext>(option => option.UseSqlServer(SqlServerConnection));



builder.Services.AddSingleton<IMysql>(x =>
    ActivatorUtilities.CreateInstance<MySql>(x, MySqlConnection)
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(Mapping));

builder.Services.AddSingleton(typeof(IDapperConfig), typeof(DapperConfig));
builder.Services.AddScoped<IAttendanceRepository, AttendanceRepository>();
builder.Services.AddScoped<IUserTokenRepository, UserTokenRepository>();
builder.Services.AddScoped<IFirebaseService, FirebaseService>();
builder.Services.AddScoped<IJobService, JobService>();

builder.Services.AddHangfire(x =>
{
    x.UseSqlServerStorage(SqlServerConnection);
});
builder.Services.AddHangfireServer();

builder.Services.Configure<FirebaseSettings>(builder.Configuration.GetSection("Firebase"));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();
app.UseHangfireDashboard();
app.Run();
