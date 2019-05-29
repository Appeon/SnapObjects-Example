using Appeon.SqlModelMapperDemo.SqlServer.Models;

namespace Appeon.SqlModelMapperDemo.SqlServer.Services
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        public AddressService(OrderContext context)
            : base(context)
        {
        }
    }
}
