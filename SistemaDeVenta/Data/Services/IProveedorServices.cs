using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public interface IProveedorServices
    {
        Task<Result<List<ProveedorResponse>>> Consultar(string filtro);
        Task<Result> Crear(ProveedorRetquest retquest);
        Task<Result> Eliminar(ProveedorRetquest retquest);
        Task<Result> Modificar(ProveedorRetquest retquest);
    }
}