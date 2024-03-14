using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.AppSettings
{
    public class FirebaseSettings
    {
        public bool IsEnable { get; set; }
        public string? ServerKey { get; set; }
    }
}
