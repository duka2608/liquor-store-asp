using FluentValidation;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Validators.OrderValidators
{
    public class OrderLineValidator : AbstractValidator<OrderLineDto>
    {
        public OrderLineValidator(LiquorStoreContext context)
        {
            RuleFor(ol => ol.Quantity).Must(q => q > 0).WithMessage("Entered quantity must be greather than 0.");
            RuleFor(ol => ol.ProductId).Must(pid => context.Liquors.Any(l => l.Id == pid)).WithMessage("Selected product could not be found.");
        }
    }
}
