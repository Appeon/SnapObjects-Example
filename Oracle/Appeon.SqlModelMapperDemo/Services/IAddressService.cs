using Appeon.SqlModelMapperDemo.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.Services
{
    public interface IAddressService
    {
        IList<Address> Retrieve(bool includeEmbedded, params object[] parameters);

        Address RetrieveByKey(bool includeEmbedded, params object[] parameters);
    }
}
