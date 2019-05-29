using Appeon.SqlModelMapperDemo.SQLAnywhere.Models;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Services
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        public AddressService(OrderContext context)
            : base(context)
        {
        }
    }
}
