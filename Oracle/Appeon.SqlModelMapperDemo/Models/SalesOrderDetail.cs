using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.Models
{
    [SqlParameter("saleId",typeof(int))]
    [Table("SalesOrderDetail", Schema = "Sales")]
    [SqlWhere("Salesorderid=:saleId")]
    public class SalesOrderDetail
    {
        [Key]
        public int SalesOrderID { get; set; }

        [Key]
        [Identity]
        public int SalesOrderDetailID { get; set; }

        public string CarrierTrackingNumber { get; set; }

        public int OrderQty { get; set; }

        [Required]
        public int ProductID { get; set; }

        [Required]
        public int SpecialOfferID { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public decimal UnitPriceDiscount { get; set; }

        [Identity]
        public decimal LineTotal { get; set; }       

        public DateTime ModifiedDate { get; set; }
    }
}
