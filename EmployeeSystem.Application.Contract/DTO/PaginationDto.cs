using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class PaginationDto
    {
        
        public Guid? branchId { get; set; }
        public int pageNo { get; set; }
        public int pageSize { get; set; }
        public string? orderColumn { get; set; }
        public string? orderType { get; set; }
        public string? searchText { get; set; } = "";
    }
  
}
