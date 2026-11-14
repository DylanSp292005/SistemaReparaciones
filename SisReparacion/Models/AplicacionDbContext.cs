
using Microsoft.EntityFrameworkCore;

namespace SistemaReparaciones.Models
{
    public class AplicacionDbContext : DbContext
    {
        public AplicacionDbContext(
            DbContextOptions<AplicacionDbContext> options
        ) : base(options)
        {
        }

        // Tabla de clientes
        public DbSet<Cliente> Clientes { get; set; }

        // Tabla de técnicos
        public DbSet<Tecnico> Tecnicos { get; set; }

        // Tabla de electrodomésticos
        public DbSet<Electrodomestico> Electrodomesticos { get; set; }

        // Tabla de reparaciones
        public DbSet<Reparacion> Reparaciones { get; set; }
    }
}
