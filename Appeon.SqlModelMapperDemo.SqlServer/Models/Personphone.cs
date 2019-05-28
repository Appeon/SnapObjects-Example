using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    [SqlParameter("entityId",typeof(int))]
    [Table("PersonPhone", Schema = "Person")]
    [SqlWhere("Businessentityid = :entityId")]
    public class Personphone
    {
        [Key]
        [Required]
        public int Businessentityid { get; set; }

        [Key]
        [Required]
        [StringLength(25)]
        public string Phonenumber { get; set; }

        [Key]
        [Required]
        public int? Phonenumbertypeid { get; set; }

        public DateTime Modifieddate { get; set; }

    }
}
