using Appeon.SqlModelMapperDemo.PostgreSQL.Models;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Services
{
    public class AddressService : ServiceBase<Address>, IAddressService
    {
        public AddressService(OrderContext context)
            : base(context)
        {
        }
    }
}
