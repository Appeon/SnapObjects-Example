using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Services
{
    public class SalesOrderService : ServiceBase<SalesOrder>, ISalesOrderService
    {
        public SalesOrderService(OrderContext context)
            : base(context)
        { }

        public async Task<int> CreateAsync(SalesOrder salesOrder, CancellationToken cancellationToken = default)
        {
            return (await _context.SqlModelMapper.TrackCreate(salesOrder)
                                          .SaveChangesAsync(cancellationToken))
                                          .InsertedCount;
        }

        public async Task<int> DeleteByKeyAsync(object[] parameters, CancellationToken cancellationToken = default)
        {
            return (await _context.SqlModelMapper.TrackDeleteByKey<SalesOrder>(parameters)
                                          .SaveChangesAsync(cancellationToken))
                                          .DeletedCount;
        }

        public async Task<int> UpdateAsync(SalesOrder salesOrder, CancellationToken cancellationToken = default)
        {
            var oldSalesOrder = await RetrieveByKeyAsync(true, new object[] { salesOrder.SalesOrderID }, cancellationToken);

            return (await _context.SqlModelMapper.TrackUpdate(oldSalesOrder, salesOrder)
                                          .SaveChangesAsync(cancellationToken))
                                          .ModifiedCount;
        }

    }
}
