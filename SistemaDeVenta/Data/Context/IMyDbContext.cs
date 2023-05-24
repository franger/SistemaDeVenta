using Microsoft.EntityFrameworkCore;

namespace SistemaDeVenta.Data.Context
{
    public interface IMyDbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Empleado> empleados { get; set; }
        public DbSet<Factura> facturas { get; set; }
        public DbSet<DetalleDeVenta> detalleDeVentas { get; set; }
        public DbSet<Producto> productos { get; set; }
        public DbSet<Proveedor> proveedors { get; set; }
        public DbSet<Venta> ventas { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}