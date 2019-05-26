namespace Appeon.SqlModelMapperDemo.Services
{
    public interface IGenericServiceFactory
    {
        IGenericService<TModel> Get<TModel>();
    }
}
