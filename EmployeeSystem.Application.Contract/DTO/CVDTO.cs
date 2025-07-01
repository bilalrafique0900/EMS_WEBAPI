using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class CVDto
    {
        public int Id { get; set; }
        public int? CVCount { get; set; }
        public Guid? JobDescriptionId { get; set; }
        public Guid? PostHostId { get; set; }

        public string? JobDescriptionName { get; set; }
        public string? PostHostName { get; set; }
    }
}
