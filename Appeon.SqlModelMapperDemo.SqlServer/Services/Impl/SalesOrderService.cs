using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.SqlServer.Services
{
    public class SalesOrderService : ServiceBase<SalesOrder>, ISalesOrderService
    {
        public SalesOrderService(OrderContext context)
            :base(context)
        {
        }
        

        public int SaveSalesOrderHeader(IModelEntry<SalesOrder> header)
        {
            var master = _context.SqlModelMapper.TrackMaster(header)
                                             .MasterModel;

            _context.SqlModelMapper.SaveChanges();

            return master.SalesOrderID;
        }

        public int SaveSalesOrderAndDetail(IModelEntry<SalesOrder> header,
                        IEnumerable<IModelEntry<SalesOrderDetail>> details)
        {
            var master = _context.SqlModelMapper.TrackMaster(header)
                                             .TrackDetails(m => m.OrderDetails, details)
                                             .MasterModel;

            _context.SqlModelMapper.SaveChanges();

            return master.SalesOrderID;
        }

    }
}
