using EmployeeSystem.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentDto : BaseModel
    {
        public Guid StudentId { get; set; }
        public string? HCode { get; set; }
        //public string? temporaryCode { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? StudentEmail { get; set; }
        public string? Nationality { get; set; }
        public string? PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PassportNo { get; set; }
        public string? IDNo { get; set; }
        public string? MotherTongue { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string? StudentPhoneNo { get; set; }
        public string? Religion { get; set; }
        public Guid? GenderId { get; set; }
        public Guid? ClassId { get; set; }
        public Guid? SectionId { get; set; }
        public Guid? LevelId { get; set; }
        public bool? IsBusServices { get; set; }
        public bool? IsTaxiServices { get; set; }
        public bool? IsUniform { get; set; }
        public bool? IsLunchServices { get; set; }
        public bool? IsBooks { get; set; }
        public bool? IsVaacination { get; set; }
        public bool? IsPicturePermission { get; set; }
        public string? Picture { get; set; }
        public bool? IsMedicalReport { get; set; }
        public string? MedicalReportAttachment { get; set; }
        public bool? IsForeign { get; set; }
        public bool? IsAllergy { get; set; }
        public string? AllergyType { get; set; }
        public string? Base64 { get; set; }
        public string? WhereHearAboutSchool { get; set; }
        public Guid? ForSchoolSystemId { get; set; }
        public string? TransferCertificate { get; set; }
        public string? PreviousThreeYearReportCard { get; set; }
        public bool? IsPassportRenewed { get; set; }
        public string? PreviousSchoolEmail { get; set; }
        public string? ParentPassportID { get; set; }
        public string? CopyOfResidency { get; set; }
        public string? ConfirmationOfResidency { get; set; }
        public string? StreetName { get; set; }
        public string? HouseNo { get; set; }
        public Guid? AreaId { get; set; }
        public string? Address { get; set; }
        public string? ImagePath { get; set; }
        public string? AcadmicYear { get; set; }
        public Guid? AcadmicYearId { get; set; }
        public string? Group { get; set; }
        public string? Grade { get; set; }
        public string? year { get; set; }
        public Guid? ZoneId { get; set; }
        public Guid BranchId { get; set; }
        public Guid StatusId { get; set; }
        public DateTime? RenewDate { get; set; }

    }
}