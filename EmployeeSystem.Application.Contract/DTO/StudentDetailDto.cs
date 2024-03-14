using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentDetailDto : BaseModel
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
        public string? RegisterdBy { get; set; }

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
        public string? SectionName { get; set; }

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

        public string? AreaName { get; set; }
        public string? Address { get; set; }
        public Guid? ParentId { get; set; }

        public string? FatherName { get; set; }

        public string? FatherContactNo { get; set; }

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
        public string? ClassName { get; set; }
        public string? LevelName { get; set; }
        public string? GenderName { get; set; }
        public string? SchoolSystem { get; set; }
        public bool? IsSubmitted { get; set; }
        public double? TotalRecords { get; set; }

        public string? Group { get; set; }
        public string? Grade { get; set; }
        public string? year { get; set; }
        public string? AcadmicYear { get; set; }
        public string? ZoneName { get; set; }
        public Guid BranchId { get; set; }
        public Guid? acadmicYearId { get; set; }
        public string? BranchName { get; set; }
        public Guid StatusId { get; set; }
        public Guid AreaId { get; set; }
        public Guid ZoneId { get; set; }
        public string? PreviousSchoolName { get; set; }
        public string? PreviousSchoolYear { get; set; }
        public string? PreviousSchoolGrade { get; set; }
        public string? PreviousSchoolCertificate { get; set; }
        public string? PreviousSchoolCertificateNumber { get; set; }
        public string? StudentStatus { get; set; }
        public DateTime? PreviousSchoolCertificateDate { get; set; }
        public string? ReasonForGoing { get; set; }
        public string? WhichSchoolGoing { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        public DateTime? RenewDate { get; set; }
        public string? SecondFatherContactNo { get; set; }
        public string? NameOfAcadmicYear { get; set; }
        public string? SapStudentCreated { get; set; }
        

    }
}