using Microsoft.EntityFrameworkCore;
using RepuestosMSP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RepuestosMSP.Views
{
    public partial class VentasView : UserControl
    {
        private readonly RepuestosDbContext _context;
        private List<DetalleVenta> _detalles = new();

        public VentasView()
        {
            InitializeComponent();

            var optionsBuilder = new DbContextOptionsBuilder<RepuestosDbContext>();
            optionsBuilder.UseSqlServer("Server=YEISON-POLANCO\\SQLEXPRESS;Database=TiendaRepuestos;Trusted_Connection=True;TrustServerCertificate=True");
            _context = new RepuestosDbContext(optionsBuilder.Options);

            cmbClientes.ItemsSource = _context.Cliente.ToList();
            cmbClientes.DisplayMemberPath = "Nombre";
            cmbClientes.SelectedValuePath = "Id";

            dgDetalleVenta.ItemsSource = _detalles;
        }

        private void AgregarRepuesto_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new SeleccionarRepuestoWindow(_context);
            if (ventana.ShowDialog() == true)
            {
                _detalles.Add(ventana.DetalleSeleccionado);
                dgDetalleVenta.Items.Refresh();
            }
        }

        private void GuardarVenta_Click(object sender, RoutedEventArgs e)
        {
            if (cmbClientes.SelectedItem is Cliente cliente && _detalles.Any())
            {
                var venta = new Venta
                {
                    ClienteId = cliente.Id,
                    Fecha = DateTime.Now,
                    Total = _detalles.Sum(d => d.Precio * d.Cantidad),
                    Detalles = _detalles
                };

                _context.Ventas.Add(venta);


                foreach (var detalle in _detalles)
                {
                    var repuesto = _context.Repuesto.Find(detalle.Repuesto.Id);
                    repuesto.Stock -= detalle.Cantidad; 
                }

                _context.SaveChanges();

                MessageBox.Show("Venta guardada con éxito");
                _detalles.Clear();
                dgDetalleVenta.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Seleccione un cliente y agregue al menos un repuesto.");
            }
        }
    }
}
