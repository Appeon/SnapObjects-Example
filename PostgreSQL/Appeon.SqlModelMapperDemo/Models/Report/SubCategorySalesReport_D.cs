using SnapObjects.Data;

namespace Appeon.SqlModelMapperDemo.Models
{
    [SqlParameter("subCategoryId", typeof(int))]
    [SqlParameter("salesMonth", typeof(string))]
    [FromTable("SalesOrderDetail", Schema = "Sales")]
    [JoinTable("SalesOrderHeader", Schema = "Sales",
            OnRaw = "SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID")]
    [JoinTable("Product", Schema = "Production",
            OnRaw = "SalesOrderDetail.ProductID = Product.ProductID")]
    [JoinTable("ProductSubcategory", Schema = "Production",
            OnRaw = "Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID")]
    [SqlWhere("(SalesOrderHeader.Status in(1,2,5)) and " +
              "(ProductSubcategory.ProductSubcategoryID = :subCategoryId) and " +
              "(to_char(SalesOrderHeader.OrderDate, 'yyyymm') =:salesMonth) ")]
    [SqlGroupBy("ProductSubcategory.Name")]

    public class SubCategorySalesReport_D
    {
        [SqlColumn(tableAlias: "ProductSubcategory", column: "Name")]
        public string SubcategoryName { get; set; }

        [SqlCompute("sum(SalesOrderDetail.orderqty)")]
        public long TotalSalesqty { get; set; }

        [SqlCompute("sum(SalesOrderDetail.linetotal)")]
        public decimal TotalSaleroom { get; set; }

    }

}
