using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public int Total { get; set; }
        public int Current { get; set; }
        public int ItemsPerPage { get; set; }
        public IEnumerable<T> Items { get; set; }
        public int Count => (int)Math.Ceiling((float)Total / ItemsPerPage);
    }
}
