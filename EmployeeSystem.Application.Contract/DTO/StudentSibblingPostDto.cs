using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class StudentSibblingPostDto
    {
        public Guid StudentId { get; set; }
        public List<StudentSibblingInfoDto>? sibblingList { get; set; }

    }
}
