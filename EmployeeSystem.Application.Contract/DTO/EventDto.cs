namespace EmployeeSystem.Application.Contracts.DTO
{
    public class EventDto
    {
        
        public Guid? EventId { get; set; }

        public Guid EventForId { get; set; }
        public string? EventFor { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
        public Guid BranchId { get; set; }

        public Guid? CreatedBy { get; set; }
        public int totalRecords { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

    }
}
