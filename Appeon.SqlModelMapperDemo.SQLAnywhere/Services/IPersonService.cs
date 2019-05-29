﻿using SnapObjects.Data;
using Appeon.SqlModelMapperDemo.SQLAnywhere.Models;
using System.Collections.Generic;

namespace Appeon.SqlModelMapperDemo.SQLAnywhere.Services
{
    public interface IPersonService
    {
        IList<Person> Retrieve(bool includeEmbedded, params object[] parameters);

        Person RetrieveByKey(bool includeEmbedded, params object[] parameters);

        int SavePerson(IModelEntry<Person> person,
                       IEnumerable<IModelEntry<BusinessentityAddress>> addresses,
                       IEnumerable<IModelEntry<Personphone>> phones,
                       IEnumerable<IModelEntry<Customer>> customers);
    }
}
