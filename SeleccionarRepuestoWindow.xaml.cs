using RepuestosMSP.Models;
using System;
using System.Linq;
using System.Windows;

namespace RepuestosMSP.Views
{
    public partial class SeleccionarRepuestoWindow : Window
    {
        private readonly RepuestosDbContext _context;
        public DetalleVenta DetalleSeleccionado { get; private set; }

        public SeleccionarRepuestoWindow(RepuestosDbContext context)
        {
            InitializeComponent();
            _context = context;

            cmbRepuestos.ItemsSource = _context.Repuesto.Where(r => r.Stock > 0).ToList();
            cmbRepuestos.DisplayMemberPath = "Nombre";
            cmbRepuestos.SelectedValuePath = "Id";
        }

        private void Aceptar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbRepuestos.SelectedItem is Repuesto repuesto &&
                int.TryParse(txtCantidad.Text, out int cantidad) &&
                cantidad > 0 && cantidad <= repuesto.Stock)
            {
                DetalleSeleccionado = new DetalleVenta
                {
                    Repuesto = repuesto,
                    RepuestoId = repuesto.Id,
                    Cantidad = cantidad,
                    PrecioVenta = repuesto.PrecioVenta,
                };

                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Verifica el repuesto y la cantidad válida.");
            }
        }
    }
}
