using System.ComponentModel.DataAnnotations;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class UserTokenDto
    {
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? Firebase { get; set; }

    }
}
