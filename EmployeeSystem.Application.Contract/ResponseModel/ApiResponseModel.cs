using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Application.Contracts.ResponseModel
{
    public class ApiResponseModel
    {
        public dynamic? Data { get; set; }
        public string Message { get; set; } = "";
        public Boolean Status { get; set; }
        public long totalCount { get; set; } 
        public List<string> ValidationErrors { get; set; } = new List<string>();
    }
}
