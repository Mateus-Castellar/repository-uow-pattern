namespace RepositoryUowPattern.API.Models
{
    public class Colaborador
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int DepartamentoId { get; set; }

        //EfCore Relational
        public Departamento? Departamento { get; set; }
    }
}
