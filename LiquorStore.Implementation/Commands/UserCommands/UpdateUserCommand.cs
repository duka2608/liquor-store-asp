using FluentValidation;
using LiquorStore.Application.Commands.IUserCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using LiquorStore.Implementation.Validators.UserValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.UserCommands
{
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly UpdateUserValidator _validator;

        public UpdateUserCommand(LiquorStoreContext context, UpdateUserValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 23;

        public string Name => "Update user command.";

        public void Execute(UserDto request)
        {
            var user = _context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(User));
            }

            _validator.ValidateAndThrow(request);

        }
    }
}
