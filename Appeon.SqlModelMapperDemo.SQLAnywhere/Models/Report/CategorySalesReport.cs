using SnapObjects.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Models
{
    [SqlParameter("fromDate", typeof(DateTime))]
    [SqlParameter("toDate", typeof(DateTime))]
    [SqlParameter("lastFromDate", typeof(DateTime))]
    [SqlParameter("lastToDate", typeof(DateTime))]
    [FromTable("ProductCategory", Schema = "Production")]

    public class CategorySalesReport
    {
        public int ProductCategoryID { get; set; }

        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }
        
        [JsonIgnore]
        [ModelEmbedded(typeof(CategorySalesReport_D), ParamValue = ":fromDate, :toDate")]
        public IList<CategorySalesReport_D> SalesReportByCategory { get; set; }

        [ModelEmbedded(typeof(CategorySalesReport_D), ParamValue = ":lastFromDate, :lastToDate")]
        public IList<CategorySalesReport_D> LastYearSalesReportByCategory { get; set; }


    }
}
