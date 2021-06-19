using FluentValidation;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Validators.LilquorValidators
{
    public class CreateLiquorValidator : AbstractValidator<LiquorDto>
    {
        public CreateLiquorValidator(LiquorStoreContext context)
        {
            RuleFor(l => l.Name).NotEmpty().Must(name => !context.Liquors.Any(l => l.Name == name))
                .WithMessage("Entered liquor name already exists in database.");

            RuleFor(l => l.Price).NotEmpty().Must(price => price >= 2).WithMessage("Price must equal or greather than 2.");

            RuleFor(l => l.BrandId).NotEmpty().Must(brand => context.Brands.Any(b => b.Id == brand))
                .WithMessage("Selected brand doesn't exist in database.");

            RuleFor(l => l.TypeId).NotEmpty().Must(type => context.LiquorTypes.Any(t => t.Id == type))
                .WithMessage("Selected liquor type doesn't exist in database.");

            RuleFor(l => l.Sizes).NotEmpty().WithMessage("You have to select at least one bottle size.");
        }
    
    }
}
