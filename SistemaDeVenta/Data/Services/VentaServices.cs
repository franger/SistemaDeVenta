using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;
using SistemaDeVenta.Data.Services;

namespace SistemaDeVenta.Data.Services
{
    public class VentaServices : IVentaServices
    {
        private readonly IMyDbContext dbContext;

        public VentaServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(VentaRetquest retquest)
        {
            try
            {
                var venta = Venta.Crear(retquest);
                dbContext.ventas.Add(venta);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Modificar(VentaRetquest retquest)
        {
            try
            {
                var venta = await dbContext.ventas
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (venta == null)
                    return new Result() { Message = "No se encontro la venta", Success = false };


                if (venta.Modificar(retquest))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Eliminar(VentaRetquest retquest)
        {
            try
            {
                var venta = await dbContext.ventas
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (venta == null)
                    return new Result() { Message = "No se encontro la venta", Success = false };


                dbContext.ventas.Remove(venta);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result<List<VentaResponse>>> Consultar(string filtro)
        {
            try
            {
                var venta = await dbContext.ventas
                    .Where(c =>
                    (c.Fecha + " " + c.Cliente + " " + c.Total)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<VentaResponse>>()
                {
                    Message = "ok",
                    Success = true,
                    Data = venta
                };

            }
            catch (Exception E)
            {
                return new Result<List<VentaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
