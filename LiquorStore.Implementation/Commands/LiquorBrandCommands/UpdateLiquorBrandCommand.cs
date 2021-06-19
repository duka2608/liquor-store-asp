using FluentValidation;
using LiquorStore.Application.Commands.ILiquorBrandCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
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
    public class UpdateLiquorBrandCommand : IUpdateLiquorBrandCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly UpdateLiquorBrandValidator _validator;

        public UpdateLiquorBrandCommand(LiquorStoreContext context, UpdateLiquorBrandValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 8;

        public string Name => "Update liquor type commmand.";

        public void Execute(LiquorBrandDto request)
        {
            var liquorBrand = _context.Brands.Find(request.Id);

            if(liquorBrand == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Brand));
            }

            _validator.ValidateAndThrow(request);

            liquorBrand.Id = request.Id;
            liquorBrand.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
