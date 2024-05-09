using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Infra.Repositories.MasterData;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/function")]
    [ApiController]
    public class FunctionsController : ControllerBase
    {

        private readonly IFunctionRepository _functionRepository;
        public FunctionsController(IFunctionRepository functionRepository)
        {
            _functionRepository = functionRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(Functions obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _functionRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _functionRepository.GetAllFunctions(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("function-by-groupid")]
        public async Task<IActionResult> GetFunctionsByGroupId(Guid GroupId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _functionRepository.GetFunctionsByGroupId(GroupId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]

        [Route("function-list")]
        public async Task<IActionResult> GetFunctions(int pageNo, int pageSize,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _functionRepository.GetAllFunctions(pageNo, pageSize, searchText),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _functionRepository.Delete(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("active/{id}")]
        public async Task<IActionResult> Active(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _functionRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
