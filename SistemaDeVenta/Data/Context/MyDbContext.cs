using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using System.Runtime.CompilerServices;

namespace SistemaDeVenta.Data.Context
{

    public class MyDbContext : DbContext, IMyDbContext
    {
        

        private readonly IConfiguration config;
        public MyDbContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Factura> facturas { get; set; }
        public DbSet<DetalleDeVenta> detalleDeVentas { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Proveedor> proveedors{ get; set; }
        public DbSet<Venta> ventas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString(name: "MSSQL"));
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
