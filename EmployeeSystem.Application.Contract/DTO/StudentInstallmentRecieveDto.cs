namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentInstallmentRecieveDto
    {
        public Guid StudentInstallmentId { get; set; }
        public double ReceivedAmount { get; set; }

        public Nullable<Guid> CreatedBy { get; set; }
        public string Remarks { get; set; }
    }
}
