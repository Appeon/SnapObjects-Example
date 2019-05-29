using SnapObjects.Data;
using System;

namespace Appeon.SqlModelMapperDemo.Oracle.Models
{    
    [SqlParameter("fromDate", typeof(DateTime))]
    [SqlParameter("toDate", typeof(DateTime))]
    [FromTable("SalesOrderDetail", Schema = "Sales")]
    [JoinTable("SalesOrderHeader", Schema = "Sales",
            OnRaw = "SalesOrderDetail.SalesOrderID = SalesOrderHeader.SalesOrderID")]
    [JoinTable("Product", Schema = "Production",
            OnRaw = "SalesOrderDetail.ProductID = Product.ProductID")]
    [JoinTable("ProductSubcategory", Schema = "Production",
            OnRaw = "Product.ProductSubcategoryID = ProductSubcategory.ProductSubcategoryID")]
    [JoinTable("ProductCategory", Schema = "Production",
            OnRaw = "ProductSubcategory.ProductCategoryID = ProductCategory.ProductCategoryID")]
    [SqlWhere("SalesOrderHeader.Status in(1,2,5) and " +
              " (SalesOrderHeader.OrderDate between :fromDate and :toDate)")]
    [SqlGroupBy("ProductCategory.ProductCategoryID, ProductCategory.Name")]
    [SqlOrderBy("ProductCategory.ProductCategoryID")]

    public class CategorySalesReport_D
    {
        [SqlColumn(tableAlias: "ProductCategory", column: "Name")]
        public string ProductCategoryName { get; set; }

        [SqlCompute("sum(SalesOrderDetail.orderqty)")]
        public decimal TotalSalesqty { get; set; }  
        
        [SqlCompute("sum(SalesOrderDetail.linetotal)")]
        public decimal TotalSaleroom { get; set; }        

    }
    
}
