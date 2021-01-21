using Appeon.SnapObjectsDemo.Service.Datacontext;
using SnapObjects.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Services
{
    public class GenericService<TModel> : ServiceBase<TModel>, IGenericService<TModel>
         where TModel : class
    {
        public GenericService(OrderContext context)
            : base(context)
        { }

        public async Task<TModel> RetrieveReportAsync(TModel master, object[] parameters, CancellationToken cancellationToken = default)
        {
            return (await _context.SqlModelMapper.LoadEmbedded(master, parameters)
                                                 .IncludeAllAsync(cancellationToken: cancellationToken))
                                                 .MasterModel;
        }

        public async Task<IDbResult> DeleteByKeyAsync(object[] parameters, CancellationToken cancellationToken = default)
        {
            return await _context.SqlModelMapper.TrackDeleteByKey<TModel>(parameters)
                                          .SaveChangesAsync(cancellationToken);
        }
    }
}
