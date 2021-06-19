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
    public class CreateLiquorTypeValidator : AbstractValidator<LiquorTypeDto>
    {
        public CreateLiquorTypeValidator(LiquorStoreContext context)
        {
            RuleFor(lt => lt.Name)
                .NotEmpty()
                .Must(lt => !context.LiquorTypes.Any(clt => clt.Name == lt))
                .WithMessage("Liquor type with this name already exists in database.");
        }
    }
}
