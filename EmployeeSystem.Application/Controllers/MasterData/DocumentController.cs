using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Common.Enumerations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EmployeeSystem.Infra.IRepositories.IDocument;

namespace EmployeeSystem.Application.Controllers.MasterData
{
    [Authorize]
    [Route("master/document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private readonly IDocumentRepository _DocumentRepository;
        public DocumentController(IDocumentRepository DocumentRepository)
        {
            _DocumentRepository = DocumentRepository;
        }
        [HttpPost]
        [RequestSizeLimit(400000000)]
        [Route("employee-document-uploaded")]
        public async Task<IActionResult> EmployeeDocumentUpload(DocumentInfoDto obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(await _DocumentRepository.EmployeeDocumentUpload(obj));

        }
        [HttpPost]
        [RequestSizeLimit(400000000)]
        public async Task<IActionResult> UploadDocument(DocumentInfoDto obj)
        {
            obj.CreatedBy = Guid.Parse(User?.Identity?.Name);
            return Ok(await _DocumentRepository.UploadDocument(obj));

        }
        [HttpGet]
        [Route("get-employee-document")]
        public async Task<IActionResult> GetEmployeeAttachments(string Table, string TableRefrenceId)
        {
            return Ok(await _DocumentRepository.GetEmployeeAttachments(Table, TableRefrenceId));
        }
        [HttpGet]
        public async Task<IActionResult> GetAttachments(string Table, Guid TableRefrenceId)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _DocumentRepository.GetDocumentsByTableRefrenceId(Table, TableRefrenceId),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
        [HttpDelete]
        [Route("deleteDocument/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(new ApiResponseModel
            {
                Status = true,
                Data = await _DocumentRepository.Delete(id),
                Message = StaticVariables.SaveUpdatedRecord
            });
        }
    }
}
