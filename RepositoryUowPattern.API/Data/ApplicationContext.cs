using Microsoft.EntityFrameworkCore;
using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; } = default!;
        public DbSet<Colaborador> Colaboradores { get; set; } = default!;
    }
}
