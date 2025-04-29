using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Domain.Models
{
    public class EmployeeAccessories
    {
        public Guid EmployeeAccessoriesId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid AccessoriesId { get; set; }
        public virtual Accessories Accessories { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
