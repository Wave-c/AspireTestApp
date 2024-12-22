using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BlazorClickerApp.Entities;

namespace BlazorClickerApp
{
    public class ClickApiClient(HttpClient httpClient) : IDisposable
    {
        public async Task Click(User user)
        {
            JsonContent jsonContent = JsonContent.Create(user);
            if((await httpClient.PostAsync("https://clickerApi/click", jsonContent)).StatusCode == System.Net.HttpStatusCode.OK)
            {
                
            }
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }

        public async Task<User> Register(User regUser)
        {
            
            JsonContent jsonContent = JsonContent.Create(regUser);

            return JsonSerializer.Deserialize<User>(await (await httpClient.PostAsync("/sign-up", jsonContent, default)).Content.ReadAsStringAsync());
        }
    }
}