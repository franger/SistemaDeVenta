namespace SistemaDeVenta.Data.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Dirección { get; set; } = null!;
        public string Teléfono { get; set; } = null!;
        public string? CorreoElectrónico { get; set; }

    }
}
