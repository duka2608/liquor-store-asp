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
    public class UpdateLiquorSizeValidator : AbstractValidator<LiquorSizeDto>
    {
        public UpdateLiquorSizeValidator(LiquorStoreContext context)
        {
            RuleFor(ls => ls.Name).NotEmpty()
                .Must((dto, name) => !context.Sizes.Any(s => s.Name == name && s.Id != dto.Id))
                .WithMessage("Liquor size already exists.");
        }
    }
}
