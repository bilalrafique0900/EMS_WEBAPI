using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Ocsp;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;
using iText.Commons.Actions.Contexts;

namespace EmployeeSystem.Infra.Repositories.UserManagement
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly ILogger _logger;
        public IDapperConfig _dapper { get; set; }
        public UserRepository(EmployeeDBContext appDbContext, IDapperConfig dapper, ILogger<UserRepository> logger) : base(appDbContext)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _logger = logger;
        }

        public async Task<bool> AddUserAsync(UserDto user)
        {
            if (user.UserId != null)
            {
                IQueryable<User> query = _dbContext.Users.IgnoreQueryFilters().Where(p => p.UserId == user.UserId);
                User result = await query.FirstOrDefaultAsync();
                if (result != null)
                {
                    result.UpdatedDate = DateTime.Now;
                    result.RoleId = user.RoleId;
                    result.FullName = user.FullName;
                    result.UpdatedBy = user.CreatedBy; 
                    result.CreatedDate = DateTime.Now;
                    //result.IsJobCreator = user.IsJobCreator;
                    //result.IsJobApprover= user.IsJobApprover;
                    //result.IsJobPublisher= user.IsJobPublisher;
                }
                else
                {
                    var usr = new User
                    {
                        Email = user.Email,
                        RoleId = user.RoleId,
                        FullName = user.FullName,
                        Password = CommonMethod.DESEncrypt(user.Password),
                        IsActive = true,
                        CreatedDate = DateTime.Now,
                       CreatedBy=user.CreatedBy
                       //IsJobCreator=user.IsJobCreator,
                       //IsJobApprover=user.IsJobApprover,
                       //IsJobPublisher=user.IsJobPublisher
                    };
                    await _dbContext.Users.AddAsync(usr);
                }
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<UserDto>> GetUsers(int pageNo, int pageSize, string searchText)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@pageNo", pageNo);
            parameters.Add("@pageSize", pageSize);
            parameters.Add("@seaechText", searchText);
            return await _dapper.QueryAsync<UserDto>("GetUsers", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
        }
        public async Task<bool> UpdateUserRoleAsync(UserDto user)
        {
            var rec = await _dbContext.Users.Where(x => x.UserId == user.UserId).FirstOrDefaultAsync();
            if (rec != null)
            {
                rec.RoleId = user.RoleId;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _dbContext.Users.AnyAsync(x => x.Email == email); 

        }
        public async Task<User> FindByEmailAsync(string email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(x =>
            x.Email.Trim().ToLower() == email.Trim().ToLower()
            && x.IsActive == true && x.IsDeleted != true
            );
            return user;
        }
        public async Task<bool> CheckPasswordAsync(User user, LoginDto loginRequest)
        {
            var userPassword = await _dbContext.Users.IgnoreQueryFilters().FirstOrDefaultAsync(x =>
            x.UserId == user.UserId
            && x.Password == CommonMethod.DESEncrypt(loginRequest.Password)
            && x.IsActive == true
            );
            return userPassword != null;
        }
        public async Task<bool> Delete(Guid id)
        {
            var rec = await _dbContext.Users.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.UserId == id);
            if (rec != null)
            {
                rec.IsDeleted = rec.IsDeleted == true ? false : true;
            }
            await _dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Active(Guid id)
        {
            var rec = await _dbContext.Users.IgnoreQueryFilters().Where(x => x.UserId == id).FirstOrDefaultAsync();
            if (rec != null)
            {
                rec.IsActive = !rec.IsActive;
            }
            await _dbContext.SaveChangesAsync();
            _logger.LogInformation($"User {id} active status changed to  {rec.IsActive}.");
            return true;
        }

        public async Task<bool> ChangePassword(Guid userId,Guid updatedUser, string password)
        {
            try
            {
                var user = await _dbContext.Users.FirstOrDefaultAsync(m => m.UserId == userId);
                if (user is not null)
                {
                    user.Password = CommonMethod.DESEncrypt(password);
                    await _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"{userId} User password changed by {updatedUser}.");
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
