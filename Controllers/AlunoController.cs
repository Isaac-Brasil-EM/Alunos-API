using AlunosAPI.Models;
using AlunosAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AlunosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;
        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]

        public IEnumerable<Aluno> GetAlunos()
        {
            return _alunoRepository.Get().ToList();

        }

        [HttpGet("{id}")]
        public ActionResult<Aluno> GetAlunos(int id)
        {
            return _alunoRepository.Get(id);
        }

        [HttpPost]
        public void PostAlunos([FromBody] Aluno aluno)
        {
            if (ModelState.IsValid == true)
            {
                _alunoRepository.Add(aluno);
            }
            else
            {

            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {

            if (ModelState.IsValid == true)
            {
                _alunoRepository.Remove(id);
            }
        }

        [HttpPut("{id}")]

        public void PutAlunos(int id, [FromBody] Aluno aluno)
        {
            if (ModelState.IsValid == true)
            {
                _alunoRepository.Update(id, aluno);
            }

        }

    }
}
