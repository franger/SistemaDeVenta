using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public interface IVentaServices
    {
        Task<Result<List<VentaResponse>>> Consultar(string filtro);
        Task<Result> Crear(VentaRetquest retquest);
        Task<Result> Eliminar(VentaRetquest retquest);
        Task<Result> Modificar(VentaRetquest retquest);
    }
}