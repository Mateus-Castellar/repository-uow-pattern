using RepositoryUowPattern.API.Models;

namespace RepositoryUowPattern.API.Data
{
    public static class InicializarBaseDeDados
    {
        public static void IniciarBaseDaDados(this WebApplication app)
        {
            using var db = app.Services.CreateScope()
                .ServiceProvider.GetRequiredService<ApplicationContext>();

            if (db.Database.EnsureCreated())
            {
                db.Departamentos.AddRange(Enumerable.Range(1, 10).Select(departamento => new Departamento
                {
                    Descricao = $"Departamento - {departamento}",
                    Colaboradores = Enumerable.Range(1, 10).Select(colaborador => new Colaborador
                    {
                        Nome = $"Colaborador {colaborador}/{departamento}"
                    }).ToList()
                }));

                db.SaveChanges();
            }
        }
    }
}
