using FluentValidation;
using LiquorStore.Application.Commands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using LiquorStore.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands
{
    public class UpdateLiquorTypeCommand : IUpdateLiquorTypeCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly UpdateLiquorTypeValidator _validator;

        public UpdateLiquorTypeCommand(LiquorStoreContext context, UpdateLiquorTypeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 5;

        public string Name => "Update liquor type.";

        public void Execute(LiquorTypeDto request)
        {
            var liquorType = _context.LiquorTypes.Find(request.Id);

            if(liquorType == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(LiquorType));
            }

            _validator.ValidateAndThrow(request);

            liquorType.Id = request.Id;
            liquorType.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
