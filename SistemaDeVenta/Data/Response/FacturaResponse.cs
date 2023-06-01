namespace SistemaDeVenta.Data.Response
{
    public class FacturaResponse
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; }
        public decimal Total { get; set; }
    }
}
