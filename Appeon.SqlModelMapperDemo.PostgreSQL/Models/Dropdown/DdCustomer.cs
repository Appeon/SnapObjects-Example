using SnapObjects.Data;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Models
{
    [Top(100)]
    [FromTable(alias: "c", name: "Customer", Schema = "Sales")]
    [FromTable(alias: "st", name: "SalesTerritory", Schema = "Sales")]
    [FromTable(alias: "p", name: "Person", Schema = "Person")]
    [SqlWhere(@"( st.TerritoryID = c.TerritoryID ) AND
                (c.PersonID is not null) AND
                (c.PersonID = p.BusinessEntityID)")]
    [SqlOrderBy("c.CustomerID")]
    public class DdCustomer
    {
        [Identity]
        [SqlColumn("CustomerID")]
        public int Customer_Customerid { get; set; }

        [SqlColumn("PersonID")]
        public int? Customer_Personid { get; set; }

        [SqlColumn(tableAlias: "c", column: "TerritoryID")]
        public int? Customer_Territoryid { get; set; }

        [SqlColumn("AccountNumber")]
        public string Customer_Accountnumber { get; set; }

        [SqlColumn("Name")]
        public string Salesterritory_Name { get; set; }

        [SqlColumn("Title")]
        public string Person_Title { get; set; }

        [SqlColumn("FirstName")]
        public string Person_Firstname { get; set; }

        [SqlColumn("MiddleName")]
        public string Person_Middlename { get; set; }

        [SqlColumn("LastName")]
        public string Person_Lastname { get; set; }

        [SqlColumn("Suffix")]
        public string Person_Suffix { get; set; }
    }
}
