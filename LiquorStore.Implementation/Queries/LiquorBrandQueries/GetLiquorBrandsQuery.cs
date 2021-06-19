using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Queries.ILiquorBrandQueries;
using LiquorStore.Application.Searches;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries.LiquorBrandQueries
{
    public class GetLiquorBrandsQuery : IGetLiquorBrandsQuery
    {
        private readonly LiquorStoreContext _context;

        public GetLiquorBrandsQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 6;

        public string Name => "Get liquor brands query.";

        public PagedResponse<LiquorBrandDto> Execute(LiquorBrandSearch search)
        {
            var liquorBrands = _context.Brands.AsQueryable();

            if(!string.IsNullOrEmpty(search.Name))
            {
                liquorBrands = liquorBrands.Where(lb => lb.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skip = search.ItemsPerPage * (search.SelectedPage - 1);

            var response = new PagedResponse<LiquorBrandDto>
            {
                Current = search.SelectedPage,
                ItemsPerPage = search.ItemsPerPage,
                Total = liquorBrands.Count(),
                Items = liquorBrands.Skip(skip).Take(search.ItemsPerPage).Select(lb => new LiquorBrandDto
                {
                    Id = lb.Id,
                    Name = lb.Name
                }).ToList()
            };

            return response;
        }
    }
}
