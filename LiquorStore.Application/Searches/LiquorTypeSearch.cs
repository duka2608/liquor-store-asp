using LiquorStore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Searches
{
    public class LiquorTypeSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
