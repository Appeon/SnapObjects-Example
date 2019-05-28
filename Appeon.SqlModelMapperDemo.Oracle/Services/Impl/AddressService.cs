using Appeon.SqlModelMapperDemo.Oracle.Models;

namespace Appeon.SqlModelMapperDemo.Oracle.Services
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        public AddressService(OrderContext context)
            : base(context)
        {
        }
    }
}
