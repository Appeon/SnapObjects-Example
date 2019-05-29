using Appeon.SqlModelMapperDemo.SQLAnywhere.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Services
{
    public interface IAddressService
    {
        IList<Address> Retrieve(bool includeEmbedded, params object[] parameters);

        Address RetrieveByKey(bool includeEmbedded, params object[] parameters);
    }
}
