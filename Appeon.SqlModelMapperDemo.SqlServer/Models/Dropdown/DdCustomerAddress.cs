using SnapObjects.Data;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    [SqlParameter("customerId", typeof(int))]
    [FromTable(alias: "bea", name: "BusinessEntityAddress", Schema = "Person")]
    [FromTable(alias: "a", name: "Address", Schema = "Person")]
    [FromTable(alias: "at", name: "AddressType", Schema = "Person")]
    [FromTable(alias: "c", name: "Customer", Schema = "Sales")]
    [FromTable(alias: "sp", name: "StateProvince", Schema = "Person")]
    [SqlWhere("a.AddressID = bea.AddressID")]
    [SqlAndWhere("at.AddressTypeID = bea.AddressTypeID")]
    [SqlAndWhere("c.TerritoryID = sp.TerritoryID")]
    [SqlAndWhere("(bea.BusinessEntityID = c.PersonID or bea.BusinessEntityID = c.StoreID)")]
    [SqlAndWhere("a.StateProvinceID = sp.StateProvinceID")]
    [SqlAndWhere("c.CustomerID = $Param(customerId)")]
    public class DdCustomerAddress
    {
        [SqlColumn("BusinessEntityID")]
        public int Businessentityaddress_Businessentityid { get; set; }

        [SqlColumn(tableAlias: "bea", column: "AddressID")]
        public int Businessentityaddress_Addressid { get; set; }

        [SqlColumn(tableAlias: "bea", column: "AddressTypeID")]
        public int Businessentityaddress_Addresstypeid { get; set; }

        [SqlColumn("AddressLine1")]
        public string Address_Addressline1 { get; set; }

        [SqlColumn("AddressLine2")]
        public string Address_Addressline2 { get; set; }

        [SqlColumn("City")]
        public string Address_City { get; set; }

        [SqlColumn(tableAlias: "a", column: "StateProvinceID")]
        public int Address_Stateprovinceid { get; set; }

        [SqlColumn("PostalCode")]
        public string Address_Postalcode { get; set; }

        [SqlColumn(tableAlias: "at", column: "Name")]
        public string Addresstype_Name { get; set; }

        [SqlColumn("CustomerID")]
        public int Customer_Customerid { get; set; }

        [SqlColumn("StateProvinceCode")]
        public string Stateprovince_Stateprovincecode { get; set; }

        [SqlColumn("CountryRegionCode")]
        public string Stateprovince_Countryregioncode { get; set; }

        [SqlColumn(tableAlias: "sp", column: "Name")]
        public string Stateprovince_Name { get; set; }
    }
}
