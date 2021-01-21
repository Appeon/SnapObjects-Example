using Newtonsoft.Json;
using SnapObjects.Data;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [SqlParameter("orderMonth1", typeof(string))]
    [SqlParameter("orderMonth2", typeof(string))]
    [SqlParameter("orderMonth3", typeof(string))]
    [SqlParameter("orderMonth4", typeof(string))]
    [SqlParameter("orderMonth5", typeof(string))]
    [SqlParameter("orderMonth6", typeof(string))]
    [SqlParameter("orderMonth7", typeof(string))]
    [SqlParameter("orderMonth8", typeof(string))]
    [SqlParameter("orderMonth9", typeof(string))]
    [SqlParameter("orderMonth10", typeof(string))]
    [SqlParameter("orderMonth11", typeof(string))]
    [SqlParameter("orderMonth12", typeof(string))]
    [FromTable("ProductCategory", Schema = "Production")]
    public class ProductCategorySalesReport
    {
        [JsonIgnore]
        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth1")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth1 { get; set; }

        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth2")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth2 { get; set; }

        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth3")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth3 { get; set; }

        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth4")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth4 { get; set; }

        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth5")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth5 { get; set; }

        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth6")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth6 { get; set; }

        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth7")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth7 { get; set; }
        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth8")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth8 { get; set; }
        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth9")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth9 { get; set; }
        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth10")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth10 { get; set; }
        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth11")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth11 { get; set; }
        [ModelEmbedded(typeof(ProductCategorySalesReport_D), ParamValue = ":orderMonth12")]
        public IList<ProductCategorySalesReport_D> OrderReportMonth12 { get; set; }

    }
}
