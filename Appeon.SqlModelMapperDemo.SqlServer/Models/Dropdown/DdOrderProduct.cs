using SnapObjects.Data;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    [FromTable(alias: "p", name: "Product", Schema = "Production")]
    [FromTable(alias: "pc", name: "ProductCategory", Schema = "Production")]
    [FromTable(alias: "pm", name: "ProductModel", Schema = "Production")]
    [FromTable(alias: "ps", name: "ProductSubcategory", Schema = "Production")]
    [SqlWhere(@"(pm.ProductModelID = p.ProductModelID ) AND
                            (ps.ProductCategoryID =pc.ProductCategoryID) AND
                            (ps.ProductSubcategoryID = p.ProductSubcategoryID) AND
                            (p.FinishedGoodsFlag = 1 AND
                            (p.ProductID in (SELECT Sales.SpecialOfferProduct.ProductID
                                             FROM Sales.SpecialOfferProduct)) )   ")]
    [SqlOrderBy("p.ProductID")]

    public class DdOrderProduct
    {
        [SqlColumn(tableAlias: "p", column: "Name")]
        public string Product_Name { get; set; }

        [SqlColumn("ProductNumber")]
        public string Product_Productnumber { get; set; }

        [SqlColumn("Color")]
        public string Product_Color { get; set; }

        [SqlColumn("ListPrice")]
        public decimal Product_Listprice { get; set; }

        [SqlColumn("Size")]
        public string Product_Size { get; set; }

        [SqlColumn(tableAlias: "p", column: "ProductSubcategoryID")]
        public int? Product_Productsubcategoryid { get; set; }

        [SqlColumn(tableAlias: "p", column: "ProductModelID")]
        public int? Product_Productmodelid { get; set; }

        [SqlColumn(tableAlias: "pc", column: "Name")]
        public string Productcategory_Name { get; set; }

        [SqlColumn(tableAlias: "ps", column: "ProductCategoryID")]
        public int Productsubcategory_Productcategoryid { get; set; }

        [SqlColumn(tableAlias: "ps", column: "Name")]
        public string Productsubcategory_Name { get; set; }

        [SqlColumn(tableAlias: "pm", column: "Name")]
        public string Productmodel_Name { get; set; }

        [SqlColumn(tableAlias: "p", column: "ProductID")]
        public int Product_Productid { get; set; }
    }
}
