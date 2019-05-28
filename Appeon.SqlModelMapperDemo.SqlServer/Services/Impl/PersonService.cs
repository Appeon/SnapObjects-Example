using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.SqlServer.Models;
using System;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.SqlServer.Services
{
    class PersonService : ServiceBase<Person>, IPersonService
    {
        public PersonService(OrderContext context)
            : base(context)
        {
        }

        public int SavePerson(IModelEntry<Person> person,
                              IEnumerable<IModelEntry<BusinessentityAddress>> addresses,
                              IEnumerable<IModelEntry<Personphone>> phones,
                              IEnumerable<IModelEntry<Customer>> customers)
        {
            
            if (person.ModelState == ModelState.NewModified)
            {
                var business = new BusinessEntity();
                business.ModifiedDate = DateTime.Now;
                _context.SqlModelMapper.TrackCreate(business).SaveChanges();

                person.CurrentValueChanged += Temp_Solution;
                person.SetCurrentValue("Businessentityid", business.Businessentityid);  

            }        
            var master = _context.SqlModelMapper.TrackMaster(person)
                                    .TrackDetails(mapper => mapper.businessAddress, addresses)
                                    .TrackDetails(mapper => mapper.Personphones, phones)
                                    .TrackDetails(mapper => mapper.Customers, customers)
                                    .MasterModel;

             _context.SqlModelMapper.SaveChanges();              
             
            return master.Businessentityid;                                      
        }

        private void Temp_Solution(string arg1, object arg2)
        {
    
        }

    }
}
