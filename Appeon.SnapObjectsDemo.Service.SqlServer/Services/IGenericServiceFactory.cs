
namespace Appeon.SnapObjectsDemo.Services
{
    public interface IGenericServiceFactory
    {
        IGenericService<TModel> Get<TModel>();

    }
}
