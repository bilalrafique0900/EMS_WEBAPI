using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.Dapper
{
    public class TimeTypeHandler : SqlMapper.TypeHandler<TimeSpan>
    {
        public override TimeSpan Parse(object value)
        {
            if (value is TimeSpan timeSpan)
            {
                return timeSpan;
            }
            else if (value is DateTime dateTime)
            {
                return dateTime.TimeOfDay;
            }
            throw new DataException("Cannot convert to TimeSpan.");
        }

        public override void SetValue(IDbDataParameter parameter, TimeSpan value)
        {
            parameter.Value = value;
        }
    }
}
