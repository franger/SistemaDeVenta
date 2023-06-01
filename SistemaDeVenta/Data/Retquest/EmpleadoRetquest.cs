namespace SistemaDeVenta.Data.Retquest
{
    public class EmpleadoRetquest
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NúmeroDeIdentificación { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public decimal Salario { get; set; }
        public string HorarioDeTrabajo { get; set; }
    }
}
