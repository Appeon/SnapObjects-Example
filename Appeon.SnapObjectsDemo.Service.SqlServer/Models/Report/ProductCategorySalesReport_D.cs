using SnapObjects.Data;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [SqlParameter("salesMonth", typeof(string))]
    [FromTable("SalesOrderDetail", Schema = "Sales")]
    [JoinTable("SalesOrderHeader", Schema = "Sales",
            OnRaw = "SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID")]
    [JoinTable("Product", Schema = "Production",
            OnRaw = "SalesOrderDetail.ProductID = Product.ProductID")]
    [JoinTable("ProductSubcategory", Schema = "Production",
            OnRaw = "Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID")]
    [JoinTable("ProductCategory", Schema = "Production",
            OnRaw = "ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID")]
    [SqlWhere("(SalesOrderHeader.Status in(1,2,5)) and " +
              "(left(convert(varchar(8), SalesOrderHeader.OrderDate, 112), 6) =:salesMonth ) ")]
    [SqlGroupBy("ProductCategory.ProductCategoryID, ProductCategory.Name")]
    [SqlOrderBy("ProductCategory.ProductCategoryID, ProductCategory.Name")]
    public class ProductCategorySalesReport_D
    {
        [SqlColumn(tableAlias: "ProductCategory", column: "Name")]
        public string ProductCategoryName { get; set; }

        [SqlCompute("sum(SalesOrderDetail.orderqty)", "TotalSalesqty")]
        public int TotalSalesqty { get; set; }

        [SqlCompute("sum(SalesOrderDetail.linetotal)", "TotalSaleroom")]
        public decimal TotalSaleroom { get; set; }

    }

}
