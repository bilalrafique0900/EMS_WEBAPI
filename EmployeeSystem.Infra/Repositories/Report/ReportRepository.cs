using AutoMapper;
using DinkToPdf.Contracts;
using DinkToPdf;
using EmployeeSystem.EntityFrameworkCore.DBContext;
using EmployeeSystem.Infra.Dapper;
using EmployeeSystem.Infra.IRepositories.IReporting;
using iText.Kernel.Geom;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSystem.Infra.Repositories.Report
{
    public class ReportRepository : IReportRepository
    {
        public IDapperConfig _dapper { get; set; }
        private IConverter _converter;
        public ReportRepository( IDapperConfig dapper, IConverter converter) 
        {
            _dapper = dapper;
            _converter = converter;
        }
        public async Task<byte[]> Generate()
        {
            SqlParameter[] parameters ={
                  //new SqlParameter("@pageNo", 1) ,
                  //new SqlParameter("@pageSize", 100) ,
                  //new SqlParameter("@searchText", "")
            };

            DataTable data = await _dapper.GetDataTableAsync("GetReport", parameters, CommandType.StoredProcedure).ConfigureAwait(true);
            StringBuilder sb = new("<style>table {font-family:Cursive;}</style> <table style='width:100%;text-align:left'><thead><tr>");
            foreach (DataColumn column in data.Columns)
            {
                sb.Append("<th>" + column.ColumnName + "</th>");
            }
            sb.Append("</tr></thead>");

            foreach (DataRow row in data.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in data.Columns)
                {
                    sb.Append("<td>" + row[column.ColumnName].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }
            sb.Append("</tr></table>");


            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Landscape,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = sb.ToString(),
                WebSettings = { DefaultEncoding = "utf-8", },
                HeaderSettings = { FontName = "Arial", FontSize = 9, Center = "Title", Line = true },
                FooterSettings = { FontName = "Arial", FontSize = 9, Line = true, Right = "Page [page] of [toPage]" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };
            return _converter.Convert(pdf);
        }
    }
}
