// Clase Clientes

// Clase Productos

// Clase Facturas

// Clase Empleados
// Clase Venta (Facturas)
public class Venta
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public Cliente Cliente { get; set; }
    public decimal Total { get; set; }
}
