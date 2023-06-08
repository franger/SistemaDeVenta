using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public interface IEmpleadoServices
    {
        Task<Result<List<EmpleadoResponse>>> Consultar(string filtro);
        Task<Result> Crear(EmpleadoRetquest retquest);
        Task<Result> Eliminar(EmpleadoRetquest retquest);
        Task<Result> Modificar(EmpleadoRetquest retquest);
    }
}