using SnapObjects.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface IGenericService<TModel>
    {
        Task<IList<TModel>> RetrieveAsync(
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<TModel> RetrieveReportAsync(
            TModel master,
            object[] parameters,
            CancellationToken cancellationToken = default);

        Task<IDbResult> DeleteByKeyAsync(object[] parameters, CancellationToken cancellationToken = default);

    }
}
