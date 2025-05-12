using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.IRepositories.UserManagement;
using EmployeeSystem.Application.Contracts.HelperMethods;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Infra.IServices;
using Microsoft.EntityFrameworkCore;

namespace EmployeeSystem.Infra.Repositories.UserManagement
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly IUserRepository _userRepository;
        private readonly JwtHandler _jwtHandler;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IRoleRepository _iRoleRepository;
        private readonly IJobPermissionRepository _iJobPermissionRepository;
        private readonly IMailService _mailService;
        public AuthenticationRepository(EmployeeDBContext appDbContext, IUserRepository userRepository, JwtHandler jwtHandler, IRolePermissionRepository rolePermissionRepository, IRoleRepository iRoleRepository, IJobPermissionRepository iJobPermissionRepository, IMailService mailService)
        {
            _dbContext = appDbContext;
            _userRepository = userRepository;
            _jwtHandler = jwtHandler;
            _rolePermissionRepository = rolePermissionRepository;
            _iRoleRepository = iRoleRepository;
            _iJobPermissionRepository= iJobPermissionRepository;
            _mailService = mailService;
        }
        public async Task<ApiResponseModel> LoginUserAsync(LoginDto loginRequest)
        {
            var user = await _userRepository.FindByEmailAsync(loginRequest.Email);
            if (user == null || !await _userRepository.CheckPasswordAsync(user, loginRequest))
            {
                return new ApiResponseModel
                {
                    Status = false,
                    Message = "Invalid UserName or Password.",
                    Data = null
                };
            }
            var role = await _iRoleRepository.GetById(user.RoleId);
            var jobPermission = await _iJobPermissionRepository.GetJobPermissionByRoleId(user.RoleId);
            LoginStudent student = null;
            LoginParent parent = null;
            LoginTeacher teacher = null;
            
            //if (role.KeyCode == nameof(RoleKeyCode.STUDENT))
            //{
            //    student = await _studentRepository.GetLoginStudent(user.UserId);
            //}
            //else if (role.KeyCode == nameof(RoleKeyCode.PARENT))
            //{
            //    parent = await _studentUserRepository.GetLoginParent(user.UserId);
            //}
            //else if (role.KeyCode == nameof(RoleKeyCode.TEACHER))
            //{
            //    teacher = await _teacherRepository.GetLoginTearcher(user.UserId);
            //}
            return new ApiResponseModel
            {
                Status = true,
                Message = "Success",
                Data = new
                {
                    token = _jwtHandler.GetToken(user),
                    user = new
                    {
                        user.UserId,
                        user.Email,
                        role.RoleName,
                        RoleKeyCode = role.KeyCode,
                        role.DefaultUrl,
                        user.FullName,
                        jobPermission.IsJobCreator,
                        jobPermission.IsJobApprover,
                        jobPermission.IsJobPublisher
                    },
                    student,
                    teacher,
                    parent,
                    permissions = await _rolePermissionRepository.GetPermissionByRoleIdForLogin(user.RoleId)
                }
            };
        }

        public async Task<bool> ForgotPasswordAsync(string email)
        {
            try
            {
                string password = await _dbContext.Users.Where(m => m.Email == email).Select(m => m.Password).FirstOrDefaultAsync();
                if (string.IsNullOrEmpty(password))
                    throw new Exception("User not found.");

                password = CommonMethod.DESDecrypt(password);
                var mail = new MailDto(new List<string>{ email },"LMS forgot password","Your password is:"+password);
                CancellationToken ct = default;
               return await _mailService.SendAsync(mail, ct);
            }
            catch (Exception)
            {

                throw;
            }
            return false;

        }
        public async Task<ApiResponseModel> CheckUser(LoginDto loginRequest)
        {
            var user = await _userRepository.FindByEmailAsync(loginRequest.Email);
            if (user == null || !await _userRepository.CheckPasswordAsync(user, loginRequest))
            {
                return new ApiResponseModel
                {
                    Status = false,
                    Message = "Invalid UserName or Password.",
                    Data = null
                };
            }
            return new ApiResponseModel
            {
                Status = true,
                Message = "valid UserName or Password.",
                Data = null
            };
        }
        public async Task<bool> ChangePassword(ChangePasswordDto loginRequest)
        {
            try
            {
                var user = await _userRepository.FindByEmailAsync(loginRequest.Email);
                if (user is null)
                {
                    throw new Exception("User's email not found");
                }
                if (user.Password!= CommonMethod.DESEncrypt(loginRequest.OldPassword))
                {
                    throw new Exception("Old password is wrong.");
                }

                user.Password = CommonMethod.DESEncrypt(loginRequest.Password);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
