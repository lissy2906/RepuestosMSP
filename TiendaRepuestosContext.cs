using Microsoft.EntityFrameworkCore;

namespace RepuestosMSP.Models
{
    public class TiendaRepuestosContext : DbContext
    {
        public TiendaRepuestosContext(DbContextOptions<TiendaRepuestosContext> options)
            : base(options)
        {
        }

        public DbSet<Repuesto> Repuesto { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public decimal PrecioVenta { get; set; }

    }
}
