using FluentValidation;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Validators.LiquorBrandValidators
{
    public class CreateLiquorBrandValidator : AbstractValidator<LiquorBrandDto>
    {
        public CreateLiquorBrandValidator(LiquorStoreContext context)
        {
            RuleFor(lb => lb.Name).NotEmpty()
                .Must(name => !context.Brands.Any(b => b.Name == name))
                .WithMessage("Brand with this name already exists in database.");
        }
    }
}
