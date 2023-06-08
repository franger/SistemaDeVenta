using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;



namespace SistemaDeVenta.Data.Services
{
    public class Result
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
    }
    public class Result<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }
    }
    public class ClienteServices : IClienteServices
    {
        private readonly IMyDbContext dbContext;

        public ClienteServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(ClienteRetquest retquest)
        {
            try
            {
                var cliente = Cliente.Crear(retquest);
                dbContext.clientes.Add(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Modificar(ClienteRetquest retquest)
        {
            try
            {
                var cliente = await dbContext.clientes
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (cliente == null)
                    return new Result() { Message = "No se encontro el cliente", Success = false };


                if (cliente.Modificar(retquest))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Eliminar(ClienteRetquest retquest)
        {
            try
            {
                var cliente = await dbContext.clientes
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (cliente == null)
                    return new Result() { Message = "No se encontro el cliente", Success = false };


                dbContext.clientes.Remove(cliente);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result<List<ClienteResponse>>> Consultar(string filtro)
        {
            try
            {
                var cliente = await dbContext.clientes
                    .Where(c =>
                    (c.Nombre + " " + c.Dirección + " " + c.Teléfono + " " + c.CorreoElectrónico)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<ClienteResponse>>()
                {
                    Message = "ok",
                    Success = true,
                    Data = cliente
                };

            }
            catch (Exception E)
            {
                return new Result<List<ClienteResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }

    }
}
