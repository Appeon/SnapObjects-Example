using SnapObjects.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.Models
{
    [SqlParameter("cateId",typeof(int))]
    [Table("Productsubcategory",Schema = "Production")]
    [SqlWhere("Productcategoryid = :cateId or :cateId = 0")]
    [SqlOrderBy("Productsubcategoryid")]
    public class SubCategory
    {
        [Key]
        [Identity]
        public int Productsubcategoryid { get; set; }

        [Required]
        public int Productcategoryid { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime Modifieddate { get; set; }
        
        [JsonIgnore]
        [SetValue("$Productsubcategoryid", "$Productsubcategoryid", SetValueStrategy.Always)]
        [ModelEmbedded(typeof(Product), ParamValue = "$Productsubcategoryid",
            CascadeCreate = true, CascadeDelete =false)]
        public Product Products { get; set; }
        
        [JsonIgnore]
        [SetValue("$Productsubcategoryid", "$Productsubcategoryid", SetValueStrategy.Always)]
        [ModelEmbedded(typeof(Product), ParamValue = "$Productsubcategoryid", 
            CascadeCreate = false, CascadeDelete = true)]
        public IList<Product> lProducts { get; set; }
    }

}
