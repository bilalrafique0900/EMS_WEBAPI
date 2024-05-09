using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {

        private readonly IGroupRepository _groupRepository;
        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(Group obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _groupRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _groupRepository.GetAllGroups(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("group-list")]
        public async Task<IActionResult> GetGroups(int pageNo, int pageSize,string searchText="") 
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _groupRepository.GetAll(pageNo, pageSize, c => c.IsDeleted != true &&  c.GroupName.Contains(searchText)),
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
                Data = await _groupRepository.Delete(id),
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
                Data = await _groupRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
