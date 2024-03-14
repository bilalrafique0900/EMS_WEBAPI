using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class ParentInformationDto : BaseModel
    {
        public Guid ParentId { get; set; }

        public Guid StudentId { get; set; }

        public string? FatherName { get; set; }

        public string? FatherContactNo { get; set; }
        public string? SecondFatherContactNo { get; set; }

        public string? FatherOccupation { get; set; }

        public string? FatherEmail { get; set; }

        public string? FatherCompany { get; set; }
        public string? MotherName { get; set; }

        public string? MotherContactNo { get; set; }

        public string? MotherOccupation { get; set; }

        public string? MotherEmail { get; set; }

        public string? MotherCompany { get; set; }

        public string? AlternativeName { get; set; }

        public string? AlternativeRelation { get; set; }

        public string? AlternativeContact { get; set; }
        public string? AlternativeNameSecond { get; set; }
        public string? AlternativeRelationSecond { get; set; }
        public string? AlternativeContactNoSecond { get; set; }
    }
}
