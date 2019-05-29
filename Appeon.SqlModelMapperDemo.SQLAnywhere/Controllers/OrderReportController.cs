using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.SQLAnywhere.Models;
using Appeon.SqlModelMapperDemo.SQLAnywhere.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderReportController : ControllerBase
    {
        private readonly IOrderReportService _reportService;
        private readonly IGenericServiceFactory _genericServices;

        public OrderReportController(IOrderReportService reportService,
                                     IGenericServiceFactory genericServiceFactory)
        {
            _reportService = reportService;
            _genericServices = genericServiceFactory;
        }

        // GET api/OrderReport/WinOpen
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IDataPacker> WinOpen()
        {
            var packer = new DataPacker();
            int cateId = 0;

            var category = _genericServices.Get<Category>().Retrieve(false);
            var subCategory = _genericServices.Get<SubCategory>()
                              .Retrieve(false, cateId);

            if(category.Count == 0 || subCategory.Count == 0)
            {
                return NotFound();
            }

            packer.AddModels("Category", category);
            packer.AddModels("SubCategory", subCategory);

            return packer;
        }

        // GET api/OrderReport/CategorySalesReport
        [HttpGet("{queryFrom}/{queryTo}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IDataPacker> CategorySalesReport(
            string queryFrom, string queryTo)
        {
            var packer = new DataPacker();

            var dataFrom = DateTime.Parse(queryFrom);
            var dataTo = DateTime.Parse(queryTo);
            var lastDataFrom = DateTime.Parse(queryFrom).AddYears(-1);
            var lastDataTo = DateTime.Parse(queryTo).AddYears(-1);
            var master = new CategorySalesReport();

            var CategoryReport = _reportService.RetrieveCategorySalesReport(
                                 master, dataFrom, dataTo,lastDataFrom, lastDataTo);

            if(CategoryReport.SalesReportByCategory.Count == 0)
            {
                return NotFound();
            }

            packer.AddModel("Category", CategoryReport)
                  .Include("SalesReport", m => m.SalesReportByCategory)
                  .Include("LastYearSalesReport", m => m.LastYearSalesReportByCategory);

            return packer;
        }

        // GET api/OrderReport/SalesReportByMonth
        [HttpGet("{subCategoryId}/{salesYear}/{halfYear}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IDataPacker> SalesReportByMonth(
            int subCategoryId, string salesYear, string halfYear)
        {
            var packer = new DataPacker();
            
            var fromDate = DateTime.Parse(
                halfYear == "first" ? salesYear + "-01-01" : salesYear + "-07-01");
            var toDate = DateTime.Parse(
                halfYear == "first" ? salesYear + "-06-30" : salesYear + "-12-31");
            object[] yearMonth = new object[7];

            yearMonth[0] = subCategoryId;
            for (int month = 1; month < 7; month++)
            {
                yearMonth[month] = 
                    halfYear == "first" ? salesYear + string.Format("{0:00}", month)
                    : salesYear + string.Format("{0:00}",(month + 6));
            }

            var master = new SubCategorySalesReport();
            var SalesReport = _reportService
                .RetrieveSubCategorySalesReport(master, yearMonth);
            var ProductReport = _reportService
                .Retrieve<ProductSalesReport>(true, subCategoryId, fromDate, toDate);

            if(ProductReport.Count == 0)
            {
                return NotFound();
            }

            IList<SubCategorySalesReport> SalesReports = new List<SubCategorySalesReport>();
            SalesReports.Add(SalesReport);

            packer.AddModels("SalesReport", SalesReports);
            packer.AddModels("ProductReport", ProductReport);

            return packer;
        }
    }
}