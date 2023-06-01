namespace SistemaDeVenta.Data.Retquest
{
    public class DetalleDeVentaRetquest
    {
        public int Id { get; set; }
        public Venta Venta { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
    }
}
