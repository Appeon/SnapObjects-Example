using Appeon.SqlModelMapperDemo.SqlServer.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.SqlServer.Services
{
    public interface IAddressService
    {
        IList<Address> Retrieve(bool includeEmbedded, params object[] parameters);

        Address RetrieveByKey(bool includeEmbedded, params object[] parameters);
    }
}
