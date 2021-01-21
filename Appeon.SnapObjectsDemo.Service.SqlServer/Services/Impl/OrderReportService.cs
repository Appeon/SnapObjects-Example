using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;
using SnapObjects.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<CategorySalesReportByYear> RetrieveCategorySalesReportByYearAsync(
            CategorySalesReportByYear master,
            string currentYear,
            string lastYear,
            CancellationToken cancellationToken = default)
        {
            return await _genericService.Get<CategorySalesReportByYear>()
                .RetrieveReportAsync(master, new object[] { currentYear, lastYear }, cancellationToken);
        }

        public async Task<ProductCategorySalesReport> RetrieveProductCategorySalesReportAsync(
            ProductCategorySalesReport master,
            object[] salesmonth,
            CancellationToken cancellationToken = default)
        {
            return await _genericService.Get<ProductCategorySalesReport>()
                .RetrieveReportAsync(master, salesmonth, cancellationToken);
        }

        public async Task<Dictionary<string, int>> RetrieveSalesOrderTotalReportAsync(CancellationToken cancellationToken = default)
        {
            var sql = "select count(1) as totalNum, "
                        + " sum(case when status = 1 then 1 else 0 end) as process,"
                        + " sum(case when status = 2 then 1 else 0 end) as approved,"
                        + " sum(case when status = 3 then 1 else 0 end) as backordered,"
                        + " sum(case when status = 4 then 1 else 0 end) as rejected,"
                        + " sum(case when status = 5 then 1 else 0 end) as shipped,"
                        + " sum(case when status = 6 then 1 else 0 end) as cancelled"
                        + " from sales.SalesOrderHeader";

            //execute sql
            var dynamicModel = await _context.SqlExecutor
                .SelectOneAsync<DynamicModel>(sql, new object[] { }, cancellationToken);

            var result = new Dictionary<string, int>();
            if (dynamicModel != null)
            {
                for (var i = 0; i < dynamicModel.PropertyCount; i++)
                {
                    var key = dynamicModel.Properties[i].Name;
                    result.Add(key, dynamicModel.GetValue<int>(key));
                }
            }
            return result;
        }

    }
}
