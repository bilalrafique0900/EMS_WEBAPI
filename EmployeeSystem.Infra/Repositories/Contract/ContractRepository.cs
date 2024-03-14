using AutoMapper;
using EmployeeSystem.Domain.Common.CommonMethod;
using EmployeeSystem.Application.Contracts.DTO;
using EmployeeSystem.Domain.Common.Enumerations;
using EmployeeSystem.Application.Contracts.ResponseModel;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Domain.Models;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IMasterData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using EmployeeSystem.Infra.IRepositories.IContract;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.PortableExecutable;
using iText.Kernel.Pdf;
using iText.Forms;

namespace EmployeeSystem.Infra.Repositories.Contract
{
    public class ContractRepository : IContractRepository
    {
        private readonly EmployeeDBContext _dbContext;
        private readonly IMapper _mapper;
        public IDapperConfig _dapper { get; set; }
        public ContractRepository(EmployeeDBContext appDbContext, IMapper mapper, IDapperConfig dapper)
        {
            _dbContext = appDbContext;
            _dapper = dapper;
            _mapper = mapper;
        }
        
       
        public async Task<string> GetStudentContract(string Contract, Guid StudentId)
        {
           var ContactData = await _dapper.QueryAsync<ContractDto>("GetStudentContract", new { @StudentId = StudentId }, CommandType.StoredProcedure).ConfigureAwait(true);
           var filepath= ContactDocument(Contract, ContactData);
           return filepath;
        }

        private string ContactDocument(string Contract, IEnumerable<ContractDto> Data)
        {
            try
            {
                string src = System.AppDomain.CurrentDomain.BaseDirectory + @"Contracts\" + Contract;
                var filledFile = Contract.Split('.')[0] + "_" + Data.FirstOrDefault().StudentId.ToString() + ".pdf";
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\StudentDocuments\", filledFile);

                //string dest = System.AppDomain.CurrentDomain.BaseDirectory + filledFile;
                PdfDocument pdf = new PdfDocument(new PdfReader(src), new PdfWriter(filePath));

                PdfAcroForm form = PdfAcroForm.GetAcroForm(pdf, true);
                foreach (var data in Data)
                {
                    var session = form.GetField("Session");
                    session.SetValue(data.Session);
                    session.SetReadOnly(true);

                    var fullName = form.GetField("FullName");
                    fullName.SetValue(data.FullName);
                    fullName.SetReadOnly(true);

                    var fatherName = form.GetField("FatherName");
                    fatherName.SetValue(data.FatherName);
                    fatherName.SetReadOnly(true);

                    var hCode = form.GetField("HCode");
                    hCode.SetValue(data.HCode);
                    hCode.SetReadOnly(true);

                    var className = form.GetField("ClassName");
                    className.SetValue(data.ClassName);
                    className.SetReadOnly(true);

                    var applicationFee = form.GetField("ApplicationFee");
                    applicationFee.SetValue(data?.ApplicationFee ?? "0");
                    applicationFee.SetReadOnly(true);

                    if (data.TuitionFee != null)
                    {
                        var tuitionFee = form.GetField("TuitionFee");
                        tuitionFee.SetValue(data.TuitionFee ?? "0");
                        tuitionFee.SetReadOnly(true);
                    }

                    if (data?.BusFee != null)
                    {
                        var busFee = form.GetField("BusFee");
                        busFee.SetValue(data.BusFee ?? "0");
                        busFee.SetReadOnly(true);

                    }

                    if (data?.LunchFee != null)
                    {
                        var lunchFee = form.GetField("LunchFee");
                        lunchFee.SetValue(data.LunchFee ?? "0");
                        lunchFee.SetReadOnly(true);
                    }

                    if (data?.TaxiFee != null)
                    {
                        var taxiFee = form.GetField("TaxiFee");
                        taxiFee.SetValue(data.TaxiFee ?? "0");
                        taxiFee.SetReadOnly(true);
                    }
                    if (data?.ResourceFee != null)
                    {
                        var resourceFee = form.GetField("ResourceFee");
                        resourceFee.SetValue(data.ResourceFee ?? "0");
                        resourceFee.SetReadOnly(true);
                    }


                    if (data?.TotalFee != null)
                    {
                        var totalFee = form.GetField("TotalFee");
                        totalFee.SetValue(data.TotalFee ?? "0");
                        totalFee.SetReadOnly(true);
                    }




                }







                pdf.Close();
                return filledFile;
            }
            catch (Exception)
            {

                throw new Exception("Some information is missing");
            }
            


        }
       
    }
}
