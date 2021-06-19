using FluentValidation;
using LiquorStore.Application.Commands;
using LiquorStore.Application.DataTransfer;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using LiquorStore.Implementation.Validators.OrderValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands
{
    public class CreateOrderCommand : ICreateOrderCommand
    {
        private readonly LiquorStoreContext _context;
        private readonly OrderValidator _validator;

        public CreateOrderCommand(LiquorStoreContext context, OrderValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 25;

        public string Name => "Create order command.";

        public void Execute(OrderDto request)
        {
            _validator.ValidateAndThrow(request);

            var orderEntity = new Order
            {
                PlacedAt = DateTime.UtcNow,
                Address = request.Address,
                OrderLines = request.OrderLines.Select(ol =>
                {
                    var liquor = _context.Liquors.Find(ol.ProductId);

                    return new OrderLine
                    {
                        Price = liquor.Price,
                        LiquorName = liquor.Brand.Name + " " + liquor.Name,
                        LiquorId = liquor.Id,
                        Quantity = ol.Quantity
                    };
                }).ToList()
            };

            _context.Orders.Add(orderEntity);
            _context.SaveChanges();
            
        }
    }
}
