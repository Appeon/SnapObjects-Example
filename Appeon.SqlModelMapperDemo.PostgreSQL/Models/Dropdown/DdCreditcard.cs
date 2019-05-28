using SnapObjects.Data;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Models
{
    [SqlParameter("customerId", typeof(int))]
    [FromTable(alias: "cc", name: "CreditCard", Schema = "Sales")]
    [FromTable(alias: "pcc", name: "PersonCreditCard", Schema = "Sales")]
    [FromTable(alias: "c", name: "Customer", Schema = "Sales")]
    [SqlWhere(@"( pcc.CreditCardID = cc.CreditCardID ) and
                              (pcc.BusinessEntityID = c.PersonID)")]
    [SqlAndWhere("c.CustomerID = $Param(customerId)")]
    [SqlOrderBy("c.CustomerID")]
    public class DdCreditcard
    {
        [Identity]
        [SqlColumn("CustomerID")]
        public int Customer_Customerid { get; set; }

        [Identity]
        [SqlColumn(tableAlias: "cc", column: "CreditCardID")]
        public int Creditcard_Creditcardid { get; set; }

        [SqlColumn(tableAlias: "cc", column: "CardType")]
        public string Creditcard_CardType { get; set; }

        [SqlColumn(tableAlias: "cc", column: "CardNumber")]
        public string Creditcard_CardNumber { get; set; }

        [SqlColumn("ExpMonth")]
        public int Creditcard_Expmonth { get; set; }

        [SqlColumn("ExpYear")]
        public int Creditcard_Expyear { get; set; }
    }
}
