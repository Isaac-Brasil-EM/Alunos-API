using AlunosAPI.Models;

namespace AlunosAPI.Repositories
{
    public interface IAlunoRepository
    {
        IEnumerable<Aluno> Get();
        Aluno Get(int Id);
        bool Add(Aluno aluno);
        bool Update(int Id, Aluno aluno);
        bool Remove(int Id);

    }
}
