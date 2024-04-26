using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using Piasecki.Electronics.DAO;

namespace Piasecki.Electronics.UI
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }  = null!;
        public IConfiguration Configuration { get; private set; }  = null!;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 21))));

            ServiceProvider = services.BuildServiceProvider();
        }
    }
}