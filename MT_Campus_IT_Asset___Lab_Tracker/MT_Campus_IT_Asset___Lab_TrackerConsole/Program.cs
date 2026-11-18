
using Microsoft.Extensions.DependencyInjection;

using MT_Campus_IT_Asset___Lab_TrackerConsole.API;
using MT_Campus_IT_Asset___Lab_TrackerConsole.Menus;

namespace CampusAssetTracker;

public class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        // Register API HTTP client
        services.AddHttpClient<AssetApiClient>(client =>
        {
            client.BaseAddress = new Uri(
                "https://localhost:7208/"
            );
        });

        // Register menu
        services.AddTransient<AssetMenu>();

        // Build dependency injection container
        var serviceProvider = services.BuildServiceProvider();

        // Get menu
        var menu = serviceProvider.GetRequiredService<AssetMenu>();

        // Run application
        await menu.Run();
    }
}
