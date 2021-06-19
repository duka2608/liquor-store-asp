using FluentValidation;
using LiquorStore.Application.Commands.ILiquorSizeCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using LiquorStore.Implementation.Validators.LiquorSizeValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.LiquorSizeCommands
{
    public class UpdateLiquorSizeCommand : IUpdateLiquorSizeCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly UpdateLiquorSizeValidator _validator;

        public UpdateLiquorSizeCommand(LiquorStoreContext context, UpdateLiquorSizeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 13;

        public string Name => "Update liquor size command.";

        public void Execute(LiquorSizeDto request)
        {
            var liquorSize = _context.Sizes.Find(request.Id);

            if(liquorSize == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Size));
            }

            _validator.ValidateAndThrow(request);

            liquorSize.Id = request.Id;
            liquorSize.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
