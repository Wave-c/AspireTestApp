using ClickerApi.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<ClickerDBContext>("user-database");
builder.Services.AddMvc();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapDefaultEndpoints();

app.UseAuthorization();

app.MapControllers();


app.Run();
