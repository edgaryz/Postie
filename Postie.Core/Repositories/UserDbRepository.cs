using Microsoft.EntityFrameworkCore;
using Postie.Core.Contracts;
using Postie.Core.Models;

namespace Postie.Core.Repositories
{
    public class UserDbRepository : IUserDbRepository
    {
        public async Task<List<User>> GetAllUsers()
        {
            using (var context = new MyDbContext())
            {
                List<User> allUsers = await context.Users.ToListAsync();
                return allUsers;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            using (var context = new MyDbContext())
            {
                return await context.Users.FindAsync(id);
            }
        }
        public async Task CreateUser(User user)
        {
            using (var context = new MyDbContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateUser(User user)
        {
            using (var context = new MyDbContext())
            {
                await context.Users
                    .Where(x => x.Id == user.Id)
                    .ExecuteUpdateAsync(x => x
                        .SetProperty(y => y.Name, user.Name)
                        .SetProperty(y => y.Email, user.Email));
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int id)
        {
            using (var context = new MyDbContext())
            {
                context.Users.Remove(await context.Users.FindAsync(id));
                await context.SaveChangesAsync();
            }
        }

    }
}
