
using Appeon.SnapObjectsDemo.Service.Models;
using SnapObjects.Data;
using System.Collections.Generic;

namespace Appeon.SnapObjectsDemo.Services
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
            if (includeEmbedded)
            {
                return _context.SqlModelMapper.Load<TModel>(parameters).IncludeAll(0, cascade: true).ToList();
            }
            else
            {
                return _context.SqlModelMapper.Load<TModel>(parameters).ToList();
            }
        }

        public TModel RetrieveByKey(bool includeEmbedded, params object[] parameters)
        {
            TModel model;

            if (includeEmbedded)
            {
                model = _context.SqlModelMapper.LoadByKey<TModel>(parameters).IncludeAll().FirstOrDefault();
            }
            else
            {
                model = _context.SqlModelMapper.LoadByKey<TModel>(parameters).FirstOrDefault();
            }

            return model;
        }


        public Page<TModel> LoadByPage(int pageIndex, int pageSize, bool includeEmbedded, params object[] parameters)
        {
            int currentIndex = (pageIndex - 1) * pageSize;
            IList<TModel> items = null;
            Page<TModel> page = new Page<TModel>();
            page.PageSize = pageSize;
            page.PageIndex = pageIndex;
            if (includeEmbedded)
            {

                items = _context.SqlModelMapper.LoadByPage<TModel>(currentIndex, pageSize, parameters)
                                               .IncludeAll()
                                               .ToList();

            }
            else
            {
                items = _context.SqlModelMapper.LoadByPage<TModel>(currentIndex, pageSize, parameters).ToList();
            }
            int totalItems = _context.SqlModelMapper.Count<TModel>(parameters);
            page.TotalItems = totalItems;
            page.Items = items;
            return page;
        }

    }
}
