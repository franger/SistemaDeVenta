using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public interface IFacturaServices
    {
        Task<Result<List<FacturaResponse>>> Consultar(string filtro);
        Task<Result> Crear(FacturaRetquest retquest);
        Task<Result> Eliminar(FacturaRetquest retquest);
        Task<Result> Modificar(FacturaRetquest retquest);
    }
}