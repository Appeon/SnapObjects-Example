using SnapObjects.Data;
using System.ComponentModel;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [SqlParameter("customerId", typeof(int))]
    [FromTable(alias: "cc", name: "CreditCard", Schema = "Sales")]
    [FromTable(alias: "pcc", name: "PersonCreditCard", Schema = "Sales")]
    [FromTable(alias: "c", name: "Customer", Schema = "Sales")]
    [SqlWhere(@"( pcc.CreditCardID = cc.CreditCardID ) and
                              (pcc.BusinessEntityID = c.PersonID)")]
    [SqlAndWhere("c.CustomerID = :customerId")]
    [SqlOrderBy("c.CustomerID")]
    public class DdCreditcard
    {
        [Identity]
        [SqlColumn("CustomerID")]
        public int Customer_Customerid { get; set; }

        [Identity]
        [SqlColumn(tableAlias: "cc", column: "CreditCardID")]
        [DisplayName("Creditcard ID")]
        public int Creditcard_Creditcardid { get; set; }

        [SqlColumn(tableAlias: "cc", column: "CardType")]
        public string Creditcard_CardType { get; set; }

        [SqlColumn(tableAlias: "cc", column: "CardNumber")]
        [DisplayName("Card Number")]
        public string Creditcard_CardNumber { get; set; }

        [SqlColumn("ExpMonth")]
        public byte Creditcard_Expmonth { get; set; }

        [SqlColumn("ExpYear")]
        public int Creditcard_Expyear { get; set; }
    }
}
