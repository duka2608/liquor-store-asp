using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Exceptions;
using LiquorStore.Application.Queries.IUserQueries;
using LiquorStore.DataAccess;
using LiquorStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries.UserQueries
{
    public class GetSingleUserQuery : IGetSingleUserQuery
    {
        private readonly LiquorStoreContext _context;

        public GetSingleUserQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 22;

        public string Name => "Get single user query";

        public UserDto Execute(int search)
        {
            var user = _context.Users.Find(search);

            if(user == null)
            {
                throw new EntityNotFoundException(search, typeof(User));
            }

            var result = new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Password = user.Password
            };

            return result;
        }
    }
}
