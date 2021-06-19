using FluentValidation;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Validators.UserValidators
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(LiquorStoreContext context)
        {
            RuleFor(u => u.FirstName).NotEmpty().Length(3, 20);
            RuleFor(u => u.LastName).NotEmpty().Length(4, 25);
            RuleFor(u => u.Username).NotEmpty().Length(4, 20)
                .Must(username => !context.Users.Any(u => u.Username == username))
                    .WithMessage("Username already exists in database.");

            RuleFor(u => u.Email).NotEmpty().Length(4, 30)
                .Must(email => !context.Users.Any(u => u.Email == email))
                    .WithMessage("Email already exists in database.");

            RuleFor(u => u.Password).NotEmpty().Length(4, 30);

        }
    }
}
