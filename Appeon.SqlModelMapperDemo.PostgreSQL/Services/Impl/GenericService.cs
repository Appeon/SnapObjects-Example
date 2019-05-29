using SnapObjects.Data;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Services
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
            _context.SqlModelMapper.LoadEmbedded(master, parameters).IncludeAll();

            return master;
        }

        public IDbResult Delete(IModelEntry<TModel> models)
        {
            return _context.SqlModelMapper.TrackMaster(models)
                                       .SaveChanges();  
        }

        public IDbResult DeleteByKey(params object[] parameters)
        {
            return _context.SqlModelMapper.TrackDeleteByKey<TModel>(parameters)
                                       .SaveChanges();
        }

        public IDbResult SaveChanges(IEnumerable<IModelEntry<TModel>> models)
        {
            var mapper = _context.SqlModelMapper;
            mapper.TrackRange(models);
            
            return mapper.SaveChanges();

        }

    }
}
