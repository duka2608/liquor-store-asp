using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.Application.Queries.ILiquorBrandQueries;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries.LiquorBrandQueries
{
    public class GetSingleLiquorBrand : IGetSingleLiquorBrandQuery
    {
        private readonly LiquorStoreContext _context;

        public GetSingleLiquorBrand(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 7;

        public string Name => "Get single liquor brand query.";

        public LiquorBrandDto Execute(int search)
        {
            var liquorBrand = _context.Brands.Find(search);

            if(liquorBrand == null)
            {
                throw new EntityNotFoundException(search, typeof(Brand));
            }

            var response = new LiquorBrandDto
            {
                Id = liquorBrand.Id,
                Name = liquorBrand.Name
            };

            return response;
        }
    }
}
