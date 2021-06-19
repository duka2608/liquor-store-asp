using LiquorStore.Application.Commands.IUserCommands;
using LiquorStore.Application.Exceptions;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Commands.UserCommands
{
    public class DeleteUserCommand : IDeleteUserCommand
    {
        private readonly LiquorStoreContext _context;

        public DeleteUserCommand(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 24;

        public string Name => "Delete user command.";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            if(user == null)
            {
                throw new EntityNotFoundException(request, typeof(User));
            }

            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}
