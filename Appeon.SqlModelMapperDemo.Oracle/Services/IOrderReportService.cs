using Appeon.SqlModelMapperDemo.Oracle.Models;
using System;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.Oracle.Services
{
    public interface IOrderReportService
    {
        IList<TModel> Retrieve<TModel>(bool includeEmbedded, params object[] parameters);

        CategorySalesReport RetrieveCategorySalesReport(CategorySalesReport master, 
                            DateTime dateFrom, DateTime dateTo, DateTime lastDateFrom, DateTime lastDateTo);

        SubCategorySalesReport RetrieveSubCategorySalesReport(SubCategorySalesReport master,
                                                              params object[] salesmonth);        
    }
}
