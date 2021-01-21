using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Appeon.SnapObjectsDemo.Services
{
    public class SalesOrderDetailService : ServiceBase<SalesOrderDetail>,
        ISalesOrderDetailService
    {
        public SalesOrderDetailService(OrderContext context)
            : base(context)
        {
        }

        public async Task<int> CreateAsync(SalesOrderDetail salesOrderDetail, CancellationToken cancellationToken = default)
        {
            salesOrderDetail.ModifiedDate = DateTime.Now;

            return (await _context.SqlModelMapper.TrackCreate(salesOrderDetail)
                                          .SaveChangesAsync(cancellationToken))
                                          .InsertedCount;
        }

        public async Task<int> UpdateAsync(SalesOrderDetail salesOrderDetail, CancellationToken cancellationToken = default)
        {
            var oldSalesOrderDetail = await RetrieveByKeyAsync(
                false,
                new object[] { salesOrderDetail.SalesOrderDetailID },
                cancellationToken);

            return (await _context.SqlModelMapper
                                  .TrackUpdate(oldSalesOrderDetail, salesOrderDetail)
                                  .SaveChangesAsync(cancellationToken))
                                  .ModifiedCount;
        }

    }
}
