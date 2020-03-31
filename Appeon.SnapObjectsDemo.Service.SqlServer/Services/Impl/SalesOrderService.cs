
using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;

namespace Appeon.SnapObjectsDemo.Services
{
    public class SalesOrderService : ServiceBase<SalesOrder>, ISalesOrderService
    {
        public SalesOrderService(OrderContext context)
            :base(context)
        {
        }

        public int Create(SalesOrder salesOrder)
        {
            return _context.SqlModelMapper.TrackCreate<SalesOrder>(salesOrder)
                                          .SaveChanges()
                                          .InsertedCount;
        }

        public int DeleteByKey(params object[] parameters)
        {
            return _context.SqlModelMapper.TrackDeleteByKey<SalesOrder>(parameters)
                                          .SaveChanges()
                                          .DeletedCount;
        }

        public int Update(SalesOrder salesOrder)
        {
            var oldSalesOrder = this.RetrieveByKey(true, salesOrder.SalesOrderID);

            return _context.SqlModelMapper.TrackUpdate(oldSalesOrder, salesOrder)
                                          .SaveChanges()
                                          .ModifiedCount;
        }

    }
}
