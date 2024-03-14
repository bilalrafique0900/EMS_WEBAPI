using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/employee-document/")]
    [ApiController]
    public class EmployeeDocumentController : ControllerBase
    {

        private readonly IEmployeeDocumentRepository _EmployeeDocumentRepository;
        public EmployeeDocumentController(IEmployeeDocumentRepository EmployeeDocumentRepository)
        {
            _EmployeeDocumentRepository = EmployeeDocumentRepository;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUpdate(EmployeeDocument obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeDocumentRepository.CreateUpdate(obj),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeDocumentRepository.GetAllEmployeeDocuments(),
                Message = StaticVariables.RecordFounded
            });
        }
        [HttpGet]
        [Route("document-list")]
        public async Task<IActionResult> GetEmployeeDocuments(int pageNo, int pageSize,string searchText="")
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeDocumentRepository.GetAll(pageNo, pageSize, c => c.IsDeleted != true && c.DocumentName.Contains(searchText)),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeDocumentRepository.Delete(id),
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
                Data = await _EmployeeDocumentRepository.Active(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpGet]
        [Route("required")]
        public async Task<IActionResult> required(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _EmployeeDocumentRepository.IsRequired(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
