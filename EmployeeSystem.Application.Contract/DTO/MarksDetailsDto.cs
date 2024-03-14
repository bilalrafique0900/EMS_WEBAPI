using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class MarksDetailsDto
    {
       
        public Guid? MarksDetailId { get; set; }
        public Guid? MarksId { get; set; }
        public Guid StudentId { get; set; }
        public string? FullName{ get; set; }
        public string? HCode { get; set; }
        public double ObtainMarks { get; set; }
        public bool IsChanged { get; set; }
    }
  
}