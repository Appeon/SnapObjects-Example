using SnapObjects.Data;
using System;

namespace Appeon.SqlModelMapperDemo.Models
{
    [Top(5)]
    [SqlParameter("subCategoryId", typeof(int))]
    [SqlParameter("dateFrom", typeof(DateTime))]
    [SqlParameter("dateTo", typeof(DateTime))]
    [FromTable("SalesOrderDetail", Schema = "Sales")]
    [JoinTable("SalesOrderHeader", Schema = "Sales",
            OnRaw = "SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID")]
    [JoinTable("Product", Schema = "Production",
            OnRaw = "SalesOrderDetail.ProductID = Product.ProductID")]
    [JoinTable("ProductSubcategory", Schema = "Production",
            OnRaw = "Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID")]
    [SqlWhere("(SalesOrderHeader.Status in(1,2,5)) and " +
              "(ProductSubcategory.ProductSubcategoryID = :subCategoryId) and " +
              "(SalesOrderHeader.OrderDate between :dateFrom and :dateTo) ")]
    [SqlGroupBy("Product.ProductID, Product.Name")]
    [SqlOrderBy("sum(SalesOrderDetail.linetotal) desc")]

    public class ProductSalesReport
    {
        [SqlColumn(tableAlias: "Product", column: "Name")]
        public string ProductName { get; set; }

        [SqlCompute("sum(SalesOrderDetail.orderqty)")]
        public long TotalSalesqty { get; set; }

        [SqlCompute("sum(SalesOrderDetail.linetotal)")]
        public decimal TotalSaleroom { get; set; }

    }

}