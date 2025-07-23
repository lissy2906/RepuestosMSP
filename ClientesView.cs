using System.Data.SqlClient;
using System.Windows.Controls;
using System;

namespace RepuestosMSP.Views
{
    public partial class ClienteView : UserControl
    {
        public ClienteView()
        {
            InitializeComponent();
            CargarClientesDesdeBD();
        }


        private void CargarClientesDesdeBD()
        {
            string connectionString = "Server=YEISON-POLANCO\\SQLEXPRESS;Database=TiendaRepuestos;Trusted_Connection=True;TrustServerCertificate=True";
            string query = "SELECT IdCliente, Nombre, Telefono FROM Cliente";

            List<Cliente> clientes = new List<Cliente>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        IdCliente = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Telefono = reader.GetString(2)
                    });
                }
            }

            dgCliente.ItemsSource = clientes;
        }
    }
    
        public class Cliente
    {
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public int Id { get; internal set; }
    }
}
