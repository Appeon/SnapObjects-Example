using SnapObjects.Data;
using Newtonsoft.Json;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Models
{
    [SqlParameter("subCategoryId", typeof(int))]
    [SqlParameter("orderMonth1", typeof(string))]
    [SqlParameter("orderMonth2", typeof(string))]
    [SqlParameter("orderMonth3", typeof(string))]
    [SqlParameter("orderMonth4", typeof(string))]
    [SqlParameter("orderMonth5", typeof(string))]
    [SqlParameter("orderMonth6", typeof(string))]
    [FromTable("ProductSubcategory", Schema = "Production")]
    [SqlWhere("ProductSubcategoryID = :subCategoryId")]
    public class SubCategorySalesReport
    {
        public string Name => OrderReportMonth1 == null ? null : OrderReportMonth1.SubcategoryName;
        public long SalesqtyMonth1 => OrderReportMonth1 == null ? 0: OrderReportMonth1.TotalSalesqty;
        public decimal SalesRoomMonth1 => OrderReportMonth1 == null ? 0: OrderReportMonth1.TotalSaleroom;
        public long SalesqtyMonth2 => OrderReportMonth2 == null ? 0: OrderReportMonth2.TotalSalesqty;
        public decimal SalesRoomMonth2 => OrderReportMonth2 == null ? 0: OrderReportMonth2.TotalSaleroom;
        public long SalesqtyMonth3 => OrderReportMonth3 == null ? 0: OrderReportMonth3.TotalSalesqty;
        public decimal SalesRoomMonth3 => OrderReportMonth3 == null ? 0 : OrderReportMonth3.TotalSaleroom;
        public long SalesqtyMonth4 => OrderReportMonth4 == null ? 0 : OrderReportMonth4.TotalSalesqty;
        public decimal SalesRoomMonth4 => OrderReportMonth4 ==null ? 0 : OrderReportMonth4.TotalSaleroom;
        public long SalesqtyMonth5 => OrderReportMonth5 == null ? 0 : OrderReportMonth5.TotalSalesqty;
        public decimal SalesRoomMonth5 => OrderReportMonth5 == null ? 0 : OrderReportMonth5.TotalSaleroom;
        public long SalesqtyMonth6 => OrderReportMonth6 == null ? 0 : OrderReportMonth6.TotalSalesqty;
        public decimal SalesRoomMonth6 => OrderReportMonth6 == null ? 0 : OrderReportMonth6.TotalSaleroom;

        [JsonIgnore]
        [ModelEmbedded(typeof(SubCategorySalesReport_D), ParamValue = ":subCategoryId, :orderMonth1")]
        public SubCategorySalesReport_D OrderReportMonth1 { get; set; }

        [ModelEmbedded(typeof(SubCategorySalesReport_D), ParamValue = ":subCategoryId, :orderMonth2")]
        public SubCategorySalesReport_D OrderReportMonth2 { get; set; }

        [ModelEmbedded(typeof(SubCategorySalesReport_D), ParamValue = ":subCategoryId, :orderMonth3")]
        public SubCategorySalesReport_D OrderReportMonth3 { get; set; }

        [ModelEmbedded(typeof(SubCategorySalesReport_D), ParamValue = ":subCategoryId, :orderMonth4")]
        public SubCategorySalesReport_D OrderReportMonth4 { get; set; }

        [ModelEmbedded(typeof(SubCategorySalesReport_D), ParamValue = ":subCategoryId, :orderMonth5")]
        public SubCategorySalesReport_D OrderReportMonth5 { get; set; }

        [ModelEmbedded(typeof(SubCategorySalesReport_D), ParamValue = ":subCategoryId, :orderMonth6")]
        public SubCategorySalesReport_D OrderReportMonth6 { get; set; }
    }
}
