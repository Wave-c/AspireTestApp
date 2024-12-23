internal class Program
{
    private static void Main(string[] args)
    {
        var builder = DistributedApplication.CreateBuilder(args);

        var pgServer = builder.AddPostgres("pg-server");

        var db = pgServer.AddDatabase("user-database", "UserClickDB");
        
        var clickerApi = builder.AddProject<Projects.AspireTestApp_ClickerApi>("clickerApi")
           .WithReference(db)
           .WaitFor(db)
           .WithHttpsHealthCheck("/health", 200);


        builder.AddNpmApp("click-front", "../AspireTestApp.FrontEndOnNormalLang/click_front")
            .WithReference(clickerApi)
            .WaitFor(clickerApi)
            .WithHttpEndpoint(3001, targetPort: 3000)
            .WithExternalHttpEndpoints()
            .WithEnvironment("BROWSER", "none");

        builder.Build().Run();
    }
}