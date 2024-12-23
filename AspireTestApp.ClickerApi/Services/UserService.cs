using ClickerApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace ClickerApi.Services
{
    public class UserService(ClickerDBContext dbContext) : IUserService
    {
        public async Task<User> Register()
        {
            User user = new User();
            
            user.ClicksCount = 0;

            user.Id = Guid.NewGuid().ToString();

            Console.WriteLine(user.Id);

            await dbContext.Users.AddAsync(user);
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