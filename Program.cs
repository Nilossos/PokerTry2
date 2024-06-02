using Microsoft.Extensions.DependencyInjection;
using Poker1.Services;
using PokerTry2.Controllers;
using PokerTry2.Services;

namespace PokerTry2
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            var form1 = serviceProvider.GetRequiredService<Form1>();
            Application.Run(form1);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Form1>();
            services.AddSingleton<IGameStateService, GameStateService>();
            services.AddTransient<DealController>();
            services.AddTransient<BetController>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IDealService, DealService>();
            services.AddTransient<IBettingRoundService, BettingRoundService>();
            services.AddTransient<IDrawer, ObjectDrawer>();

            services.AddTransient(provider =>
                new Lazy<IDealService>(() => provider.GetRequiredService<DealService>()));
        }
    }
}