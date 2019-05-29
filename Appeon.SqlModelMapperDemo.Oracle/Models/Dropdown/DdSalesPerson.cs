using SnapObjects.Data;

namespace Appeon.SqlModelMapperDemo.Oracle.Models
{
    [FromTable(alias: "sp", name: "SalesPerson", Schema = "Sales")]
    [FromTable(alias: "p", name: "Person", Schema = "Person")]
    [SqlWhere("(sp.BusinessEntityID = p.BusinessEntityID)")]
    public class DdSalesPerson
    {
        [SqlColumn(tableAlias: "sp", column: "BusinessEntityID")]
        public int Salesperson_Businessentityid { get; set; }

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
