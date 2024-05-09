using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class FunctionDto : BaseModel
    {
        public Guid FunctionId { get; set; }
        
      
        public string? FunctionName { get; set; }

        public Guid? GroupId { get; set; }
        public string? GroupName { get; set; }
     
        
        




    }
}