using ClickerApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ClickerApi.Controllers
{
    public class ClickController : ControllerBase
    {
        [HttpPost("/click")]
        public async Task Click([FromBody] User user)
        {
            Console.WriteLine("click");
        }
    }
}