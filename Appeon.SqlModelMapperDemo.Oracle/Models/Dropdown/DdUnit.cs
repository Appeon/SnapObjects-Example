using SnapObjects.Data;
using System.ComponentModel.DataAnnotations;

namespace Appeon.SqlModelMapperDemo.Oracle.Models
{
    [FromTable("unitmeasure", Schema = "production")]
    public class DdUnit
    {
        public string Unitmeasurecode { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }
    }
}
