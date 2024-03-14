namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentPaymentDto
    {
        public Guid StudentPaymentId { get; set; }
        public Guid? StudentId { get; set; }
        public string? FullName { get; set; }
        public string? HCode { get; set; }
        
        public DateTime? DateOfBirth { get; set; }
        public bool? IsBusServices { get; set; }
        public bool? IsLunchServices { get; set; }
        public string? PassportNo { get; set; }
        public string? IDNo { get; set; }
        public string? PaymentReceived { get; set; }
        public string? AcadmicYear { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string? CreatedUser { get; set; }
        public string? ClassName { get; set; }
        public double? TotalRecords { get; set; }
    }
  
}
