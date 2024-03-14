using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class DocumentInfoDto
    {
        public Guid DocumentId { get; set; }
        public Guid? LovId { get; set; }
        public string? Table { get; set; }
        public Guid TableRefrenceId { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? DocumentGuid { get; set; }
        public string? DocumentPath { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentFileName { get; set; }
        public string? DocumentSize { get; set; }
        public string? DocumentExtension { get; set; }
        public string? Base64Url { get; set; }
        public string? LovName { get; set; }
        public string? AttachmentId { get; set; }
        public bool? DocumentStatus { get; set; }

    }
}