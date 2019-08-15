using SnapObjects.Data;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Services
{
    public interface IGenericService<TModel>
    {
        IList<TModel> Retrieve(bool includeEmbedded, params object[] parameters);

        TModel RetrieveReport(TModel master, params object[] parameters);

        IDbResult DeleteByKey(params object[] parameters);
    }
}
