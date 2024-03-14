using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.DTO
{
    public class TimetableSectionWiseDto
    {

        public Guid ClassId { get; set; }
        public Guid SectionId { get; set; }
        public Guid BranchId { get; set; }
        public string BreakTime1 { get; set; }
        public int Break1Duration { get; set; }
        public string? BreakTime2 { get; set; }
        public int? Break2Duration { get; set; }
        public string? BreakTime3 { get; set; }
        public int? Break3Duration { get; set; }
        public string PeriodDuration { get; set; }
        public int? PeriodBreak { get; set; }

    }
}
