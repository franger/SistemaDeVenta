using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public interface IDetalleDeVentaServices
    {
        Task<Result<List<DetalleDeVentaResponse>>> Consultar(string filtro);
        Task<Result> Crear(DetalleDeVentaRetquest retquest);
        Task<Result> Eliminar(DetalleDeVentaRetquest retquest);
        Task<Result> Modificar(DetalleDeVentaRetquest retquest);
    }
}