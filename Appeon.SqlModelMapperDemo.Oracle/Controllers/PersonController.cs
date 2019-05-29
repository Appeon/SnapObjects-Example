using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.Oracle.Models;
using Appeon.SqlModelMapperDemo.Oracle.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Appeon.SqlModelMapperDemo.Oracle.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IGenericServiceFactory _genericServices;

        public PersonController(IPersonService perService, 
                                IGenericServiceFactory genericServiceFactory)
        {
            _personService = perService;
            _genericServices = genericServiceFactory;
        }

        // GET api/Person/WinOpen
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> WinOpen()
        {
            var packer = new DataPacker();

            try
            {
                packer.AddModels("Address",
                _genericServices.Get<DdAddress>().Retrieve(false));
                packer.AddModels("AddressType",
                    _genericServices.Get<DdAddressType>().Retrieve(false));
                packer.AddModels("PhonenumberType",
                    _genericServices.Get<DdPhoneNumberType>().Retrieve(false));
                packer.AddModels("CustomerTerritory",
                    _genericServices.Get<DdSalesTerritory>().Retrieve(false));
                packer.AddModels("Store",
                    _genericServices.Get<DdStore>().Retrieve(false));
                packer.AddModels("Person", _personService.Retrieve(false));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return packer;
        }

        // GET api/Person/RetrievePersonByKey        
        [HttpGet("{personId}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> RetrievePersonByKey(int personId)
        {
            var packer = new DataPacker();
            
            try
            {
                var person = _personService.RetrieveByKey(true, personId);

                packer.AddModel("Person", person)
                  .Include("PersonAddress", m => m.businessAddress)
                  .Include("PersonPhone", m => m.Personphones)
                  .Include("Customer", m => m.Customers);
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            } 

            return packer;
        }

        // POST api/Person/SavePerson
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> SavePerson(IDataUnpacker unPacker)
        {
            var packer = new DataPacker();

            try
            {
                var person = unPacker.GetModelEntries<Person>("dw1").FirstOrDefault();
                var personId = 0;

                var personAddress = unPacker.GetModelEntries<BusinessentityAddress>("dw2",
                    MappingMethod.Key);
                var personPhone = unPacker.GetModelEntries<Personphone>("dw3",
                    MappingMethod.Key);
                var customer = unPacker.GetModelEntries<Customer>("dw4",
                    MappingMethod.Key);
           
                personId = _personService.SavePerson(person, 
                           personAddress, personPhone, customer);
                packer.AddValue("Status", "Success");

                var master = _personService.RetrieveByKey(true, personId);

                packer.AddModel("Person", master)
                  .Include("PersonAddress", m => m.businessAddress)
                  .Include("PersonPhone", m => m.Personphones)
                  .Include("Customer", m => m.Customers);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

            return packer;
        }

        // POST api/Person/Savechanges
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> Savechanges(IDataUnpacker unPacker)
        {
            var packer = new DataPacker();
           
            IDbResult result;
            object personId = 0;

            try
            {
                var personAddress = unPacker.GetModelEntries<BusinessentityAddress>("dw1");
                var personPhone = unPacker.GetModelEntries<Personphone>("dw2");
                var customer = unPacker.GetModelEntries<Customer>("dw3");

                if (personAddress.Count() > 0)
                {
                    result = _genericServices.Get<BusinessentityAddress>()
                             .SaveChanges(personAddress);
                    personId = personAddress.FirstOrDefault()
                               .GetCurrentValue("Businessentityid");
                }

                if (personPhone.Count() > 0)
                {
                    result = _genericServices.Get<Personphone>()
                             .SaveChanges(personPhone);
                    personId = personPhone.FirstOrDefault()
                              .GetCurrentValue("Businessentityid");
                }

                if (customer.Count() > 0)
                {
                    result = _genericServices.Get<Customer>().SaveChanges(customer);
                    personId = customer.FirstOrDefault().GetCurrentValue("Personid");
                }

                var master = _personService.RetrieveByKey(true, personId);

                packer.AddModel("Person", master)
                      .Include("PersonAddress", m => m.businessAddress)
                      .Include("PersonPhone", m => m.Personphones)
                      .Include("Customer", m => m.Customers);
                packer.AddValue("Status", "Success");
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }            

            return packer;
        }

        // Delete api/Person/DeleteByKey
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IDataPacker> DeleteByKey(IDataUnpacker unPacker)
        {
            var packer = new DataPacker();

            var dwname = unPacker.GetValue<string>("arm1");
            var personId = unPacker.GetValue<int>("arm2");

            try
            {
                switch (dwname)
                {
                    case "Person":
                        var personDelete = _genericServices.Get<Person>()
                                           .DeleteByKey(personId);
                        break;

                    case "PersonAddress":
                        var addressId = unPacker.GetValue<int>("arm3");
                        var addressTypeId = unPacker.GetValue<int>("arm4");

                        var addressDelete = _genericServices
                            .Get<BusinessentityAddress>()
                            .DeleteByKey(personId, addressId, addressTypeId);
                        break;

                    case "PersonPhone":
                        var personNumber = unPacker.GetValue<string>("arm3");
                        var phonenumbertypeid = unPacker.GetValue<int>("arm4");

                        var phoneDelete = _genericServices
                            .Get<Personphone>()
                            .DeleteByKey(personId, personNumber, phonenumbertypeid);
                        break;

                    case "Customer":
                        var customerId = unPacker.GetValue<int>("arm3");

                        var custDelete = _genericServices.Get<Customer>()
                            .DeleteByKey(customerId);
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