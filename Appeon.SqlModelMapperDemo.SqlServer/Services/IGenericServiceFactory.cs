namespace Appeon.SqlModelMapperDemo.SqlServer.Services
{
    public interface IGenericServiceFactory
    {
        IGenericService<TModel> Get<TModel>();
    }
}
