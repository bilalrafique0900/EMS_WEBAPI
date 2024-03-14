﻿using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class JobDescriptionDto : BaseModel
    {
        public Guid JobDescriptionId { get; set; }
        
        public string? Title { get; set; }
        
        public Guid? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public Guid? GroupId { get; set; }
        public string? GroupName { get; set; }
        public Guid? HiringManagerId { get; set; }
        public string? ManagerName { get; set; }
        public Guid? PostHostId { get; set; }
        public string? PostHostName { get; set; }
        public Guid? EmploymentTypeId { get; set; }
        public string? EmploymentTypeName { get; set; }
        public DateTime? JobOpeningDate { get; set; }
        public string? Description { get; set; }
        public double? TotalRecords { get; set; }




    }
}