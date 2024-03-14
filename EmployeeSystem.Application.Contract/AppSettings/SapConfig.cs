using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.AppSettings
{
    public class SapConfig
    {
        public bool IsEnabled { get; set; }
        public string? Authorization { get; set; }
        public string? ApiCreateStudent { get; set; }
        public string? ApiCreateInvoice { get; set; }
        
    }
}
