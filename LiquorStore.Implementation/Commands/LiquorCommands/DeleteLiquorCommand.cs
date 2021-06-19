using LiquorStore.Application.Commands.ILiquorCommands;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.LiquorCommands
{
    public class DeleteLiquorCommand : IDeleteLiquorCommand
    {
        private readonly LiquorStoreContext _context;

        public DeleteLiquorCommand(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 19;

        public string Name => "Delete liquor command.";

        public void Execute(int request)
        {
            var liquor = _context.Liquors.Find(request);

            if(liquor == null)
            {
                throw new EntityNotFoundException(request, typeof(Liquor));
            }

            _context.Liquors.Remove(liquor);
            _context.SaveChanges();
        }
    }
}
