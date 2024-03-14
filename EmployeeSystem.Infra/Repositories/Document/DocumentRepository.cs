using AutoMapper;
using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.Dapper;
using Microsoft.EntityFrameworkCore;
using System.Data;
using EmployeeSystem.Infra.IRepositories.IDocument;

namespace EmployeeSystem.Infra.Repositories.Document
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly IMapper _mapper;
        public IDapperConfig _dapper { get; set; }
        public DocumentRepository(EmployeeDBContext appDbContext, IMapper mapper, IDapperConfig dapper)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _mapper = mapper;
        }
        public async Task<ApiResponseModel> EmployeeDocumentUpload(DocumentInfoDto document)
        {
            if (document.Base64Url != null)
            {
                string Base64 = "";
                int index = (document.Base64Url.IndexOf(","));
                if (index > 0)
                    Base64 = document.Base64Url.Substring(index + 1);
                document.DocumentGuid = CommonMethod.AddFile(Base64, document.DocumentPath);
            }
                var documentMapped = this._mapper.Map<DocumentInfoDto, Domain.Models.Document>(document);
            documentMapped.CreatedDate = DateTime.Now;
                await _dbContext.Documents.AddAsync(documentMapped);
            
            
            await _dbContext.SaveChangesAsync();
            return new ApiResponseModel
            {
                Status = true,
                Message = StaticVariables.SaveUpdatedRecord,
                Data = true
            };
        }
        public async Task<ApiResponseModel> UploadDocument(DocumentInfoDto document)
        {
            if (document.Base64Url != null)
            {
                string Base64 = "";
                int index = (document.Base64Url.IndexOf(","));
                if (index > 0)
                    Base64 = document.Base64Url.Substring(index + 1);
                document.DocumentGuid = CommonMethod.AddFile(Base64, document.DocumentPath);
            }
            var documentMapped = this._mapper.Map<DocumentInfoDto, Domain.Models.Document>(document);
            documentMapped.CreatedDate = DateTime.Now;
            await _dbContext.Documents.AddAsync(documentMapped);
            await _dbContext.SaveChangesAsync();
            return new ApiResponseModel
            {
                Status = true,
                Message = StaticVariables.SaveUpdatedRecord,
                Data = true
            };
        }
        public async Task<ApiResponseModel> GetEmployeeAttachments(string Table, string TableRefrenceId)
        {
            var AttachmentList = await _dapper.QueryAsync<DocumentInfoDto>("GetEmployeeAttachmentByReferenceId", new { @Table = Table, @TableRefrenceId = TableRefrenceId }, CommandType.StoredProcedure).ConfigureAwait(true);
            return new ApiResponseModel
            {
                Status = true,
                Message = StaticVariables.RecordFounded,
                Data = AttachmentList
            };
        }
        public async Task<List<Domain.Models.Document>> GetDocumentsByTableRefrenceId(string Table, Guid TableRefrenceId)
        {
            var documents = await _dbContext.Documents.Where(x => x.TableRefrenceId == TableRefrenceId && x.Table == Table && x.IsDeleted != true).ToListAsync();
            return documents;
            
        }
        public async Task<bool> Delete(Guid id)
        {
            IQueryable<Domain.Models.Document> DbQuery = _dbContext.Documents.Where(x => x.DocumentId == id);
            Domain.Models.Document results = await DbQuery.FirstOrDefaultAsync();
            if (results is not null)
            {
                results.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
