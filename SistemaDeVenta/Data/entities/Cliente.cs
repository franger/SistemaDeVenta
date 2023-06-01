using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;
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

    public static Cliente Crear(ClienteRetquest cliente)
    => new Cliente()
    {
        Nombre = cliente.Nombre,
        Dirección = cliente.Dirección,
        Teléfono = cliente.Teléfono,
        CorreoElectrónico = cliente.CorreoElectrónico


    };
    public bool Modificar(ClienteRetquest cliente)
    {
        var  cambio = false;
        if (Nombre != cliente.Nombre)
        {
            Nombre = cliente.Nombre;
            cambio = true;

        }
        if (Dirección != cliente.Dirección)
        {
            Dirección = cliente.Dirección;
            cambio = true;

        }
        if (Teléfono!= cliente.Teléfono)
        {
            Teléfono = cliente.Teléfono;
            cambio = true;

        }
        if (CorreoElectrónico != cliente.CorreoElectrónico)
        {
            CorreoElectrónico = cliente.CorreoElectrónico;
            cambio = true;

        }
        return cambio;
        
    }
    public ClienteResponse ToResponse()
        => new ClienteResponse()
        {
            Nombre = Nombre,
            Dirección = Dirección,
            Teléfono = Teléfono,
            CorreoElectrónico = CorreoElectrónico

        };
}
