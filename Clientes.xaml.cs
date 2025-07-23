using System.Collections.Generic;
using System.Windows.Controls;
using RepuestosMSP.Models;
using RepuestosMSP.servicios;

namespace RepuestosMSP.Views
{
    public partial class ClientesView : UserControl
    {
        private ClienteService clienteService;

        public ClientesView()
        {
            InitializeComponent();
            clienteService = new ClienteService();
            CargarClientes();
        }

        private void CargarClientes()
        {
            List<RepuestosMSP.Models.Clientes> clientes = clienteService.ObtenerTodos();
            dgClientes.ItemsSource = clientes;
        }
    }
}



