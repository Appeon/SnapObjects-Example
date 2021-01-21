using Newtonsoft.Json;
using SnapObjects.Data;
using System;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [SqlParameter("curYear", typeof(string))]
    [SqlParameter("lastYear", typeof(string))]
    [FromTable("ProductCategory", Schema = "Production")]
    public class CategorySalesReportByYear
    {
        public int ProductCategoryID { get; set; }

        public string Name { get; set; }

        public DateTime ModifiedDate { get; set; }

        [JsonIgnore]
        [ModelEmbedded(typeof(CategorySalesReportByYear_D), ParamValue = ":curYear")]
        public IList<CategorySalesReportByYear_D> SalesReportByCategory { get; set; }

        [ModelEmbedded(typeof(CategorySalesReportByYear_D), ParamValue = ":lastYear")]
        public IList<CategorySalesReportByYear_D> LastYearSalesReportByCategory { get; set; }

        public string Json_Categorys { get; set; }

        public string Json_categorysData { get; set; }

        public string Json_totalData { get; set; }

        public string Json_ProductSaleMonth { get; set; }

        public string Json_ProductCategory { get; set; }

        public string Json_ProductSaleSqty { get; set; }

    }
}
