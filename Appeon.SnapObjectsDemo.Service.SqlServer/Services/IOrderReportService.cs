using Appeon.SnapObjectsDemo.Service.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface IOrderReportService
    {
        Task<CategorySalesReportByYear> RetrieveCategorySalesReportByYearAsync(
            CategorySalesReportByYear master,
            string currentYear,
            string lastYear,
            CancellationToken cancellationToken = default);

        Task<ProductCategorySalesReport> RetrieveProductCategorySalesReportAsync(
            ProductCategorySalesReport master,
            object[] salesmonth,
            CancellationToken cancellationToken = default);

        Task<Dictionary<string, int>> RetrieveSalesOrderTotalReportAsync(CancellationToken cancellationToken = default);

    }
}
