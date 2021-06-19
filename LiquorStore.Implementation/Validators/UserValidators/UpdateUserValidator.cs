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
    public class UpdateUserValidator : AbstractValidator<UserDto>
    {
        public UpdateUserValidator(LiquorStoreContext context)
        {
            RuleFor(u => u.FirstName).NotEmpty().Length(3, 20);
            RuleFor(u => u.LastName).NotEmpty().Length(4, 25);
            RuleFor(u => u.Username).NotEmpty().Length(4, 20)
                .Must((dto, username) => !context.Users.Any(u => u.Username == username && u.Id != dto.Id))
                    .WithMessage("User with this username already exists in database.");

            RuleFor(u => u.Email).NotEmpty().Length(4, 30)
                .Must((dto, email) => !context.Users.Any(u => u.Email == email && u.Id != dto.Id))
                    .WithMessage("Email already exists in database.");

            RuleFor(u => u.Password).NotEmpty().Length(4, 30);

        }
    }
}
