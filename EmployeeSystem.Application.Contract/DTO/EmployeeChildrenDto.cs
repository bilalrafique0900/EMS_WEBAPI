using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class EmployeeChildrenDto:BaseModel
    {
        public Guid ChildrenId { get; set; }
        
        public Guid? EmployeeId { get; set; }
        
        public string? NameOfChild { get; set; }
        
        public Guid? ChildGenderId { get; set; }
        
        public DateTime? ChildDateOfBirth { get; set; }
    }
}
