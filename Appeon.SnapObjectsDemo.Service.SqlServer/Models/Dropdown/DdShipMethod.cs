using SnapObjects.Data;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    [FromTable("ShipMethod", Schema = "Purchasing")]
    public class DdShipMethod
    {
        [Key]
        [Identity]
        [DisplayName("Ship Method ID")]
        public int Shipmethodid { get; set; }

        public string Name { get; set; }

        public decimal Shipbase { get; set; }

        public decimal Shiprate { get; set; }
    }
}
