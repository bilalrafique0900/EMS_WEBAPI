using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class EmployeeDto : BaseModel
    {
        public Guid EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        //public string? temporaryCode { get; set; }
        
        public Guid? EmployeeDesignationId { get; set; } 
        public Guid? JobDescriptionId { get; set; }
        public Guid? GroupId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? FunctionId { get; set; }
        public Guid? LevelId { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalEmail { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Contact { get; set; }
        public string? Cnic { get; set; }

        public Guid? GenderId { get; set; }
        public Guid? EmployeeTypeId { get; set; }
        public Guid? MaritalStatusId { get; set; }
        public Guid? EducationTypeId { get; set; }
        public bool? IsPicturePermission { get; set; }
        public Guid? EmploymentTypeId { get; set; }
        public string? Picture { get; set; }
        public string? Base64 { get; set; }
        public string? StreetAddress { get; set; }
        public string? Mohallah { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PermanentStreetAddress { get; set; }
        public string? PermanentMohallah { get; set; }
        public string? PermanentCity { get; set; }
        public string? PermanentTehsil { get; set; }
        public string? PermanentDistrict { get; set; }
        public string? PermanentState { get; set; }
        public string? ImagePath { get; set; }

    }
}