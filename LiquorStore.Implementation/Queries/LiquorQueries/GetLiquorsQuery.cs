using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Searches;
using LiquorStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries
{
    public class GetLiquorsQuery : IGetLiquorsQuery
    {
        private readonly LiquorStoreContext _context;

        public GetLiquorsQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 15;

        public string Name => "Get all liquors query.";

        public PagedResponse<LiquorDto> Execute(LiqourSearch search)
        {
            var query = _context.Liquors
                .Include(l => l.Brand)
                .Include(l => l.Type)
                .Include(l => l.LiquorSizes)
                .ThenInclude(l => l.Size).AsQueryable();

            if(!string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(l => l.Name.ToLower().Contains(search.Name.ToLower()) || l.Brand.Name.ToLower().Contains(search.Name.ToLower()));
            }

            if(search.MinPrice.HasValue)
            {
                query = query.Where(l => l.Price >= search.MinPrice);
            }

            if (search.MaxPrice.HasValue)
            {
                query = query.Where(l => l.Price <= search.MaxPrice);
            }

            if(search.BrandId.HasValue)
            {
                query = query.Where(l => l.BrandId == search.BrandId);
            }

            if(search.TypeId.HasValue)
            {
                query = query.Where(l => l.TypeId == search.TypeId);
            }

            var skipCount = search.ItemsPerPage * (search.SelectedPage - 1);

            var response = new PagedResponse<LiquorDto>
            {
                Total = query.Count(),
                ItemsPerPage = search.ItemsPerPage,
                Current = search.SelectedPage,
                Items = query.Skip(skipCount).Take(search.ItemsPerPage).Select(l => new LiquorDto
                {
                    Id = l.Id,
                    Name = l.Brand.Name+" "+l.Name,
                    Price = l.Price,
                    Description = l.Description,
                    BrandId = l.BrandId,
                    Brand = l.Brand.Name,
                    TypeId = l.TypeId,
                    Type = l.Type.Name,
                    Sizes = l.LiquorSizes.Select(ls => new LiquorSizeDto
                    {
                        Id = ls.Size.Id,
                        Name = ls.Size.Name
                    })
                }).ToList()
            };

            return response;
        }
    }
}
