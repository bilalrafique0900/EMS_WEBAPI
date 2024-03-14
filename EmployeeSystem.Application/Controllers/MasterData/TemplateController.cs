using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/template")]
    [ApiController]
    public class TemplateController : ControllerBase
    {

        private readonly ITemplateRepository _templateRepository;
        public TemplateController(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(Template obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _templateRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _templateRepository.GetAllTemplates(),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("template-list")]
        public async Task<IActionResult> GetTemplates(int pageNo, int pageSize,Guid branchId,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _templateRepository.GetAll(pageNo, pageSize, c => c.IsDeleted != true && c.BranchId==branchId && c.TemplateName.Contains(searchText)),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _templateRepository.Delete(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("active")]
        public async Task<IActionResult> Active(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _templateRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
