namespace EmployeeSystem.Application.Contracts.DTO
{
    public class NotificationDto
    {
        public NotificationDto()
        {
            CreatedDate = DateTime.Now;
        }

        public Guid NotificationId { get; set; }
        public Guid BranchId { get; set; }
        public Guid? ToUserId { get; set; }

        public string? NotifincationType { get; set; }

        public string? RedirectUrl { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }
        public bool IsRead { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}