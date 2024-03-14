using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class RoomDto: BaseModel
    {
        public Guid RomeId { get; set; }
        public Guid BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? RoomName { get; set; }
        public double? TotalRecords { get; set; } = 0;
    }
}
