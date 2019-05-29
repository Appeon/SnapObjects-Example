using SnapObjects.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    [Top(1000)]
    [SqlParameter("custId", typeof(int))]
    [SqlParameter("stratOrderDate", typeof(DateTime))]
    [SqlParameter("endOrderDate", typeof(DateTime))]
    [Table("SalesOrderHeader",Schema = "Sales")]
    [SqlWhere("(CustomerId = :custId Or :custId = 0) " +
        " and (Orderdate Between :stratOrderDate and :endOrderDate)")]
    public class SalesOrder
    {
        [Key]
        [Identity]        
        public int SalesOrderID { get; set; }

        [Required]
        public byte RevisionNumber { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        [Required]
        public DateTime? DueDate { get; set; }

        public DateTime? ShipDate { get; set; }

        [Required]
        public byte? Status { get; set; }

        [Required]
        public bool? OnlineOrderFlag { get; set; }

        [SqlCompute("(isnull(N'SO'+CONVERT([nvarchar](23),[SalesOrderID]),N'*** ERROR ***'))")]
        public string SalesOrderNumber { get; set; }

        public string PurchaseOrderNumber { get; set; }

        public string AccountNumber { get; set; }

        [Required]
        public int? CustomerID { get; set; }

        public int? SalesPersonID { get; set; }

        public int? TerritoryID { get; set; }

        [Required]
        public int? BillToAddressID { get; set; }

        [Required]
        public int? ShipToAddressID { get; set; }

        [Required]
        public int? ShipMethodID { get; set; }

        public int? CreditCardID { get; set; }

        public string CreditCardApprovalCode { get; set; }

        public int? CurrencyRateID { get; set; }

        [Required]
        public decimal? SubTotal { get; set; }

        [Required]
        public decimal? TaxAmt { get; set; }

        [Required]
        public decimal? Freight { get; set; }

        [SqlCompute("(isnull(([SubTotal]+[TaxAmt])+[Freight],(0)))")]
        public decimal? TotalDue { get; set; }

        public string Comment { get; set; }
        
        public DateTime? ModifiedDate { get; set; }

        [JsonIgnore]
        [SetValue("$SalesOrderID", "$SalesOrderID", SetValueStrategy.Always)]
        [ModelEmbedded(typeof(SalesOrderDetail), ParamValue = "$SalesOrderID",
            CascadeCreate =true, CascadeDelete = true)]
        public IList<SalesOrderDetail> OrderDetails { get; set; }
    }
}
