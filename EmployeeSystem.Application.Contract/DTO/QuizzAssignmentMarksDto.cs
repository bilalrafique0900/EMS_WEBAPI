using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class QuizzAssignmentMarksDto
    {
        public Guid? StudentId { get; set; }
        public Guid? TermId { get; set; }
        public Guid? QuizzAssignmentId { get; set; }
        public double ObtainMarks { get; set; }
        public string? FullName { get; set; }
        public string? HCode { get; set; }
    }
}