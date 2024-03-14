using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class LovSelectItemDto
    {
        public Guid Id { get; set; }
        public string? text { get; set; }
        public string? code { get; set; }
        public string? loveTypeCode { get; set; }
    }
}
