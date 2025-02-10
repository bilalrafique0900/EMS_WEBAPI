

using EmployeeSystem.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Domain.Models
{
    public  class Files 
    {   
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string FileName { get; set; }
        [StringLength(500)]
        public string FilePath { get; set; }
        [StringLength(200)]
        public string ContentType { get; set; }
        public Guid JobDescriptionId { get; set; }
        [StringLength(50)]
        //public string? Status { get; set; }// rejected, selected, pending, future, view  

        public string? Status { get; set; }


    }
}
