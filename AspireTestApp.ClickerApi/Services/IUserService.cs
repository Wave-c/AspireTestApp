using ClickerApi.Entities;

namespace ClickerApi.Services
{
    public interface IUserService
    {
        public Task<User> Register();
        public Task<User?> Login(User? user);
        public Task DeleteAll();
    }
}