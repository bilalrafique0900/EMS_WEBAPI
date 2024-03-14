using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Infra.IRepositories.IDocument
{
    public interface IDocumentRepository
    {
        Task<ApiResponseModel> EmployeeDocumentUpload(DocumentInfoDto document);
        Task<ApiResponseModel> UploadDocument(DocumentInfoDto document);
        Task<ApiResponseModel> GetEmployeeAttachments(string Table, string TableRefrenceId);
        Task<List<Document>> GetDocumentsByTableRefrenceId(string Table, Guid TableRefrenceId);
        Task<bool> Delete(Guid id);
    }
}
