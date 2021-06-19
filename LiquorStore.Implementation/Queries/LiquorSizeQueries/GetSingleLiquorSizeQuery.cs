using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.Application.Queries.ILiquorSizeQueries;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries.LiquorSizeQueries
{
    public class GetSingleLiquorSizeQuery : IGetSingleLiquorSizeQuery
    {
        private readonly LiquorStoreContext _context;

        public GetSingleLiquorSizeQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 11;
        public string Name => "Get single liquor size query.";

        public LiquorSizeDto Execute(int search)
        {
            var liquorSize = _context.Sizes.Find(search);

            if(liquorSize == null)
            {
                throw new EntityNotFoundException(search, typeof(Size));
            }

            var result = new LiquorSizeDto
            {
                Id = liquorSize.Id,
                Name = liquorSize.Name
            };

            return result;
        }
    }
}
