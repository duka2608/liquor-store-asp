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
    public class OrderValidator : AbstractValidator<OrderDto>
    {
        public OrderValidator(LiquorStoreContext context)
        {
            RuleFor(o => o.Address).NotEmpty();
            RuleFor(o => o.OrderLines).NotEmpty().DependentRules(() => 
            {
                RuleFor(o => o.OrderLines).Must(orderLines =>
                {
                    var distinctPr = orderLines.Select(ol => ol.ProductId).Distinct();

                    return distinctPr.Count() == orderLines.Count();
                }).WithMessage("There are duplicate order lines.").DependentRules(() => 
                {
                    RuleForEach(x => x.OrderLines).SetValidator(new OrderLineValidator(context));
                });
            });
        }
    }
}
