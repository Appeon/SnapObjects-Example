using SnapObjects.Data;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.PostgreSQL.Services
{
    public interface IGenericService<TModel>
    {
        IList<TModel> Retrieve(bool includeEmbedded, params object[] parameters);

        TModel RetrieveByKey(bool includeEmbedded, params object[] parameters);

        TModel RetrieveReport(TModel master, params object[] parameters);

        IDbResult Delete(IModelEntry<TModel> models);

        IDbResult DeleteByKey(params object[] parameters);

        IDbResult SaveChanges(IEnumerable<IModelEntry<TModel>> models);

    }
}
