using Appeon.SnapObjectsDemo.Service.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface ISalesOrderDetailService
    {
        Task<IList<SalesOrderDetail>> RetrieveAsync(
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<SalesOrderDetail> RetrieveByKeyAsync(
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<int> CreateAsync(SalesOrderDetail salesOrderDetail, CancellationToken cancellationToken = default);

        Task<int> UpdateAsync(SalesOrderDetail salesOrderDetail, CancellationToken cancellationToken = default);

    }
}
