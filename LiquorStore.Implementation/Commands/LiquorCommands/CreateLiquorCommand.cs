using FluentValidation;
using LiquorStore.Application.Commands.ILiquorCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using LiquorStore.Implementation.Validators.LilquorValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.LiquorCommands
{
    public class CreateLiquorCommand : ICreateLiquorCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly CreateLiquorValidator _validator;

        public CreateLiquorCommand(LiquorStoreContext context, CreateLiquorValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 17;

        public string Name => "Create liquor command";

        public void Execute(LiquorDto request)
        {
            _validator.ValidateAndThrow(request);

            var liquor = new Liquor
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                BrandId = request.BrandId,
                TypeId = request.TypeId,
                LiquorSizes = request.Sizes.Select(s =>
                {
                    var size = _context.Sizes.Find(s.Id);

                    return new LiquorSizes
                    {
                        SizeId = size.Id
                    };
                }).ToList()
            };

            _context.Liquors.Add(liquor);
            _context.SaveChanges();
        }
    }
}
