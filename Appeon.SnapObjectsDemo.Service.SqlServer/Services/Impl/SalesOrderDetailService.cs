using Appeon.SnapObjectsDemo.Service.Datacontext;
using Appeon.SnapObjectsDemo.Service.Models;
using System;

namespace Appeon.SnapObjectsDemo.Services
{
    public class SalesOrderDetailService : ServiceBase<SalesOrderDetail>,
        ISalesOrderDetailService
    {
        public SalesOrderDetailService(OrderContext context)
            : base(context)
        {
        }

        public int Create(SalesOrderDetail salesOrderDetail)
        {
            salesOrderDetail.ModifiedDate = DateTime.Now;

            return _context.SqlModelMapper.TrackCreate<SalesOrderDetail>(salesOrderDetail)
                                          .SaveChanges()
                                          .InsertedCount;
        }


        public int Update(SalesOrderDetail salesOrderDetail)
        {
            var oldSalesOrderDetail = this.RetrieveByKey(false, salesOrderDetail.SalesOrderDetailID);

            return _context.SqlModelMapper.TrackUpdate(oldSalesOrderDetail, salesOrderDetail)
                                          .SaveChanges()
                                          .ModifiedCount;
        }
    }
}
