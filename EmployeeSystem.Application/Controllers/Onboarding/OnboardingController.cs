using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Infra.IRepositories.IEmployee;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Repositories.Employee;
using ExcelDataReader;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using OfficeOpenXml;
using System.IO;
using System.Threading.Tasks;
using EmployeeSystem.Infra.IRepositories.ILovType;
using EmployeeSystem.Infra.IRepositories.IOnboarding;

namespace EmployeeSystem.Application.Controllers.Onboarding
{
    [Route("onboarding/")]
    [ApiController]
    public class OnboardingController : ControllerBase
    {

        private readonly IOnboardingRepository _OnboardingRepository;

        
        public OnboardingController(IOnboardingRepository OnboardingRepository )
        {
            _OnboardingRepository = OnboardingRepository;
            
        }
           

        [HttpGet("get-onboardings")]
        public async Task<IActionResult> GetOnboardings(int pageNo, int pageSize, string searchText = "")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _OnboardingRepository.GetOnboardingsPaginated(pageNo, pageSize, searchText),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpPost("post-onboarding")]
        public async Task<IActionResult> CreateUpdate(EmployeeSystem.Domain.Models.Onboarding obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _OnboardingRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
            [HttpGet("get-onboarding-byId")]
        public async Task<IActionResult> GetOnboardingById(Guid onboardingId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _OnboardingRepository.GetOnboardingById(onboardingId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet("get-clientcode")]
        public async Task<IActionResult> GetClientCode()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _OnboardingRepository.GetClientCode(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }



        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> Active(Guid onboardingId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _OnboardingRepository.Active(onboardingId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _OnboardingRepository.GetAllBoardings(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid onboardingId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _OnboardingRepository.Delete(onboardingId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }


    }
}

