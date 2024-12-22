using ClickerApi.Entities;

namespace ClickerApi.Services
{
    public class AuthService (ClickerDBContext dbContext)
    {
        public bool TokenVerification(User userDto)
        {
            return true;
            //return dbContext.Users.Any(x => x.Tocken == userDto.Tocken && x.Username == userDto.Username);
        }
    }
}