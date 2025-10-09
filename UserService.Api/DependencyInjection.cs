using Serilog;

namespace UserService.Api;

public static class DependencyInjection
{
    public static void AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(builder.Configuration) 
            .Enrich.FromLogContext()                       
            .WriteTo.Console()                             
            .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day) 
            .CreateLogger();

        builder.Host.UseSerilog();
    }
}
