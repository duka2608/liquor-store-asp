using LiquorStore.Application.Commands.ILiquorSizeCommands;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.LiquorSizeCommands
{
    public class DeleteLiquorSizeCommand : IDeleteLiquorSizeCommand
    {
        private readonly LiquorStoreContext _context;

        public DeleteLiquorSizeCommand(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 14;

        public string Name => "Delete liquor size command.";

        public void Execute(int request)
        {
            var liquorSize = _context.Sizes.Find(request);

            if(liquorSize == null)
            {
                throw new EntityNotFoundException(request, typeof(Size));
            }

            _context.Remove(liquorSize);
            _context.SaveChanges();
        }
    }
}
