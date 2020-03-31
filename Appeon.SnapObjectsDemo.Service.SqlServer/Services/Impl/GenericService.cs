using Appeon.SnapObjectsDemo.Service.Datacontext;
using SnapObjects.Data;

namespace Appeon.SnapObjectsDemo.Services
{
    public class GenericService<TModel> : ServiceBase<TModel>, IGenericService<TModel>
         where TModel : class
    {
        public GenericService(OrderContext context)
            : base(context)
        {
        }

        public TModel RetrieveReport(TModel master, params object[] parameters)
        {
            return _context.SqlModelMapper.LoadEmbedded(master, parameters)
                                          .IncludeAll()
                                          .MasterModel;
        }

        public IDbResult DeleteByKey(params object[] parameters)
        {
            return _context.SqlModelMapper.TrackDeleteByKey<TModel>(parameters)
                                          .SaveChanges();
        }
    }
}
