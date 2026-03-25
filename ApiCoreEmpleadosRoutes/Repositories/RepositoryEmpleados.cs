using ApiCoreEmpleadosRoutes.Data;
using Microsoft.EntityFrameworkCore;
using NugetApiModels.Models;

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

        public async Task<List<string>> GetOficiosAsync()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return await consulta.ToListAsync();
        }

        public async Task<List<Empleado>> GetEmpleadosOficioAsync(string oficio) {
            return await this.context.Empleados.Where(x => x.Oficio == oficio).ToListAsync();
        }
        
        public async Task<List<Empleado>> GetEmpleadosSalarioIdDeptAsync(int salario, int iddept)
        {
            //TAMBIEN SE PUEDE HACER EL && CON EL .WHERE()
            var consulta = from datos in this.context.Empleados
                           where datos.Salario >= salario && datos.IdDepartamnto == iddept
                           select datos;
            return await consulta.ToListAsync();
        }

    }
}
