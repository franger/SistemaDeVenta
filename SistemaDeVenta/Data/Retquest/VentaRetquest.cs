namespace SistemaDeVenta.Data.Retquest
{
    public class VentaRetquest
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
    }
}
