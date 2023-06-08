using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public class FacturaServices : IFacturaServices
    {
        private readonly IMyDbContext dbContext;

        public FacturaServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(FacturaRetquest retquest)
        {
            try
            {
                var factura = Factura.Crear(retquest);
                dbContext.facturas.Add(factura);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Modificar(FacturaRetquest retquest)
        {
            try
            {
                var factura = await dbContext.facturas
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (factura == null)
                    return new Result() { Message = "la factura no se has encontrado", Success = false };


                if (factura.Modificar(retquest))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Eliminar(FacturaRetquest retquest)
        {
            try
            {
                var factura = await dbContext.facturas
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (factura == null)
                    return new Result() { Message = "No se encontro la factuta", Success = false };


                dbContext.facturas.Remove(factura);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result<List<FacturaResponse>>> Consultar(string filtro)
        {
            try
            {
                var factura = await dbContext.facturas
                    .Where(c =>
                    (c.Fecha + " " + c.Cliente + " " + c.Productos + " " + c.Total)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<FacturaResponse>>()
                {
                    Message = "ok",
                    Success = true,
                    Data = factura
                };

            }
            catch (Exception E)
            {
                return new Result<List<FacturaResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
