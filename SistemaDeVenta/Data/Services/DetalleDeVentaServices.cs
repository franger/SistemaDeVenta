using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{

    public class DetalleDeVentaServices : IDetalleDeVentaServices
    {
        private readonly IMyDbContext dbContext;

        public DetalleDeVentaServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(DetalleDeVentaRetquest retquest)
        {
            try
            {
                var detalleDeVenta = DetalleDeVenta.Crear(retquest);
                dbContext.detalleDeVentas.Add(detalleDeVenta);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Modificar(DetalleDeVentaRetquest retquest)
        {
            try
            {
                var detalleDeVenta = await dbContext.detalleDeVentas
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (detalleDeVenta == null)
                    return new Result() { Message = "No se encontro el detalle de la venta", Success = false };


                if (detalleDeVenta.Modificar(retquest))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Eliminar(DetalleDeVentaRetquest retquest)
        {
            try
            {
                var detalleDeVenta = await dbContext.detalleDeVentas
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (detalleDeVenta == null)
                    return new Result() { Message = "No se encontro los detalle", Success = false };


                dbContext.detalleDeVentas.Remove(detalleDeVenta);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result<List<DetalleDeVentaResponse>>> Consultar(string filtro)
        {
            try
            {
                var detalleDeVentas = await dbContext.detalleDeVentas
                    .Where(c =>
                    (c.Venta + " " + c.Producto + " " + c.Cantidad + " " + c.Precio)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<DetalleDeVentaResponse>>()
                {
                    Message = "ok",
                    Success = true,
                    Data = detalleDeVentas
                };

            }
            catch (Exception E)
            {
                return new Result<List<DetalleDeVentaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
