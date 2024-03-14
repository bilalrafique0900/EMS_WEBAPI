using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class SapAddPaymentTypeDto
    {
        public SapAddPaymentTypeDto()
        {
            PaymentTypes = new List<StudentPaymentTypeDto>();
        }
        public Guid StudentId { get; set; }
        public bool? IsBusServices { get; set; }
        public bool? IsTaxiServices { get; set; }
        public bool? IsLunchServices { get; set; }
        public List<StudentPaymentTypeDto> PaymentTypes { get; set; }
    }
}
