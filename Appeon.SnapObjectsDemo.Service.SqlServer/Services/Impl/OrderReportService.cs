using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;
using SnapObjects.Data;
using System;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Services
{
    public class OrderReportService : IOrderReportService
    {
        private readonly IGenericServiceFactory _genericService;
        private readonly OrderContext _context;
        public OrderReportService(IGenericServiceFactory genericService, OrderContext context)
        {
            _genericService = genericService;
            _context = context;
        }

        public CategorySalesReportByYear RetrieveCategorySalesReportByYear(
            CategorySalesReportByYear master, string currentYear, string lastYear)
        {
            return _genericService.Get<CategorySalesReportByYear>().RetrieveReport(master, currentYear, lastYear);
        }
		
        public ProductCategorySalesReport RetrieveProductCategorySalesReport(
            ProductCategorySalesReport master,params object[] salesmonth)
        {
            return _genericService.Get<ProductCategorySalesReport>().RetrieveReport(master, salesmonth);
        }

        public Dictionary<string, int> RetrieveSalesOrderTotalReport()
        {
            String sql = "select count(1) as totalNum, "
                        + " sum(case when status = 1 then 1 else 0 end) as process,"
                        + " sum(case when status = 2 then 1 else 0 end) as approved,"
                        + " sum(case when status = 3 then 1 else 0 end) as backordered,"
                        + " sum(case when status = 4 then 1 else 0 end) as rejected,"
                        + " sum(case when status = 5 then 1 else 0 end) as shipped,"
                        + " sum(case when status = 6 then 1 else 0 end) as cancelled"
                        + " from sales.SalesOrderHeader";

            //execute sql
            var dynamicModel = this._context.SqlExecutor.SelectOne<DynamicModel>(sql);

            Dictionary<string, int> result = new Dictionary<string, int>();
            if (dynamicModel != null)
            {
                for (int i = 0; i < dynamicModel.PropertyCount; i++)
                {
                    string key = dynamicModel.Properties[i].Name;
                    result.Add(key, dynamicModel.GetValue<int>(key));
                }
            }
            return result;
        }
    }
}
