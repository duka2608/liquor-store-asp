using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Searches;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries
{
    public class GetLiquorTypesQuery : IGetLiquorTypesQuery
    {
        private readonly LiquorStoreContext _context;

        public GetLiquorTypesQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 3;

        public string Name => "Get all liquor types query.";

        public PagedResponse<LiquorTypeDto> Execute(LiquorTypeSearch search)
        {
            var liquorTypes = _context.LiquorTypes.AsQueryable();

            if(!string.IsNullOrEmpty(search.Name))
            {
                liquorTypes = liquorTypes.Where(lt => lt.Name.ToLower().Contains(search.Name.ToLower()));
            }

            var skip = search.ItemsPerPage * (search.SelectedPage - 1);

            var response = new PagedResponse<LiquorTypeDto>
            {
                Current = search.SelectedPage,
                ItemsPerPage = search.ItemsPerPage,
                Total = liquorTypes.Count(),
                Items = liquorTypes.Skip(skip).Take(search.ItemsPerPage).Select(lt => new LiquorTypeDto
                {
                    Id = lt.Id,
                    Name = lt.Name
                }).ToList()
            };

            return response;
        }
    }
}
