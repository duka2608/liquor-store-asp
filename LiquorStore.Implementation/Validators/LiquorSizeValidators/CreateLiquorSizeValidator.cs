using FluentValidation;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Validators.LiquorSizeValidators
{
    public class CreateLiquorSizeValidator : AbstractValidator<LiquorSizeDto>
    {
        public CreateLiquorSizeValidator(LiquorStoreContext context)
        {
            RuleFor(ls => ls.Name).NotEmpty()
                .Must(name => !context.Sizes.Any(s => s.Name == name))
                .WithMessage("Entered liquor size already exists.");
        }
    }
}
