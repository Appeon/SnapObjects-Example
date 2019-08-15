using Appeon.SnapObjectsDemo.Service.Models;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface ISalesOrderService
    {
        IList<SalesOrder> Retrieve(bool includeEmbedded, params object[] parameters);
        
        SalesOrder RetrieveByKey(bool includeEmbedded, params object[] parameters);

        Page<SalesOrder> LoadByPage(int pageIndex, int pageSize, bool includeEmbedded, params object[] parameters);

        int Create(SalesOrder salesOrder);

        int Update(SalesOrder salesOrder);

        int DeleteByKey(params object[] parameters);
    }
}
