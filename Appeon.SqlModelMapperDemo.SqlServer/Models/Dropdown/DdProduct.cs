﻿using SnapObjects.Data;
using System.ComponentModel.DataAnnotations;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    [FromTable("product", Schema = "production")]
    public class DdProduct
    {
        [Key]
        [Identity]
        public int Productid { get; set; }

        [ConcurrencyCheck]
        public string Name { get; set; }
    }
}
