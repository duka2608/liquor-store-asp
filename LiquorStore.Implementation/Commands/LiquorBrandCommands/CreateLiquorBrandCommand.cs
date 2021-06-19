using FluentValidation;
using LiquorStore.Application.Commands.ILiquorBrandCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using LiquorStore.Implementation.Validators.LiquorBrandValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.LiquorBrandCommands
{
    public class CreateLiquorBrandCommand : ICreateLiquorBrandCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly CreateLiquorBrandValidator _validator;

        public CreateLiquorBrandCommand(LiquorStoreContext context, CreateLiquorBrandValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Create liquor brand command.";

        public void Execute(LiquorBrandDto request)
        {
            _validator.ValidateAndThrow(request);

            var liquorBrand = new Brand
            {
                Name = request.Name
            };

            _context.Brands.Add(liquorBrand);
            _context.SaveChanges();
        }
    }
}
