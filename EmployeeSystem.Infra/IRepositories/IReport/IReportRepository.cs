﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.IRepositories.IReporting
{
    public interface IReportRepository
    {
       Task<byte[]> Generate();
    }
}
