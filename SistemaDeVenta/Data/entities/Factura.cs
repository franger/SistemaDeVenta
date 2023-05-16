// Clase Clientes

// Clase Productos
// Clase Facturas
public class Factura
{
    public int Id { get; set; }
    public DateTime Fecha { get; set; }
    public Cliente Cliente { get; set; }
    public List<Producto> Productos { get; set; }
    public decimal Total { get; set; }
}
