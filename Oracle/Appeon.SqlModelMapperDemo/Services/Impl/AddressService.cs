using Appeon.SqlModelMapperDemo.Models;

namespace Appeon.SqlModelMapperDemo.Services
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        public AddressService(OrderContext context)
            : base(context)
        {
        }
    }
}
