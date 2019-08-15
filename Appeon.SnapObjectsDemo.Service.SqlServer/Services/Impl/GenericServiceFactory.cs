using Appeon.SnapObjectsDemo.Service.Datacontext;
using System;

namespace Appeon.SnapObjectsDemo.Services
{
    public class GenericServiceFactory : IGenericServiceFactory
    {
        private readonly OrderContext _context;

        public GenericServiceFactory(OrderContext context)
        {
            _context = context;
        }

        public IGenericService<TModel> Get<TModel>()
        {
            Type factoryType = typeof(GenericService<>).MakeGenericType(
                new Type[] 
                {
                    typeof(TModel)
                });

            return (IGenericService<TModel>)Activator.CreateInstance(
                factoryType, new object[] 
                {
                    _context
                });
        }
    }
}
