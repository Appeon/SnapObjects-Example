using Appeon.SnapObjectsDemo.Service.Models;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface IOrderReportService
    {

        CategorySalesReportByYear RetrieveCategorySalesReportByYear(
            CategorySalesReportByYear master, string currentYear, string lastYear);


        ProductCategorySalesReport RetrieveProductCategorySalesReport(
            ProductCategorySalesReport master, params object[] salesmonth);


        Dictionary<string, int> RetrieveSalesOrderTotalReport();
    }
}
