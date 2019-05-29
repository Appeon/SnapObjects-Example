namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Services
{
    public interface IGenericServiceFactory
    {
        IGenericService<TModel> Get<TModel>();
    }
}
