using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public class ProductoServices : IProductoServices
    {
        private readonly IMyDbContext dbContext;

        public ProductoServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(ProductoRetquest retquest)
        {
            try
            {
                var producto = Producto.Crear(retquest);
                dbContext.productos.Add(producto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Modificar(ProductoRetquest retquest)
        {
            try
            {
                var producto = await dbContext.productos
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (producto == null)
                    return new Result() { Message = "No se encontro el producto", Success = false };


                if (producto.Modificar(retquest))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Eliminar(ProductoRetquest retquest)
        {
            try
            {
                var producto = await dbContext.productos
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (producto == null)
                    return new Result() { Message = "No se encontro el producto", Success = false };


                dbContext.productos.Remove(producto);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result<List<ProductoResponse>>> Consultar(string filtro)
        {
            try
            {
                var producto = await dbContext.productos
                    .Where(c =>
                    (c.Nombre + " " + c.Descripción + " " + c.Precio + " " + c.UnidadDeMedida + " " + c.Existencias)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<ProductoResponse>>()
                {
                    Message = "ok",
                    Success = true,
                    Data = producto
                };

            }
            catch (Exception E)
            {
                return new Result<List<ProductoResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
