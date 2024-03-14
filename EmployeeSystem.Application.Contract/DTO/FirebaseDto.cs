using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class FirebaseDto
    {
        public string? Token { get; set; }
        public string? Topic { get; set; }
        public string? NotificationTitle { get; set; }
        public string? NotificationBody { get; set; }
        public object? Data { get; set; }
    }
}
