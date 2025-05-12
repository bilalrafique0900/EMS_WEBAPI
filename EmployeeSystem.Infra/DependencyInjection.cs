using DinkToPdf;
using DinkToPdf.Contracts;
using EmployeeSystem.Application.Contracts.HelperMethods;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories;
using EmployeeSystem.Infra.IRepositories.EmployeeAccessoriesRepository;
using EmployeeSystem.Infra.IRepositories.IContract;
using EmployeeSystem.Infra.IRepositories.IDocument;
using EmployeeSystem.Infra.IRepositories.IEmployee;
using EmployeeSystem.Infra.IRepositories.IFile;
using EmployeeSystem.Infra.IRepositories.IIAceessriesRepo;
using EmployeeSystem.Infra.IRepositories.IJobDescription;
using EmployeeSystem.Infra.IRepositories.ILovType;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using EmployeeSystem.Infra.IRepositories.IOnboarding;
using EmployeeSystem.Infra.IRepositories.IReporting;
using EmployeeSystem.Infra.IRepositories.IUserManagement;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using EmployeeSystem.Infra.IServices;
using EmployeeSystem.Infra.Repositories;
using EmployeeSystem.Infra.Repositories.AccessriesRepostery;
using EmployeeSystem.Infra.Repositories.Contract;
using EmployeeSystem.Infra.Repositories.Document;
using EmployeeSystem.Infra.Repositories.Employee;
using EmployeeSystem.Infra.Repositories.EmployeeAccessoriesRepostery;
using EmployeeSystem.Infra.Repositories.File;
using EmployeeSystem.Infra.Repositories.JobDescription;
using EmployeeSystem.Infra.Repositories.MasterData;
using EmployeeSystem.Infra.Repositories.Onboarding;
using EmployeeSystem.Infra.Repositories.Report;
using EmployeeSystem.Infra.Repositories.UserManagement;
using EmployeeSystem.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace EmployeeSystem.Infra
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectPersistenceDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<JwtHandler>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IRedisCacheService, RedisCacheService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            services.AddTransient<ILovTypeRepository, LovTypeRepository>();
            services.AddTransient<IDocumentRepository, DocumentRepository>();
            services.AddSingleton(typeof(IDapperConfig), typeof(DapperConfig));
            services.AddTransient<ITemplateRepository, TemplateRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IUserTokenRepository, UserTokenRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeDocumentRepository, EmployeeDocumentRepository>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
            services.AddTransient<IFunctionRepository, FunctionRepository>();
            services.AddTransient<IGroupRepository, GroupRepository>();
            services.AddTransient<IPostHostRepository, PostHostRepository>();
            services.AddTransient<IJobDescriptionRepository, JobDescriptionRepository>();
            services.AddTransient<ILevelRepository,LevelRepository>();
            services.AddSingleton(typeof(IConverter), new SynchronizedConverter(new PdfTools()));
            services.AddTransient<IReportRepository, ReportRepository>();
            services.AddTransient<IFileRepository, FileRepository>();
            services.AddSingleton<IMailService, MailService>();
            services.AddScoped<IEmployeeAccessoriesRepository, EmployeeAccessoriesRepostery>();
            services.AddScoped<IAceessriesRepository, AccessriesRepostery>();
            services.AddTransient<IOnboardingRepository, OnboardingRepository>();
            services.AddTransient<IRoleDepartmentRepository, RoleDepartmentRepository>();
            services.AddTransient<IJobPermissionRepository, JobPermissionRepository>();
            return services;
        }
    }
}
