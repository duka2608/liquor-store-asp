using FluentValidation;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Validators
{
    public class UpdateLiquorTypeValidator : AbstractValidator<LiquorTypeDto>
    {
        public UpdateLiquorTypeValidator(LiquorStoreContext context)
        {
            RuleFor(lt => lt.Name).NotEmpty()
                .Must((dto, name) => !context.LiquorTypes.Any(lt => lt.Name == name && lt.Id != dto.Id))
                .WithMessage("Liquor type with this name already exists in database.");
        }
    }
}
