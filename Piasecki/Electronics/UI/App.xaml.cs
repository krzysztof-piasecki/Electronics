using System.IO;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Piasecki.Electronics.BL;
using Piasecki.Electronics.DAO;
using Piasecki.Electronics.DAO.REPOSITORIES;
using Prism.Ioc;
using Prism.Unity;

namespace Piasecki.Electronics.UI
{
    public partial class App : PrismApplication
    {
        public IConfiguration Configuration { get; private set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<AppDbContext>(containerProvider =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                optionsBuilder.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 21)));
                return new AppDbContext(optionsBuilder.Options);
            });

            containerRegistry.Register<Repository>();
            containerRegistry.Register<ProductService>();
            containerRegistry.Register<PhoneService>();
            containerRegistry.Register<LaptopService>();
            containerRegistry.Register<GPUService>();
            containerRegistry.Register<DisplayMonitorService>();
            containerRegistry.RegisterSingleton<MainWindow>();
        }

        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow = Container.Resolve<MainWindow>();
            MainWindow.Show();
        }
    }
}