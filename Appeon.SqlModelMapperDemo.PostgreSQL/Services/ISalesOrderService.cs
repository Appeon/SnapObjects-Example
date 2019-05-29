using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.PostgreSQL.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Services
{
    public interface ISalesOrderService
    {
        IList<SalesOrder> Retrieve(bool includeEmbedded, params object[] parameters);
        
        SalesOrder RetrieveByKey(bool includeEmbedded, params object[] parameters);
        
        int SaveSalesOrderHeader(IModelEntry<SalesOrder> header);

        int SaveSalesOrderAndDetail(IModelEntry<SalesOrder> header,  
                                    IEnumerable<IModelEntry<SalesOrderDetail>> details);

    }
}
