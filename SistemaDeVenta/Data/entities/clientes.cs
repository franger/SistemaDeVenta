using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeVenta.Data.entities
{

}
// Clase Clientes
public class Cliente
{
    [Key]
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public string Dirección { get; set; } = null!;
    public string Teléfono { get; set; } = null!;
    public string? CorreoElectrónico { get; set; } 
}
