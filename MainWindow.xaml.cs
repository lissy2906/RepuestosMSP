using Microsoft.Extensions.DependencyInjection;
using RepuestosMSP.Models;
using RepuestosMSP.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace RepuestosMSP
{
    public partial class MainWindow : Window
    {
        private readonly TiendaRepuestosContext _context;

        public MainWindow()
        {
            InitializeComponent();
            _context = App.ServiceProvider.GetRequiredService<TiendaRepuestosContext>();
            MostrarVistaInicial();
        }

        private void MostrarVistaInicial()
        {
            MainContent.Content = new RepuestosView();
        }

        private void CargarCategorias()
        {
            var categorias = _context.Categoria.ToList();
            foreach (var cat in categorias)
            {
                MessageBox.Show(cat.Nombre);
            }
        }

        private void BtnRepuestos_Click(object sender, RoutedEventArgs e)
        {
            var ventana = App.ServiceProvider.GetRequiredService<RepuestosView>();
        }

        private void BtnClientes_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ClientesView();
        }

        private void BtnVentas_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new VentasView();
        }

        private void BtnProveedores_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ProveedorView();
        }

        private void BtnCategorias_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new CategoriaView();
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

