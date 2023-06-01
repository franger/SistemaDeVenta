namespace SistemaDeVenta.Data.Retquest
{
    public class ClienteRetquest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string Teléfono { get; set; } = null!;
        public string? CorreoElectrónico { get; set; }

    }
}
