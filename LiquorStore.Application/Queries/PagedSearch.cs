using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Queries
{
    public abstract class PagedSearch
    {
        public int ItemsPerPage { get; set; } = 5;
        public int SelectedPage { get; set; } = 1;
    }
}
