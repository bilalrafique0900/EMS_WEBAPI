using Dapper;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IUserManagement;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.Repositories.UserManagement
{
    public class UserTokenRepository : IUserTokenRepository
    {
        private readonly EmployeeDBContext _dbContext;
        public IDapperConfig _dapper { get; set; }
        public UserTokenRepository(EmployeeDBContext dbContext
            , IDapperConfig dapper) {

            _dbContext = dbContext;
            _dapper = dapper;
        }
        public async Task<UserToken> AddUpdate(UserToken userToken)
        {
            try
            {
                UserToken existingToken = await _dbContext.UserTokens.FirstOrDefaultAsync(x => x.UserId == userToken.UserId);
                if (existingToken is not null)
                {
                    existingToken.UpdatedDate = DateTime.UtcNow;

                    existingToken.Firebase=userToken.Firebase;
                }
                else
                    await _dbContext.UserTokens.AddAsync(userToken);

                await _dbContext.SaveChangesAsync();
                return userToken;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserToken> GetByUserIdAsync(Guid userId)
        {
            return await _dbContext.UserTokens.FirstOrDefaultAsync(x => x.UserId == userId);
        }

        public async Task<IEnumerable<UserTokenDto>> GetStudentToken()
        {
            var parameters = new DynamicParameters();
            return await _dapper.QueryAsync<UserTokenDto>("GetStudentsUserToken", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
        }

        public async Task<IEnumerable<UserTokenDto>> GetParentToken()
        {
            var parameters = new DynamicParameters();
            return await _dapper.QueryAsync<UserTokenDto>("GetParentUserTokens", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
        }

        public async Task<IEnumerable<UserTokenDto>> GetAssignmentStudentToken(Guid assignmentId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@AssignmentId", assignmentId);
            return await _dapper.QueryAsync<UserTokenDto>("GetAssgnmentStudentTokens", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
        }
    }
}
