namespace RepositoryUowPattern.API.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string? Descricao { get; set; }

        //EfCore Relational
        public List<Colaborador>? Colaboradores { get; set; }

    }
}
