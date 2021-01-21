using Appeon.SnapObjectsDemo.Service.Models;
using SnapObjects.Data;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<IList<TModel>> RetrieveAsync(
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            if (includeEmbedded)
            {
                return (await (await _context.SqlModelMapper
                    .LoadAsync<TModel>(parameters, cancellationToken))
                    .IncludeAllAsync(0, cascade: true, cancellationToken))
                    .ToList();
            }
            else
            {
                return (await _context.SqlModelMapper
                    .LoadAsync<TModel>(parameters, cancellationToken))
                    .ToList();
            }
        }

        public async Task<TModel> RetrieveByKeyAsync(
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            TModel model;

            if (includeEmbedded)
            {
                model = (await (await _context.SqlModelMapper
                    .LoadByKeyAsync<TModel>(parameters, cancellationToken))
                    .IncludeAllAsync(cancellationToken: cancellationToken))
                    .FirstOrDefault();
            }
            else
            {
                model = (await _context.SqlModelMapper
                    .LoadByKeyAsync<TModel>(parameters, cancellationToken))
                    .FirstOrDefault();
            }

            return model;
        }


        public async Task<Page<TModel>> LoadByPageAsync(
            int pageIndex,
            int pageSize,
            bool includeEmbedded,
            object[] parameters,
            CancellationToken cancellationToken = default)
        {
            var currentIndex = (pageIndex - 1) * pageSize;

            IList<TModel> items = null;
            var page = new Page<TModel>();

            page.PageSize = pageSize;
            page.PageIndex = pageIndex;

            if (includeEmbedded)
            {

                items = (await (await _context.SqlModelMapper
                    .LoadByPageAsync<TModel>(currentIndex, pageSize, parameters, cancellationToken))
                    .IncludeAllAsync(cancellationToken: cancellationToken))
                    .ToList();

            }
            else
            {
                items = (await _context.SqlModelMapper
                    .LoadByPageAsync<TModel>(currentIndex, pageSize, parameters, cancellationToken))
                    .ToList();
            }

            var totalItems = _context.SqlModelMapper.Count<TModel>(parameters);
            page.TotalItems = totalItems;
            page.Items = items;

            return page;
        }

    }
}
