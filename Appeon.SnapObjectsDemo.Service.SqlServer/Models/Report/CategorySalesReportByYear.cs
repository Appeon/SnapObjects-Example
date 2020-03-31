using SnapObjects.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [SqlParameter("curYear", typeof(String))]
    [SqlParameter("lastYear", typeof(String))]
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

        public String Json_Categorys { get; set; }

        public String Json_categorysData { get; set; }

        public String Json_totalData { get; set; }

        public String Json_ProductSaleMonth { get; set; }

        public String Json_ProductCategory { get; set; }

        public String Json_ProductSaleSqty { get; set; }

    }
}
