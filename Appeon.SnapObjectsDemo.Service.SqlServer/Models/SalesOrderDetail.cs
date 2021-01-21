using SnapObjects.Data;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [SqlParameter("saleId", typeof(int))]
    [Table("SalesOrderDetail", Schema = "Sales")]
    [SqlWhere("Salesorderid=:saleId")]
    public class SalesOrderDetail
    {
        public int SalesOrderID { get; set; }

        [Key]
        [Identity]
        [DisplayName("ID")]
        public int SalesOrderDetailID { get; set; }

        [DisplayName("Carrier Tracking Number")]
        public string CarrierTrackingNumber { get; set; }

        [DisplayName("Order Qty")]
        public int OrderQty { get; set; }

        [Required]
        [DisplayName("Product")]
        public int ProductID { get; set; }

        [Required]
        [DisplayName("Special Offer ID")]
        public int SpecialOfferID { get; set; }

        [Required]
        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }

        //[Required]
        [DisplayName("Unit Price Discount")]
        [DataType(DataType.Currency)]
        [Range(0, 1)]
        public decimal? UnitPriceDiscount { get; set; }

        //[Identity]
        [DisplayName("Line Total")]
        [DataType(DataType.Currency)]
        [PropertySave(SaveStrategy.ReadAfterSave)]
        public decimal? LineTotal { get; set; }

        [DisplayName("Modified Date")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ModifiedDate { get; set; }

    }
}
