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
            var pokerForm = serviceProvider.GetRequiredService<Poker>();
            Application.Run(pokerForm);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<Poker>();
            services.AddSingleton<IGameStateService, GameStateService>();
            services.AddTransient<DealController>();
            services.AddTransient<BetController>();
            services.AddTransient<ReplacementController>();
            services.AddTransient<ResultController>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IDealService, DealService>();
            services.AddTransient<IReplacementService, ReplacementService>();
            services.AddTransient<IBettingRoundService, BettingRoundService>();
            services.AddTransient<IResultService, ResultService>();
            services.AddTransient<IDrawer, ObjectDrawer>();
        }
    }
}