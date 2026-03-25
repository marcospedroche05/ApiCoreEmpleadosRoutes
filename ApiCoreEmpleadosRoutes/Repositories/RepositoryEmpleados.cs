using ApiCoreEmpleadosRoutes.Data;
using ApiCoreEmpleadosRoutes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreEmpleadosRoutes.Repositories
{
    public class RepositoryEmpleados
    {
        private EmpleadoContext context;

        public RepositoryEmpleados(EmpleadoContext context)
        {
            this.context = context;
        }

        public async Task<List<Empleado>> GetEmpleadosAsync()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return await consulta.ToListAsync();
        }

        public async Task<Empleado> FindEmpleadoAsync(int id)
        {
            return await this.context.Empleados
                .FirstOrDefaultAsync(x => x.IdEmpleado == id);
        }
    }
}
