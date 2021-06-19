using LiquorStore.Application.Commands.ILiquorBrandCommands;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.LiquorBrandCommands
{
    public class DeleteLiquorBrandCommand : IDeleteLiquorBrandCommand
    {
        private readonly LiquorStoreContext _context;

        public DeleteLiquorBrandCommand(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name => "Delete liquor brand command.";

        public void Execute(int request)
        {
            var liquorBrand = _context.Brands.Find(request);

            if(liquorBrand == null)
            {
                throw new EntityNotFoundException(request, typeof(Brand));
            }

            _context.Brands.Remove(liquorBrand);
            _context.SaveChanges();
        }
    }
}
