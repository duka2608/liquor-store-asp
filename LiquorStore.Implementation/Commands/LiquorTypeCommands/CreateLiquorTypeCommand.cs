using FluentValidation;
using LiquorStore.Application.Commands;
using LiquorStore.Application.DataTransfer;
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
    public class CreateLiquorTypeCommand : ICreateLiquorTypeCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly CreateLiquorTypeValidator _validator;

        public CreateLiquorTypeCommand(LiquorStoreContext context, CreateLiquorTypeValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 1;

        public string Name => "Create new liquor type command.";

        public void Execute(LiquorTypeDto request)
        {
            _validator.ValidateAndThrow(request);

            var type = new LiquorType
            {
                Name = request.Name
            };

            _context.LiquorTypes.Add(type);
            _context.SaveChanges();
        }
    }
}
