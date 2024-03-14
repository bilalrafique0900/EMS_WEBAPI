using EmployeeSystem.Application.Contracts.DTO;
using Org.BouncyCastle.Asn1.Pkcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.IServices
{
    public interface IMailService
    {
        Task<bool> SendAsync(MailDto mailData, CancellationToken ct);
    }
}
