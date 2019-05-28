using SnapObjects.Data;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Models
{
    [FromTable("ProductCategory", Schema = "production")]
    [SqlOrderBy("Productcategoryid ASC")]
    public class Category
    {
        [Key]
        [Identity]
        public int Productcategoryid { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }

        [JsonIgnore]
        [SetValue("$Productcategoryid", "$Productcategoryid",SetValueStrategy.Always)]
        [ModelEmbedded(typeof(SubCategory),ParamValue = "$Productcategoryid",
            CascadeCreate = true,CascadeDelete = true)]
        public IList<SubCategory> Subcates { get; set; }

    }
}
