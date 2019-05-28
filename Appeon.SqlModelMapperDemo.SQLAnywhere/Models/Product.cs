using SnapObjects.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Models
{
    [SqlParameter("subCateId",typeof(int))]
    [Table("Product",Schema = "production")]
    [SqlWhere("Productsubcategoryid = :subCateId")]
    [SqlOrderBy("Productid ASC")]
    public class Product
    {
        [Key]
        [Identity]
        [PropertySave(SaveStrategy.ReadAfterSave)]
        public int Productid { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Productnumber { get; set; }

        [Required]
        public bool Makeflag { get; set; }

        [StringLength(15)]
        public string Color { get; set; }

        [Required]
        public int Safetystocklevel { get; set; }

        public int Reorderpoint { get; set; }

        public decimal Standardcost { get; set; }

        public decimal Listprice { get; set; }

        [StringLength(5)]
        public string Size { get; set; }

        [StringLength(3)]
        public string Sizeunitmeasurecode { get; set; }

        [StringLength(3)]
        public string Weightunitmeasurecode { get; set; }

        public decimal? Weight { get; set; }

        public int Daystomanufacture { get; set; }

        public string Productline { get; set; }

        public string Class { get; set; }

        public string Style { get; set; }

        [Required]
        public int? Productsubcategoryid { get; set; }

        public int? Productmodelid { get; set; }

        public DateTime Sellstartdate { get; set; }

        public DateTime? Sellenddate { get; set; }

        public DateTime Modifieddate { get; set; }

        public bool Finishedgoodsflag { get; set; }

        [JsonIgnore]
        [SetValue("$Productid", "$Productid",SetValueStrategy.Always)]
        [ModelEmbedded(typeof(HistoryPrice),ParamValue = "$Productid", 
            CascadeCreate =true,CascadeDelete =true)]
        public IList<HistoryPrice> HistoryPrices { get; set; }

        [SetValue("$Productid", "$Productid", SetValueStrategy.Always)]
        [ModelEmbedded(typeof(ProductProductPhoto),
            ParamValue = "$Productid",CascadeDelete = true)]
        public IList<ProductProductPhoto> Photos { get; set; }
    }
}
