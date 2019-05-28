using Newtonsoft.Json;
using SnapObjects.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    //[Top(2000)]
    [Table("Person", Schema = "Person")]
    [SqlWhere("Persontype = 'IN'")]
    public class Person
    {
        [Key]
        [Required]
        public int Businessentityid { get; set; }

        [Required]
        [StringLength(2)]
        public String Persontype { get; set; }

        [Required]
        public Boolean Namestyle { get; set; }

        public String Title { get; set; }

        [Required]
        [StringLength(50)]
        public String Firstname { get; set; }

        public String Middlename { get; set; }

        [Required]
        [StringLength(50)]
        public String Lastname { get; set; }

        public String Suffix { get; set; }

        [Required]
        public Int32 Emailpromotion { get; set; }

        [SqlDefaultValue("(getdate())")]
        public DateTime Modifieddate { get; set; }

        [JsonIgnore]
        [SetValue("$Businessentityid", "$Businessentityid", SetValueStrategy.Always)]
        [ModelEmbedded(typeof(BusinessentityAddress),
            ParamValue = "$Businessentityid",CascadeCreate =true,CascadeDelete =true)]
        public IList<BusinessentityAddress> businessAddress { get; set; }

        [SetValue("$Businessentityid", "$Businessentityid", SetValueStrategy.Always)]
        [ModelEmbedded(typeof(Personphone), ParamValue = "$Businessentityid",
            CascadeCreate = true, CascadeDelete = true)]
        public IList<Personphone> Personphones { get; set; }

        [SetValue("$Businessentityid", "$Personid", SetValueStrategy.Always)]
        [ModelEmbedded(typeof(Customer), ParamValue = "$Businessentityid", 
            CascadeCreate = true, CascadeDelete = true)]
        public IList<Customer> Customers { get; set; }

    }
}
