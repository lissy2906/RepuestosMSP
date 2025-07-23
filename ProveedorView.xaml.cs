using Microsoft.EntityFrameworkCore;
using RepuestosMSP.Models;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RepuestosMSP.Views
{
    public partial class ProveedorView : UserControl
    {
        private readonly RepuestosDbContext _context;

        public ProveedorView()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<RepuestosDbContext>();
            optionsBuilder.UseSqlServer("Server=YEISON-POLANCO\\SQLEXPRESS;Database=TiendaRepuestos;Trusted_Connection=True;TrustServerCertificate=True");

            _context = new RepuestosDbContext(optionsBuilder.Options);

            CargarProveedores();
        }

        private void CargarProveedores()
        {
            dgProveedores.ItemsSource = _context.Proveedor.ToList();
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            var proveedor = new Proveedor
            {
                Nombre = txtNombre.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text
            };

            _context.Proveedor.Add(proveedor);
            _context.SaveChanges();
            CargarProveedores();

            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
        }
    }
}

