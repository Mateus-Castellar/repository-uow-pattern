using Microsoft.EntityFrameworkCore;
using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Departamento> Departamentos { get; set; } = default!;
        public DbSet<Colaborador> Colaboradores { get; set; } = default!;
    }
}
