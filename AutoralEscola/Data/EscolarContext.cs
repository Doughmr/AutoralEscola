using Microsoft.EntityFrameworkCore;


namespace Escolar.Data
{
    public class EscolarContext : DbContext
    {
        public EscolarContext(DbContextOptions<EscolarContext> options) : base(options) { }

        public DbSet<Alunos>? Aluno { get; set; } 
        public DbSet<Matricula>? Matriculas { get; set; }
        public DbSet<Unifoa>? Unifoa { get; set; }

    }

}