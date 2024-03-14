using AutoMapper;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Models;

namespace EmployeeSystem.Application.Contracts.MapperConfiguration
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<DocumentInfoDto, Document>().ReverseMap();
            CreateMap<EmployeeDto, Employee>().ReverseMap();
            CreateMap<EmployeeEducationDto, EmployeeEducation>().ReverseMap();
            CreateMap<EmployeePreviousExperienceDto, EmployeePreviousExperience>().ReverseMap();
            CreateMap<EmployeeFamilyDto, EmployeeFamily>().ReverseMap();
            CreateMap<EmployeeChildrenDto, EmployeeChildren>().ReverseMap();
            CreateMap<JobDescriptionDto, JobDescription>().ReverseMap();

        }
    }
}
