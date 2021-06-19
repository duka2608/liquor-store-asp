using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.Application.Queries;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries
{
    public class GetSingleLiquorType : IGetSingleLiquorType
    {
        private readonly LiquorStoreContext _context;

        public GetSingleLiquorType(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 4;

        public string Name => "Get single liquor type.";
        public LiquorTypeDto Execute(int search)
        {
            var liquorType = _context.LiquorTypes.Find(search);

            if(liquorType == null)
            {
                throw new EntityNotFoundException(search, typeof(LiquorType));
            }

            var response = new LiquorTypeDto
            {
                Id = liquorType.Id,
                Name = liquorType.Name
            };

            return response;
        }
    }
}
