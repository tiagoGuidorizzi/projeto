using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        services.AddHttpClient<PlayerDataService>(client =>
        {
            client.BaseAddress = new Uri("https://api.cartola.globo.com");
        });

        services.AddHangfire(config =>
            config.UseSqlServerStorage("YourConnectionStringHere"));
        services.AddHangfireServer();

        services.AddTransient<PlayerDataService>();
    })
    .Build();

using (var scope = host.Services.CreateScope())
{
    var jobService = scope.ServiceProvider.GetRequiredService<PlayerDataService>();
    RecurringJob.AddOrUpdate("FetchPlayersJob", 
        () => jobService.FetchPlayersAsync(), Cron.Hourly);
}

host.Run();
