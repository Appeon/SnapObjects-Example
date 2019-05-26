﻿using SnapObjects.Data;
using System.Collections.Generic;
using Appeon.SqlModelMapperDemo.Models;

namespace Appeon.SqlModelMapperDemo.Services
{
    public abstract class ServiceBase<TModel> 
        where TModel : class
    {
        protected readonly DataContext _context;

        protected ServiceBase(DataContext context)
        {
            _context = context;
        }

        public IList<TModel> Retrieve(bool includeEmbedded, params object[] parameters)
        {
            var sql = ModelSqlBuilder.GetBuilder<SalesOrder>(_context).QuerySql;        
            if (includeEmbedded)
            {
                return _context.SqlModelMapper.Load<TModel>(parameters)
                                           .IncludeAll(0, cascade:true)
                                           .ToList();
            }
            else
            {
                return _context.SqlModelMapper.Load<TModel>(parameters)
                                           .ToList();
            }
        }

        public TModel RetrieveByKey(bool includeEmbedded, params object[] parameters)
        {
            if (includeEmbedded)
            {
                return _context.SqlModelMapper.LoadByKey<TModel>(parameters)
                                           .IncludeAll()
                                           .FirstOrDefault(); 
            }
            else
            {
                return _context.SqlModelMapper.LoadByKey<TModel>(parameters)
                                           .FirstOrDefault();
            }
        }
        
    }
}
