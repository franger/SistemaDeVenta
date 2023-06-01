namespace SistemaDeVenta.Data.Response
{
    public class VentaResponse
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente Cliente { get; set; }
        public decimal Total { get; set; }
    }
}
