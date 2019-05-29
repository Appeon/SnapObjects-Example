using Appeon.SqlModelMapperDemo.PostgreSQL.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Services
{
    public interface IAddressService
    {
        IList<Address> Retrieve(bool includeEmbedded, params object[] parameters);

        Address RetrieveByKey(bool includeEmbedded, params object[] parameters);
    }
}
