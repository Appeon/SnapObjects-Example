namespace Appeon.SqlModelMapperDemo.Oracle.Services
{
    public interface IGenericServiceFactory
    {
        IGenericService<TModel> Get<TModel>();
    }
}
