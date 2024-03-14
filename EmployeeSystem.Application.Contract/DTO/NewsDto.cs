using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class NewsDto
    {
        public NewsDto()
        {
            CreatedDate=DateTime.Now;
        }
        public Guid NewsId { get; set; }
        public Guid NewForId { get; set; }
        public string? NewFor { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        public Guid BranchId { get; set; }
        public Guid? CreatedBy { get; set; }
        public int totalRecords { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
