using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public interface IProductoServices
    {
        Task<Result<List<ProductoResponse>>> Consultar(string filtro);
        Task<Result> Crear(ProductoRetquest retquest);
        Task<Result> Eliminar(ProductoRetquest retquest);
        Task<Result> Modificar(ProductoRetquest retquest);
    }
}