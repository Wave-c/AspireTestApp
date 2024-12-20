using ClickerApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ClickerApi.Services
{
    public class UserService(ClickerDBContext dbContext)
    {
        public async Task<User> Register(User user)
        {
            user.ClicksCount = 0;

            user.Id = Guid.NewGuid();

            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<User?> Login(User? user)
        {
            var tempUser = await dbContext.Users.FirstAsync(x => x.Id == user.Id);
            if(user != null)
            {
                return tempUser;
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteAll()
        {
            dbContext.Users.RemoveRange(dbContext.Users);
            await dbContext.SaveChangesAsync();
        }
    }
}