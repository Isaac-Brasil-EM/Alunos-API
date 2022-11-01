using AlunosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosAPI.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        public readonly AlunoContext _context;
        public AlunoRepository(AlunoContext context)
        {
            _context = context;
        }

        public async Task<Aluno> Create(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();

            return aluno;
        }

        public async Task Delete(int id)
        {
            var alunoToDelete = await _context.Alunos.FindAsync(id);
            _context.Alunos.Remove(alunoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Aluno>> Get()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> Get(int id)
        {
            return await _context.Alunos.FindAsync(id);
        }

        public async Task Update(Aluno aluno)
        {
            _context.Entry(aluno).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
