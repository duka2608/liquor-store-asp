using FluentValidation;
using LiquorStore.Application.Commands.ILiquorSizeCommands;
using LiquorStore.Application.DataTransfer;
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
    public class CreateLiquorSizeCommand : ICreateLiquorSizeCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly CreateLiquorSizeValidator _validator;

        public CreateLiquorSizeCommand(LiquorStoreContext context, CreateLiquorSizeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 12;

        public string Name => "Create liquor size command.";

        public void Execute(LiquorSizeDto request)
        {
            _validator.ValidateAndThrow(request);

            var liquorSize = new Size
            {
                Name = request.Name
            };

            _context.Sizes.Add(liquorSize);
            _context.SaveChanges();
        }
    }
}
