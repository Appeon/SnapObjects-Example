using Appeon.SnapObjectsDemo.Service.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface ISalesOrderService
    {
        Task<IList<SalesOrder>> RetrieveAsync(
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<SalesOrder> RetrieveByKeyAsync(
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<Page<SalesOrder>> LoadByPageAsync(
            int pageIndex,
            int pageSize,
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<int> CreateAsync(SalesOrder salesOrder, CancellationToken cancellationToken = default);

        Task<int> UpdateAsync(SalesOrder salesOrder, CancellationToken cancellationToken = default);

        Task<int> DeleteByKeyAsync(object[] parameters, CancellationToken cancellationToken = default);

    }
}
