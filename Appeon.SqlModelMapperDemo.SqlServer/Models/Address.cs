using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    [SqlParameter("stateId",typeof(int))]
    [SqlParameter("city",typeof(string))]
    [Table("Address", Schema = "Person")]
    [SqlWhere("(StateProvinceID = :stateId OR :stateId = 0) " +
              " And (City like '%' + :city + '%')")]
    public class Address
    {
        [Key]
        [Identity]
        public int AddressID { get; set; }

        [Required]
        [MaxLength(60)]
        public String AddressLine1 { get; set; }

        [MaxLength(60)]
        public String AddressLine2 { get; set; }

        [Required]
        [MaxLength(30)]
        public String City { get; set; }

        [Required]
        public int StateProvinceID { get; set; }

        [Required]
        [MaxLength(60)]
        public String PostalCode { get; set; }

        [SqlDefaultValue("(getdate())")]
        public DateTime ModifiedDate { get; set; }

    }
}
