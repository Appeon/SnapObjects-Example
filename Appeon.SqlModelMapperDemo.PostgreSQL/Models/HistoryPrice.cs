using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Models
{
    [SqlParameter("prodid",typeof(int))]
    [Table("productlistpricehistory", Schema = "production")]
    [SqlWhere("productid = :prodid")]
    public class HistoryPrice
    {
        [Key]
        public int Productid { get; set; }

        public DateTime Startdate { get; set; }

        public DateTime? Enddate { get; set; }

        public decimal? Listprice { get; set; }

        [SqlDefaultValue("(getdate())")]
        public DateTime Modifieddate { get; set; }
    }
}
