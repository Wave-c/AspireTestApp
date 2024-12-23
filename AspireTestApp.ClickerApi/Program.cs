using ClickerApi.Entities;
using ClickerApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<ClickerDBContext>("user-database");
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

builder.Services.AddMvc();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapDefaultEndpoints();

app.UseAuthorization();

app.MapControllers();


app.Run();
