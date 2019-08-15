using System.Collections.Generic;
using Appeon.SnapObjectsDemo.Service.Models;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface ISalesOrderDetailService
    {
        IList<SalesOrderDetail> Retrieve(bool includeEmbedded, params object[] parameters);

        SalesOrderDetail RetrieveByKey(bool includeEmbedded, params object[] parameters);

        int Create(SalesOrderDetail salesOrderDetail);

        int Update(SalesOrderDetail salesOrderDetail);

    }
}
