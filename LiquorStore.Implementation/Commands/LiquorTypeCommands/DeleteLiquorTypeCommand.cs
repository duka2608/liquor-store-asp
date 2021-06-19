using LiquorStore.Application.Commands;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands
{
    public class DeleteLiquorTypeCommand : IDeleteLiquorTypeCommand
    {
        private readonly LiquorStoreContext _context;

        public DeleteLiquorTypeCommand(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Delete liquor type command.";

        public void Execute(int request)
        {
            var type = _context.LiquorTypes.Find(request);

            if(type == null)
            {
                throw new EntityNotFoundException(request, typeof(LiquorType));
            }

            _context.LiquorTypes.Remove(type);
            _context.SaveChanges();
        }
    }
}
