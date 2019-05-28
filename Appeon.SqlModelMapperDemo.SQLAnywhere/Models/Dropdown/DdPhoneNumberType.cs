using SnapObjects.Data;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Models
{
    [FromTable("PhoneNumberType", Schema = "Person")]
    public class DdPhoneNumberType
    {
        public int Phonenumbertypeid { get; set; }

        public string Name { get; set; }
    }
}
