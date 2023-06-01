namespace SistemaDeVenta.Data.Retquest
{
    public class FacturaRetquest
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public List<Producto> Productos { get; set; }
        public decimal Total { get; set; }
    }
}
