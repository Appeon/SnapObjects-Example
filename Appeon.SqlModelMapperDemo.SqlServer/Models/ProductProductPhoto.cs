using SnapObjects.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace Appeon.SqlModelMapperDemo.SqlServer.Models
{
    [SqlParameter("photoid",typeof(int))]
    [FromTable("ProductProductPhoto",Schema = "Production")]
    [SqlWhere("ProductID=:photoid")]
    public class ProductProductPhoto
    {
        [Key]
        public int ProductID { get; set; }

        public int ProductPhotoID { get; set; }

        public byte? Primary { get; set; }

        [SqlDefaultValue("(getdate())")]
        public DateTime ModifiedDate { get; set; }


    }
}
