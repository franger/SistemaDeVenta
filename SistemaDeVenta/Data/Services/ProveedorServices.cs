using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public class ProveedorServices : IProveedorServices
    {
        private readonly IMyDbContext dbContext;

        public ProveedorServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(ProveedorRetquest retquest)
        {
            try
            {
                var proveedor = Proveedor.Crear(retquest);
                dbContext.proveedors.Add(proveedor);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Modificar(ProveedorRetquest retquest)
        {
            try
            {
                var proveedor = await dbContext.proveedors
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (proveedor == null)
                    return new Result() { Message = "No se encontro el proveedor", Success = false };


                if (proveedor.Modificar(retquest))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Eliminar(ProveedorRetquest retquest)
        {
            try
            {
                var proveedor = await dbContext.proveedors
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (proveedor == null)
                    return new Result() { Message = "No se encontro el proveedor", Success = false };


                dbContext.proveedors.Remove(proveedor);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result<List<ProveedorResponse>>> Consultar(string filtro)
        {
            try
            {
                var proveedor = await dbContext.proveedors
                    .Where(c =>
                    (c.Nombre + " " + c.Dirección + " " + c.Teléfono + " " + c.CorreoElectrónico)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<ProveedorResponse>>()
                {
                    Message = "ok",
                    Success = true,
                    Data = proveedor
                };

            }
            catch (Exception E)
            {
                return new Result<List<ProveedorResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
