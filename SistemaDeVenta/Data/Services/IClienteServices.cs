using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public interface IClienteServices
    {
        Task<Result<List<ClienteResponse>>> Consultar(string filtro);
        Task<Result> Crear(ClienteRetquest retquest);
        Task<Result> Eliminar(ClienteRetquest retquest);
        Task<Result> Modificar(ClienteRetquest retquest);
    }
}