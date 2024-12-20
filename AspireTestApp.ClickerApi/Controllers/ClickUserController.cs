using ClickerApi.Entities;
using ClickerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClickerApi.Controllers
{
    public class ClickUserController : ControllerBase
    {
        private UserService userService;

        [HttpPost("/sign-up")]
        public async Task<User> RegUser([FromBody] User user)
        {
            return await userService.Register(user);
        }

        [HttpPost("/sign-in")]
        public async Task<User?> Login([FromBody] User user)
        {
            return await userService.Login(user);
        }

        [HttpDelete("/delete-all")]
        public async Task DeleteAll()
        {
            await userService.DeleteAll();
        }
    }
}