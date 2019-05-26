using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.Models
{
    [SqlParameter("persId", typeof(int))]
    [Table("Customer", Schema = "Sales")]
    [SqlWhere("Personid = :persId")]
    public class Customer
    {
        [Key]
        [Identity]
        public int Customerid { get; set; }

        public int? Personid { get; set; }

        public int? Storeid { get; set; }

        public int? Territoryid { get; set; }

        public string Accountnumber { get; set; }

        public DateTime Modifieddate { get; set; }
    }
}
