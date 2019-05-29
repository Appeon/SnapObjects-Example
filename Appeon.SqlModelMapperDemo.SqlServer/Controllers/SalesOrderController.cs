using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.SqlServer.Models;
using Appeon.SqlModelMapperDemo.SqlServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Appeon.SqlModelMapperDemo.SqlServer.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class SalesOrderController : ControllerBase
    {
        private readonly ISalesOrderService _saleService;
        private readonly IGenericServiceFactory _genericServices;       

        public SalesOrderController(ISalesOrderService saleService,
                                    IGenericServiceFactory genericServiceFactory)
        {
            _saleService = saleService;
            _genericServices = genericServiceFactory;
        }

        // GET api/SalesOrder/WinOpen
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> WinOpen()
        {
            var packer = new DataPacker();

            try
            {
                packer.AddModels("Customer",
                _genericServices.Get<DdCustomer>().Retrieve(false));
                packer.AddModels("SalesPerson",
                    _genericServices.Get<DdSalesPerson>().Retrieve(false));
                packer.AddModels("SalesTerritory",
                    _genericServices.Get<DdSalesTerritory>().Retrieve(false));
                packer.AddModels("ShipMethod",
                    _genericServices.Get<DdShipMethod>().Retrieve(false));
                packer.AddModels("OrderProduct",
                    _genericServices.Get<DdOrderProduct>().Retrieve(false));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }            

            return packer;
        }

        // GET api/SalesOrder/RetrieveSaleOrderList
        [HttpGet("{customerId}/{dateFrom}/{dateto}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> RetrieveSaleOrderList(
            int customerId, string dateFrom, string dateTo)
        {
            var packer = new DataPacker();
            var fromDate = DateTime.Parse(dateFrom);
            var toDate = DateTime.Parse(dateTo);

            try
            {
                packer.AddModels("SalesOrderHeader",
                    _saleService.Retrieve(false, customerId, fromDate, toDate));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
            
           
            return packer;
        }

        // GET api/SalesOrder/RetrieveSaleOrderDetail
        [HttpGet("{salesOrderId}/{customerId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> RetrieveSaleOrderDetail(
            int salesOrderId, int customerId)
        {

            var packer = new DataPacker();           

            try
            {
                packer.AddModels("SalesOrderDetail",
                             _genericServices.Get<SalesOrderDetail>()
                             .Retrieve(false, salesOrderId));

                packer.AddModels("DddwAddress",
                                 _genericServices.Get<DdCustomerAddress>()
                                 .Retrieve(false, customerId));

                packer.AddModels("DddwCreditcard",
                                 _genericServices.Get<DdCreditcard>()
                                 .Retrieve(false, customerId));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return packer;
        }

        // GET api/SalesOrder/RetrieveDropdownModel
        [HttpGet("{modelName}/{CodeId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> RetrieveDropdownModel(string modelName, int CodeId)
        {
            var packer = new DataPacker();
            
            try
            {
                switch (modelName)
                {
                    case "Customer":
                        packer.AddModels("DddwAddress",
                                 _genericServices.Get<DdCustomerAddress>()
                                 .Retrieve(false, CodeId));

                        packer.AddModels("DddwCreditcard",
                                         _genericServices.Get<DdCreditcard>()
                                         .Retrieve(false, CodeId));
                        break;
                }
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return packer;
        }

        // POST api/SalesOrder/SaveSalesOrderAndDetail
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> SaveSalesOrderAndDetail(IDataUnpacker unPacker)
        {
            var packer = new DataPacker();
            var saleOrderId = 0;

            var orderHeader = unPacker.GetModelEntries<SalesOrder>("dw1")
                              .FirstOrDefault();
            var orderDetail = unPacker.GetModelEntries<SalesOrderDetail>("dw2");

            try
            {
                saleOrderId = _saleService.SaveSalesOrderAndDetail(orderHeader, orderDetail);
                packer.AddValue("Status", "Success");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }            

            var SaleOrder = _saleService.RetrieveByKey(true, saleOrderId);
            packer.AddModel("SalesOrderHeader", SaleOrder)
                  .Include("SalesOrderDetail", m => m.OrderDetails);

            return packer;
        }

        // POST api/SalesOrder/SaveChanges
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> SaveChanges(IDataUnpacker unPacker)
        {
            var packer = new DataPacker();
            var modelname = unPacker.GetValue<string>("arm1");

            try
            {
                switch (modelname)
                {
                    case "SaleOrderHeader":
                        var orderHeader = unPacker.GetModelEntries<SalesOrder>("dw1")
                                          .FirstOrDefault();
                        var salesOrderId = _saleService.SaveSalesOrderHeader(orderHeader);

                        packer.AddModel("SalesOrderHeader", _saleService
                                        .RetrieveByKey(false, salesOrderId));
                        break;

                    case "SaleOrderDetail":
                        var orderDetail = unPacker.GetModelEntries<SalesOrderDetail>("dw1");
                        var dModel = _genericServices.Get<SalesOrderDetail>()
                                    .SaveChanges(orderDetail);

                        packer.AddValue("SalesOrderHeader.SalesOrderDetail",
                                        dModel.AffectedCount);
                        break;
                }
                packer.AddValue("Status", "Success");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return packer;
        }

        // Delete api/SalesOrder/DeleteSalesOrderByKey
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> DeleteSalesOrderByKey(IDataUnpacker unPacker)
        {
            var packer = new DataPacker();
            var modelName = unPacker.GetValue<string>("arm1");
            var saleOrderId = unPacker.GetValue<int>("arm2");
            
            try
            {
                switch (modelName)
                {
                    case "SaleOrder":
                        var orderDelete = _genericServices.Get<SalesOrder>()
                                          .DeleteByKey(saleOrderId);
                        break;

                    case "OrderDetail":
                        var saleDetailId = unPacker.GetValue<int>("arm3");
                        var detailDelete = _genericServices.Get<SalesOrderDetail>()
                            .DeleteByKey(saleOrderId, saleDetailId);
                        break;
                }
                packer.AddValue("Status", "Success");
            }            
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return packer;
        }
    }
}