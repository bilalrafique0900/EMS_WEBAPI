using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TemplateDto
    {
        public Guid TemplateId { get; set; }
        public string? TemplateName { get; set; }
        public Guid TemplateTypeId { get; set; }
        public string? TemplateTypeName { get; set; }
        public string? TemplateKeyCode { get; set; }
        public string? TemplateContent { get; set; }
        public Guid BranchId { get; set; }
        public string? BranchName { get; set; }

    }
}