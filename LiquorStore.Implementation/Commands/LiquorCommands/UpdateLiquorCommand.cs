using LiquorStore.Application.Commands.ILiquorCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.LiquorCommands
{
    public class UpdateLiquorCommand : IUpdateLiquorCommand
    {
        private readonly LiquorStoreContext _context;

        public UpdateLiquorCommand(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 18;

        public string Name => "Update liquor type";

        public void Execute(LiquorDto request)
        {
            var liquor = _context.Liquors.Find(request.Id);

            if(liquor == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Liquor));
            }

            liquor.Name = request.Name;
            liquor.Price = request.Price;
            liquor.Description = request.Description;
            liquor.BrandId = request.BrandId;
            liquor.TypeId = request.TypeId;
            liquor.LiquorSizes = request.Sizes.Select(s =>
            {
                var size = _context.Sizes.Find(s.Id);

                return new LiquorSizes
                {
                    SizeId = size.Id
                };
            }).ToList();

            _context.SaveChanges();
        }
    }
}
