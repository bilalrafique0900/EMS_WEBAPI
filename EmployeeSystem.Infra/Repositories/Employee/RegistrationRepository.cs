using AutoMapper;
using Dapper;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IEmployee;  
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.SignalR;
using EmployeeSystem.Infra.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EmployeeSystem.Infra.Repositories.Employee
{
    public class EmployeeRepository : GenericRepository<Domain.Models.Employee>, IEmployeeRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly IMapper _mapper;
        public IDapperConfig _dapper { get; set; }
        private readonly ILogger _logger;
        private readonly IHubContext<NotificationHub> _hub;
        public EmployeeRepository(EmployeeDBContext appDbContext, IMapper mapper, IDapperConfig dapper
            , ILogger<EmployeeRepository> logger
            , IHubContext<NotificationHub> hub) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _mapper = mapper;
            _logger = logger;
            _hub = hub;
            
        }
        public async Task<Guid> AddUpdate(EmployeeDto employee)
        {
            if (employee.IsPicturePermission == false)
                employee.Picture = null;
            var EmployeeRecordFormDB = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            if (EmployeeRecordFormDB != null)
            {
                _logger.LogInformation("update employee from {@EmployeeRecordFormDB} by {@CreatedBy} ", EmployeeRecordFormDB, employee.CreatedBy);
                var MapeTheParentObject = this._mapper.Map(employee, EmployeeRecordFormDB);
                EmployeeRecordFormDB.UpdatedDate = DateTime.Now;
                EmployeeRecordFormDB.UpdatedBy = employee.CreatedBy;

            }
            else
            {
                employee.IsActive = true;
                employee.IsDeleted = false;
                employee.CreatedDate = DateTime.Now;
                var StudentMapped = this._mapper.Map<EmployeeDto, EmployeeSystem.Domain.Models.Employee>(employee);
                StudentMapped.Status = EmployeeStatus.NEW.ToString();
                await _dbContext.Employees.AddAsync(StudentMapped);
                employee.EmployeeId = StudentMapped.EmployeeId;

            }
            await _dbContext.SaveChangesAsync();
            return employee.EmployeeId;
        }
        public async Task<Guid> AddUpdateEducation(EmployeeEducationDto employee)
        {
          
            var EmployeeRecordFormDB = await _dbContext.EmployeeEducations.FirstOrDefaultAsync(x => x.EducationId == employee.EducationId);
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            if (EmployeeRecordFormDB != null)
            {
                _logger.LogInformation("update employeeeducation from {@EmployeeRecordFormDB} by {@CreatedBy} ", EmployeeRecordFormDB, employee.CreatedBy);
                var MapeTheParentObject = this._mapper.Map(employee, EmployeeRecordFormDB);
                emp.EducationTypeId = employee.EducationTypeId;
                EmployeeRecordFormDB.UpdatedDate = DateTime.Now;
                EmployeeRecordFormDB.UpdatedBy = employee.CreatedBy;

            }
            else
            {
                employee.IsActive = true;
                employee.IsDeleted = false;
                employee.CreatedDate = DateTime.Now;
                var StudentMapped = this._mapper.Map<EmployeeEducationDto, EmployeeSystem.Domain.Models.EmployeeEducation>(employee);
                await _dbContext.EmployeeEducations.AddAsync(StudentMapped);
                emp.EducationTypeId = employee.EducationTypeId;
                employee.EducationId = StudentMapped.EducationId;

            }
            await _dbContext.SaveChangesAsync();
            return employee.EducationId;
        }
        public async Task<Guid> AddUpdatePreviousExperience(EmployeePreviousExperienceDto employee)
        {
           
            var EmployeeRecordFormDB = await _dbContext.EmployeePreviousExperiences.FirstOrDefaultAsync(x => x.PreviousExperienceId == employee.PreviousExperienceId);
            if (EmployeeRecordFormDB != null)
            {
                _logger.LogInformation("update employeepreviousexperience from {@EmployeeRecordFormDB} by {@CreatedBy} ", EmployeeRecordFormDB, employee.CreatedBy);
                var MapeTheParentObject = this._mapper.Map(employee, EmployeeRecordFormDB);
                EmployeeRecordFormDB.UpdatedDate = DateTime.Now;
                EmployeeRecordFormDB.UpdatedBy = employee.CreatedBy;

            }
            else
            {
                employee.IsActive = true;
                employee.IsDeleted = false;
                employee.CreatedDate = DateTime.Now;
                var StudentMapped = this._mapper.Map<EmployeePreviousExperienceDto, EmployeeSystem.Domain.Models.EmployeePreviousExperience>(employee);
                await _dbContext.EmployeePreviousExperiences.AddAsync(StudentMapped);
                employee.PreviousExperienceId = StudentMapped.PreviousExperienceId;

            }
            await _dbContext.SaveChangesAsync();
            return employee.PreviousExperienceId;
        }
        public async Task<IEnumerable<EmployeeEducation>> GetEducationById(Guid employeeId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeeEducations.Where(x => x.EmployeeId == employeeId).ToListAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<bool> SaveEducationType(Guid employeeId,Guid educationTypeId)
        {
            var EmployeeRecordFormDB = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (EmployeeRecordFormDB != null)
            {

                EmployeeRecordFormDB.EducationTypeId = educationTypeId;
                EmployeeRecordFormDB.UpdatedDate = DateTime.Now;
                await _dbContext.SaveChangesAsync();

                return true;
            }else
            return false;
        }
        public async Task<Domain.Models.Employee> GetEmployeeById(Guid employeeId)
        {
            var EmployeeRecordFormDB = await _dbContext.Employees.Where(x => x.EmployeeId == employeeId).FirstOrDefaultAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<EmployeeEducation> GetEducationByEducationId(Guid educationId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeeEducations.Where(x => x.EducationId == educationId).FirstOrDefaultAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<EmployeePreviousExperience> GetExperienceByExperienceId(Guid PreviousExperienceId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeePreviousExperiences.Where(x => x.PreviousExperienceId == PreviousExperienceId).FirstOrDefaultAsync();
            return EmployeeRecordFormDB;
        }

        public async Task<IEnumerable<EmployeePreviousExperience>> GetExperienceById(Guid employeeId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeePreviousExperiences.Where(x=>x.EmployeeId==employeeId).ToListAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<string> GetEmployeeCode()
        {
            var EmployeeRecordFormDB = await _dbContext.Employees.ToListAsync();
            if(EmployeeRecordFormDB.Count>9)
            return "EMP-"+EmployeeRecordFormDB.Count+1;
            else
                return "EMP-0" + (EmployeeRecordFormDB.Count + 1);
        }
        public async Task<IEnumerable<Domain.Models.Employee>> GetEmployees()
        {
            var EmployeeRecordFormDB = await _dbContext.Employees.ToListAsync();
         
                return EmployeeRecordFormDB;
        }
        public async Task<IEnumerable<DropdownListDto>> GetEmployeesByDesignation(string DesignationCode)
        {
            var lov=await _dbContext.LOVS.FirstOrDefaultAsync(x=>x.LovCode==DesignationCode);
            List<DropdownListDto> EmployeeRecordFormDB = await (from groups in _dbContext.Employees

                                                where groups.IsDeleted != true && groups.IsActive==true && groups.EmployeeDesignationId==lov.LovId
                                                select new DropdownListDto
                                                {
                                                    Id = groups.EmployeeId,
                                                    Name = groups.FirstName+" "+groups.MiddleName+" "+groups.LastName,

                                                }).ToListAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<IEnumerable<EmployeeListDto>> GetEmployeesPaginated(int pageNo, int pageSize, string searchText)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pageNo", pageNo);
            parameters.Add("@pageSize", pageSize);
            parameters.Add("@seaechText", searchText);

            var EmployeeList = await _dapper.QueryAsync<EmployeeListDto>("GetEmployees", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
            return EmployeeList;
        }
        private static string CheckValidDate(DateTime? date)
        {
            DateTime temp;
            if (DateTime.TryParse(date.ToString(), out temp))
            {
                return temp.ToString("yyyyMMdd");
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> Active(Guid employeeId)
        {
            var rec = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
            if (rec != null)
            {
                rec.IsActive = rec.IsActive == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> CheckAllAttachmentUploaded(Guid studentId)
        {
            var documentCountCheck = await _dapper.QueryAsync<DocumentInfoDto>("CheckAllAttachmentUploadedByStudentId", new { @StudentId = studentId }, CommandType.StoredProcedure).ConfigureAwait(true);
            bool Isuploaded = documentCountCheck.Any(x => x.DocumentStatus == true);
            return !Isuploaded;
        }
        public async Task<bool> Delete(Guid id)
        {
            IQueryable<EmployeeSystem.Domain.Models.Employee> DbQuery = _dbContext.Employees.Where(x => x.EmployeeId == id);
            Domain.Models.Employee results = await DbQuery.FirstOrDefaultAsync();
            if (results is not null)
            {
                results.IsDeleted = results.IsDeleted == true ? false : true;
                await _dbContext.SaveChangesAsync();
                _logger.LogInformation("delete employee {@id} ", id);
                return true;
            }
            return false;
        }
        public async Task<Guid> AddUpdateFamily(EmployeeFamilyDto employee)
        {

            var EmployeeRecordFormDB = await _dbContext.EmployeeFamilys.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            var emp = await _dbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);
            if (EmployeeRecordFormDB != null)
            {
                _logger.LogInformation("update employeefamily from {@EmployeeRecordFormDB} by {@CreatedBy} ", EmployeeRecordFormDB, employee.CreatedBy);
                var MapeTheParentObject = this._mapper.Map(employee, EmployeeRecordFormDB);
                emp.MaritalStatusId = employee.MaritalStatusId;
                EmployeeRecordFormDB.UpdatedDate = DateTime.Now;

                EmployeeRecordFormDB.UpdatedBy = employee.CreatedBy;

            }
            else
            {
                employee.IsActive = true;
                employee.IsDeleted = false;
                employee.CreatedDate = DateTime.Now;
                var StudentMapped = this._mapper.Map<EmployeeFamilyDto, EmployeeSystem.Domain.Models.EmployeeFamily>(employee);
                await _dbContext.EmployeeFamilys.AddAsync(StudentMapped);
                emp.MaritalStatusId = employee.MaritalStatusId;
                employee.FamilyId = StudentMapped.FamilyId;

            }
            await _dbContext.SaveChangesAsync();
            return employee.FamilyId;
        }
        public async Task<Guid> AddUpdateChildren(EmployeeChildrenDto employee)
        {

            var EmployeeRecordFormDB = await _dbContext.EmployeeChildrens.FirstOrDefaultAsync(x => x.ChildrenId == employee.ChildrenId);
            if (EmployeeRecordFormDB != null)
            {
                _logger.LogInformation("update employeechildren from {@EmployeeRecordFormDB} by {@CreatedBy} ", EmployeeRecordFormDB, employee.CreatedBy);
                var MapeTheParentObject = this._mapper.Map(employee, EmployeeRecordFormDB);
                EmployeeRecordFormDB.UpdatedDate = DateTime.Now;
                EmployeeRecordFormDB.UpdatedBy = employee.CreatedBy;

            }
            else
            {
                employee.IsActive = true;
                employee.IsDeleted = false;
                employee.CreatedDate = DateTime.Now;
                var StudentMapped = this._mapper.Map<EmployeeChildrenDto, EmployeeSystem.Domain.Models.EmployeeChildren>(employee);
                await _dbContext.EmployeeChildrens.AddAsync(StudentMapped);
                employee.ChildrenId = StudentMapped.ChildrenId;

            }
            await _dbContext.SaveChangesAsync();
            return employee.ChildrenId;
        }
        public async Task<IEnumerable<EmployeeFamily>> GetFamilyById(Guid employeeId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeeFamilys.Where(x => x.EmployeeId == employeeId).ToListAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<IEnumerable<EmployeeChildren>> GetChildrenById(Guid employeeId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeeChildrens.Where(x => x.EmployeeId == employeeId).ToListAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<EmployeeFamily> GetFamilyByFamilyId(Guid familyId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeeFamilys.Where(x => x.FamilyId == familyId).FirstOrDefaultAsync();
            return EmployeeRecordFormDB;
        }
        public async Task<EmployeeChildren> GetChildrenByChildrenId(Guid childrenId)
        {
            var EmployeeRecordFormDB = await _dbContext.EmployeeChildrens.Where(x => x.ChildrenId == childrenId).FirstOrDefaultAsync();
            return EmployeeRecordFormDB;
        }



    }
}
