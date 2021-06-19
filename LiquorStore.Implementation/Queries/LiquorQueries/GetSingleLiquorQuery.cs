using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.Application.Queries.ILiquorQueries;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries.LiquorQueries
{
    public class GetSingleLiquorQuery : IGetSingleLiquorQuery
    {
        private readonly LiquorStoreContext _context;

        public GetSingleLiquorQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Get single liquor query.";
        public LiquorDto Execute(int search)
        {
            var liquor = _context.Liquors
                .Include(l => l.Brand)
                .Include(l => l.Type)
                .Include(l => l.LiquorSizes)
                .ThenInclude(l => l.Size).FirstOrDefault(l => l.Id == search);

            if(liquor == null)
            {
                throw new EntityNotFoundException(search, typeof(Liquor));
            }

            var response = new LiquorDto
            {
                Id = liquor.Id,
                Name = liquor.Brand.Name + " " + liquor.Name,
                Price = liquor.Price,
                Description = liquor.Description,
                BrandId = liquor.BrandId,
                Brand = liquor.Brand.Name,
                TypeId = liquor.TypeId,
                Type = liquor.Type.Name,
                Sizes = liquor.LiquorSizes.Select(ls => new LiquorSizeDto
                {
                    Id = ls.Size.Id,
                    Name = ls.Size.Name
                })
            };

            return response;
        }
    }
}
