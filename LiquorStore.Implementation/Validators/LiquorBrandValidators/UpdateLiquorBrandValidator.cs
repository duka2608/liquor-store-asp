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
    public class UpdateLiquorBrandValidator : AbstractValidator<LiquorBrandDto>
    {
        public UpdateLiquorBrandValidator(LiquorStoreContext context)
        {
            RuleFor(lb => lb.Name).NotEmpty()
                .Must((dto, name) => !context.Brands.Any(b => b.Name == name && b.Id != dto.Id))
                .WithMessage("Liquor brand with this name already exists in database.");
        }
    }
}
