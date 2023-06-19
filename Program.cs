using Microsoft.Extensions.DependencyInjection;
using Sender.Services;


public class Program
{
    private static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var publisher = serviceProvider.GetRequiredService<IPublisher>();
        var cts = new CancellationTokenSource();

        publisher.Publish(cts.Token);

        Console.ReadLine();
    }

    private static void ConfigureServices(IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IPublisher, Publisher>();
    }
}
