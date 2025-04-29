using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MailKit.Search;
using EmployeeSystem.Infra.Repositories.MasterData;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/level")]
    [ApiController]
    public class LevelController : ControllerBase
    {

        private readonly ILevelRepository _levelRepository;
        public LevelController(ILevelRepository levelRepository)
        {
            _levelRepository = levelRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(Level obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _levelRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _levelRepository.GetAllLevels(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("level-list")]
        public async Task<IActionResult> GetLevels(int pageNo, int pageSize,string searchText="") 
        {
            var result = await _levelRepository.GetAll(pageNo, pageSize, c => c.IsDeleted != true && c.LevelName.Contains(searchText));
            
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = result,
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
                Data = await _levelRepository.Delete(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("level-by-groupid")]
        public async Task<IActionResult> GetLevelsByGroupId(Guid GroupId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _levelRepository.GetLevelsByGroupId(GroupId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("level-by-groupcode")]
        public async Task<IActionResult> GetLevelsByGroupCode(string GroupCode="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _levelRepository.GetLevelsByGroupCode(GroupCode),
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
                Data = await _levelRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
