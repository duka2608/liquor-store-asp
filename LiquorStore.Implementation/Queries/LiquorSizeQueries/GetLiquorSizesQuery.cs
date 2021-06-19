using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Queries.ILiquorSizeQueries;
using LiquorStore.Application.Searches;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries.LiquorSizeQueries
{
    public class GetLiquorSizesQuery : IGetLiquorSizesQuery
    {
        private readonly LiquorStoreContext _context;

        public GetLiquorSizesQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 10;

        public string Name => "Get all liquor sizes query.";

        public PagedResponse<LiquorSizeDto> Execute(LiquorSizeSearch search)
        {
            var liquorSizes = _context.Sizes.AsQueryable();

            if(!string.IsNullOrEmpty(search.Name))
            {
                liquorSizes = liquorSizes.Where(ls => ls.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skip = search.ItemsPerPage * (search.SelectedPage - 1);

            var result = new PagedResponse<LiquorSizeDto>
            {
                Current = search.SelectedPage,
                ItemsPerPage = search.ItemsPerPage,
                Total = liquorSizes.Count(),
                Items = liquorSizes.Skip(skip).Take(search.ItemsPerPage).Select(ls => new LiquorSizeDto
                {
                    Id = ls.Id,
                    Name = ls.Name
                }).ToList()
            };

            return result;
        }
    }
}
