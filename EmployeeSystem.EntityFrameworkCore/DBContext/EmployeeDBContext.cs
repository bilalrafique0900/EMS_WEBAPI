  using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EmployeeSystem.Domain.Models;
using System.Reflection.Metadata;
using Microsoft.Extensions.Hosting;
using System.Data;

namespace EmployeeSystem.EntityFrameworkCore.DBContext;

public partial class EmployeeDBContext : DbContext
{
    public EmployeeDBContext()
    {
    }
    public EmployeeDBContext(DbContextOptions options) : base(options)
    {
    }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<RoleDepartment> RoleDepartments { get; set; }
    public virtual DbSet<PermissionItem> PermissionItems { get; set; }  
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<LOV> LOVS { get; set; }
    public virtual DbSet<LOVType> LOVType { get; set; }
    public virtual DbSet<Domain.Models.Document> Documents { get; set; }
    public virtual DbSet<Template> Templates { get; set; }
    public virtual DbSet<UserToken> UserTokens { get; set; }
    public virtual DbSet<ReportConfig> ReportConfigs { get; set; }
    public virtual DbSet<ReportConfigDetail> ReportConfigDetails { get; set; }
    public virtual DbSet<Employee> Employees { get; set; }
    public virtual DbSet<EmployeeEducation> EmployeeEducations { get; set; }
    public virtual DbSet<EmployeePreviousExperience> EmployeePreviousExperiences { get; set; }
    public virtual DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
    public virtual DbSet<EmployeeFamily> EmployeeFamilys { get; set; }
    public virtual DbSet<EmployeeChildren> EmployeeChildrens { get; set; }
    public virtual DbSet<Department> Departments { get; set; }
    public virtual DbSet<Functions> Functions { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Level> Levels { get; set; }
    public virtual DbSet<PostHost> PostHosts { get; set; }
    public virtual DbSet<JobDescription> JobDescriptions { get; set; }

    public virtual DbSet<CV> CVs { get; set; }
    public virtual DbSet<Onboarding> Onboardings { get; set; }

    public virtual DbSet<Accessories> Accessories { get; set; }
    public virtual DbSet<EmployeeAccessories> EmployeeAccessories { get; set; }
    public virtual DbSet<JobPermission> JobPermissions { get; set; }




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                                                              .SetBasePath(Directory.GetCurrentDirectory())
                                                              .AddJsonFile("appsettings.json")
                                                              .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ServerConnection"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
#pragma warning disable 0169, 0414, gobalFilters
        modelBuilder.Entity<User>().HasQueryFilter(m => m.IsActive == true);
        modelBuilder.Entity<Template>().HasQueryFilter(m => m.IsActive == true && m.IsDeleted == false);
#pragma warning restore 0169, 0414, gobalFilters

        // modelBuilder.Entity<MarksPolicyDetail>()
        //.HasOne(e => e.MarksPolicy)
        //.WithMany(e => e.PolicyDetails)
        //.HasForeignKey(e => e.MarksPolicyId)
        //.IsRequired();
        modelBuilder.Entity<RoleDepartment>().HasNoKey();
        base.OnModelCreating(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
       
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
