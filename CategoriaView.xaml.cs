using Microsoft.EntityFrameworkCore;
using RepuestosMSP.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RepuestosMSP.Views
{
    public partial class CategoriaView : UserControl
    {
        private readonly RepuestosDbContext _context;

        public CategoriaView()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<RepuestosDbContext>();
            optionsBuilder.UseSqlServer("Server=YEISON-POLANCO\\SQLEXPRESS;Database=TiendaRepuestos;Trusted_Connection=True;TrustServerCertificate=True");

            _context = new RepuestosDbContext(optionsBuilder.Options);
        }

        private void CargarCategorias()
        {
            dgCategorias.ItemsSource = _context.Categoria.ToList();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            var categoria = new Categoria { Nombre = txtNombre.Text };

            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            CargarCategorias();

            txtNombre.Clear();
        }
    }
}

