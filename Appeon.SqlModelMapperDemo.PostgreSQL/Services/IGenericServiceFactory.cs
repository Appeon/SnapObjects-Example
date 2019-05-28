namespace Appeon.SqlModelMapperDemo.PostgreSQL.Services
{
    public interface IGenericServiceFactory
    {
        IGenericService<TModel> Get<TModel>();
    }
}
