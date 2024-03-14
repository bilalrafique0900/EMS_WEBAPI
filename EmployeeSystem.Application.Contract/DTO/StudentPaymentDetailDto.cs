using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentPaymentDetailDto
    {
        public StudentPaymentDetailDto() {
            StudentPaymentTypes=new List<StudentPaymentTypeDto>();
        }
        public StudentPaymentDto? studentPayment { get; set; }
        public List<StudentPaymentTypeDto> StudentPaymentTypes { get; set; }
    }
}
