namespace SistemaDeVenta.Data.Retquest
{
    public class ProductoRetquest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripción { get; set; }
        public decimal Precio { get; set; }
        public string UnidadDeMedida { get; set; }
        public int Existencias { get; set; }
    }
}
