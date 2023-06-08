using Microsoft.EntityFrameworkCore;
using SistemaDeVenta.Data.Context;
using SistemaDeVenta.Data.Response;
using SistemaDeVenta.Data.Retquest;

namespace SistemaDeVenta.Data.Services
{
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly IMyDbContext dbContext;

        public EmpleadoServices(IMyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Result> Crear(EmpleadoRetquest retquest)
        {
            try
            {
                var empleado = Empleado.Crear(retquest);
                dbContext.empleados.Add(empleado);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Modificar(EmpleadoRetquest retquest)
        {
            try
            {
                var empleado = await dbContext.empleados
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);

                if (empleado == null)
                    return new Result() { Message = "No se encontro el empleado", Success = false };


                if (empleado.Modificar(retquest))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result> Eliminar(EmpleadoRetquest retquest)
        {
            try
            {
                var empleado = await dbContext.empleados
                    .FirstOrDefaultAsync(c => c.Id == retquest.Id);
                if (empleado == null)
                    return new Result() { Message = "No se encontro el empleado", Success = false };


                dbContext.empleados.Remove(empleado);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "ok", Success = true };
            }
            catch (Exception E)
            {
                return new Result() { Message = E.Message, Success = false };


            }
        }
        public async Task<Result<List<EmpleadoResponse>>> Consultar(string filtro)
        {
            try
            {
                var empleado = await dbContext.empleados
                    .Where(c =>
                    (c.Nombre + " " + c.NúmeroDeIdentificación + " "
                    + c.Cargo + " " + c.FechaDeIngreso + " "
                    + c.Salario + " " + c.HorarioDeTrabajo)
                    .ToLower()
                    .Contains(filtro.ToLower()))
                    .Select(c => c.ToResponse())
                    .ToListAsync();
                return new Result<List<EmpleadoResponse>>()
                {
                    Message = "ok",
                    Success = true,
                    Data = empleado
                };

            }
            catch (Exception E)
            {
                return new Result<List<EmpleadoResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }


    }
}
