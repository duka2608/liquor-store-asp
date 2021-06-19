using LiquorStore.Application.DataTransfer;
using LiquorStore.Application.Queries;
using LiquorStore.Application.Queries.IUserQueries;
using LiquorStore.Application.Searches;
using LiquorStore.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquorStore.Implementation.Queries.UserQueries
{
    public class GetUsersQuery : IGetUsersQuery
    {
        private readonly LiquorStoreContext _context;

        public GetUsersQuery(LiquorStoreContext context)
        {
            _context = context;
        }

        public int Id => 21;

        public string Name => "Get all users query.";

        public PagedResponse<UserDto> Execute(UserSearch search)
        {
            var users = _context.Users.AsQueryable();

            if (!string.IsNullOrEmpty(search.FirstName))
            {
                users = users.Where(u => u.FirstName.ToLower().Contains(search.FirstName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.LastName))
            {
                users = users.Where(u => u.LastName.ToLower().Contains(search.LastName.ToLower()));
            }

            if (!string.IsNullOrEmpty(search.Username))
            {
                users = users.Where(u => u.Username.ToLower().Contains(search.Username.ToLower()));
            }
            var skip = search.ItemsPerPage * (search.SelectedPage - 1);

            var result = new PagedResponse<UserDto>
            {
                Current = search.SelectedPage,
                ItemsPerPage = search.ItemsPerPage,
                Total = users.Count(),
                Items = users.Skip(skip).Take(search.ItemsPerPage).Select(u => new UserDto
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Username = u.Username,
                    Password = u.Password
                }).ToList()
            };

            return result;

        }
    }
}
