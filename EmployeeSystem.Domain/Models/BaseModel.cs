using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public class BaseModel
    {
        public BaseModel()
        {
            CreatedDate = DateTime.Now;
            IsActive = true;
            IsDeleted = false;
        }

        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public Nullable<DateTime> CreatedDate { get; set; }

        public Nullable<Guid> CreatedBy { get; set; }

        public Nullable<DateTime> UpdatedDate { get; set; }

        public Nullable<Guid> UpdatedBy { get; set; }
    }
}
