using System;
using System.Collections.Generic;
using System.Text;

namespace Appeon.SnapObjectsDemo.Service.Models
{
    public class Page<TModel>
    {
        /// <summary>
        /// current page
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// total num
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// page size
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// result items
        /// </summary>
        public IList<TModel> Items { get; set; }
    }
}
