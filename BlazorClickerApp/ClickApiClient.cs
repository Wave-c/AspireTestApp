using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorClickerApp.Entities;

namespace BlazorClickerApp
{
    public class ClickApiClient(HttpClient httpClient)
    {
        public async Task Click(User user)
        {
            if((await httpClient.GetAsync("/click?")).StatusCode == System.Net.HttpStatusCode.OK)
            {
                
            }
        }

        public async Task<User> Register(User regUser)
        {
            
            JsonContent jsonContent = JsonContent.Create(regUser);

            return JsonSerializer.Deserialize<User>(await (await httpClient.PostAsync("/sign-up", jsonContent, default)).Content.ReadAsStringAsync());
        }
    }
}