using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeSystem.Domain.Models
{
    public class CV
    {
        [Key]
        public int Id { get; set; }

        public int? CVCount { get; set; }

        public Guid? JobDescriptionId { get; set; }
        public Guid? PostHostId { get; set; }

        // Navigation Properties
        [ForeignKey("JobDescriptionId")]
        public virtual JobDescription? JobDescription { get; set; }

        [ForeignKey("PostHostId")]
        public virtual PostHost? PostHost { get; set; }
    }
}
