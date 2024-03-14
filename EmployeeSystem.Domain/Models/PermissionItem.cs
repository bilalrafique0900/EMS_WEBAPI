using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public partial class PermissionItem : BaseModel
    {

        [Key]
        public Guid PermissionItemId { get; set; }
        public Guid? ParentId { get; set; }
        [StringLength(30)]
        public string? Title { get; set; }
        [StringLength(50)]
        public string? Description { get; set; }
        [StringLength(100)]
        public string? URL { get; set; }
        [StringLength(30)]
        public string? Code { get; set; }
        public int SortOrder { get; set; }
        [StringLength(30)]
        public string? Icon { get; set; }
        public bool IsMenuItem { get; set; }
    }
}
