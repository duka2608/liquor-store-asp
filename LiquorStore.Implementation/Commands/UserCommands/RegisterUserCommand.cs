using FluentValidation;
using LiquorStore.Application.Commands.IUserCommands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using LiquorStore.Implementation.Email;
using LiquorStore.Implementation.Validators.UserValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.UserCommands
{
    public class RegisterUserCommand : IRegisterUserCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly CreateUserValidator _validator;
        private readonly EmailSender _sender;

        public RegisterUserCommand(LiquorStoreContext context, CreateUserValidator validator, EmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 20;

        public string Name => "Register new user command.";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Users.Add(new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            });

            _context.SaveChanges();

            _sender.Send(new EmailDto
            {
                EmailTo = request.Email,
                Subject = "Welcome to Liquor Store !",
                Content = "<h1>Your account was successfully created, enjoy.</h1>"
            });
        }
    }
}
