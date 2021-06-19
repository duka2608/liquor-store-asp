using LiquorStore.Application.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Application.Searches
{
    public class LiqourSearch : PagedSearch
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public decimal? BrandId { get; set; }
        public decimal? TypeId { get; set; }
    }
}
