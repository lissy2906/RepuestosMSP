using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; 
using System.Windows;
using RepuestosMSP.Views;
using RepuestosMSP.Models;

namespace RepuestosMSP
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        private IServiceCollection _services;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            _services = new ServiceCollection();
            ConfigureServices(_services); 
            ServiceProvider = _services.BuildServiceProvider();

            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<TiendaRepuestosContext>(options =>
                options.UseSqlServer("Server=YEISON-POLANCO\\SQLEXPRESS;Database=TiendaRepuestos;Trusted_Connection=True;TrustServerCertificate=True")); 

            services.AddSingleton<MainWindow>();
            services.AddTransient<RepuestosView>();
            services.AddTransient<ClientesView>();
            services.AddTransient<VentasView>();
            services.AddTransient<ProveedorView>();
            services.AddTransient<CategoriaView>();
        }
    }
}



