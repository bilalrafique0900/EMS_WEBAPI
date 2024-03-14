using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/posthost")]
    [ApiController]
    public class PostHostController : ControllerBase
    {

        private readonly IPostHostRepository _posthostRepository;
        public PostHostController(IPostHostRepository posthostRepository)
        {
            _posthostRepository = posthostRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(PostHost obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _posthostRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _posthostRepository.GetAllPostHosts(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("posthost-list")]
        public async Task<IActionResult> GetPostHosts(int pageNo, int pageSize,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _posthostRepository.GetAll(pageNo, pageSize, c => c.IsDeleted != true  && c.PostHostName.Contains(searchText)),
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
                Data = await _posthostRepository.Delete(id),
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
                Data = await _posthostRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
