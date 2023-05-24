// Clase Clientes

// Clase Productos

// Clase Facturas

// Clase Empleados
// Clase Venta (Facturas)
using System.ComponentModel.DataAnnotations;

public class Venta
{
    [Key]
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public Cliente Cliente { get; set; }
    public decimal Total { get; set; }
}
