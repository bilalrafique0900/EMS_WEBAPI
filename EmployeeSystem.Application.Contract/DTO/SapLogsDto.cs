using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class SapLogsDto
    {
        public string? LogType { get; set; }
        public string? Response { get; set; }
        public string? Payload { get; set; }
        public string? FullName { get; set; }
        public string? HCode { get; set; }
        public Guid? StudentId { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
