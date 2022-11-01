using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Models
{
    public class AlunoContext : DbContext
    {
        public AlunoContext(DbContextOptions<AlunoContext> options)
      : base(options) { 
            Database.EnsureCreated();
        }

        public DbSet<Aluno> Alunos {get; set;}
    }
}
