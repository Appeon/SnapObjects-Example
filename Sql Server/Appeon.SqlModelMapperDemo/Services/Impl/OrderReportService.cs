using Appeon.SqlModelMapperDemo.Models;
using System;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.Services
{
    public class OrderReportService : IOrderReportService
    {
        private readonly IGenericServiceFactory _genericService;
        public OrderReportService(IGenericServiceFactory genericService)
        {
            _genericService = genericService;
        }

        public IList<TModel> Retrieve<TModel>(bool includeEmbedded,
            params object[] parameters)
        {
            return _genericService.Get<TModel>()
                .Retrieve(includeEmbedded, parameters);
        }

        public CategorySalesReport RetrieveCategorySalesReport(CategorySalesReport master, 
                                                DateTime dateFrom, DateTime dateTo, 
                                                DateTime lastDateFrom, DateTime lastDateTo)
        {
            return _genericService.Get<CategorySalesReport>().RetrieveReport(master,
                                                              dateFrom, dateTo,
                                                              lastDateFrom, lastDateTo);
        }

        public SubCategorySalesReport RetrieveSubCategorySalesReport(SubCategorySalesReport master, 
                                                                     params object[] salesmonth)
        {
            return _genericService.Get<SubCategorySalesReport>().RetrieveReport(master, salesmonth);
        }
    }
    
}
