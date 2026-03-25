using ApiCoreEmpleadosRoutes.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCoreEmpleadosRoutes.Data
{
    public class EmpleadoContext: DbContext
    {
        public EmpleadoContext(DbContextOptions<EmpleadoContext> options): base(options)
        {
        }

        public DbSet<Empleado> Empleados { get; set; }
    }
}
