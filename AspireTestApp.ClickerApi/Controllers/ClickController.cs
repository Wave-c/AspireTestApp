using Microsoft.AspNetCore.Mvc;

namespace ClickerApi.Controllers
{
    public class ClickController : ControllerBase
    {
        [HttpGet("/click")]
        public async Task Click([FromQuery(Name = "id")] string id)
        {
            
        }
    }
}