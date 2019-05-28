using SnapObjects.Data;
using System.ComponentModel.DataAnnotations;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Models
{
    [FromTable("Store", Schema = "Sales")]
    public class DdStore
    {
        [Key]
        public int BusinessEntityID { get; set; }

        public string Name { get; set; }

    }
}
