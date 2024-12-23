using ClickerApi.Entities;
using ClickerApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClickerApi.Controllers
{
    public class ClickUserController : ControllerBase
    {
        private readonly IUserService userService;

        public ClickUserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("/sign-up")]
        public async Task<User> RegUser()
        {
            Console.WriteLine("aaaa");
            Console.WriteLine(userService);
            return await userService.Register();
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