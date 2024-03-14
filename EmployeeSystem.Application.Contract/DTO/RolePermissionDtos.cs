using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class RolePermissionDtos
    {
        public Guid PermissionItemId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid? RoleId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
        public string? Code { get; set; }
        public string? Icon { get; set; }
        public bool IsMenuItem { get; set; }
        public bool IsAssigned { get; set; }
        public int SortOrder { get; set; }
    }
}
