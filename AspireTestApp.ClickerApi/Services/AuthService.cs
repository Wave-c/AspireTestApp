using ClickerApi.Dtos;
using ClickerApi.Entities;

namespace ClickerApi.Services
{
    public class AuthService (ClickerDBContext dbContext)
    {
        public bool TokenVerification(UserDto userDto)
        {
            return dbContext.Users.Any(x => x.Tocken == userDto.Tocken && x.Username == userDto.Username);
        }
    }
}