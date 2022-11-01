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
        public async Task<IEnumerable<Aluno>> GetAlunos()
        {
            return await _alunoRepository.Get();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> GetAlunos(int id)
        {
            return await _alunoRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Aluno>> PostAlunos([FromBody] Aluno aluno)
        {
            var newAluno = await _alunoRepository.Create(aluno);
            return CreatedAtAction(nameof(GetAlunos), new {id = newAluno.Matricula}, newAluno);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var alunoToDelete = await _alunoRepository.Get(id);
            if (alunoToDelete == null)
                return NotFound();

            await _alunoRepository.Delete(alunoToDelete.Matricula);
            return NoContent();

        }
        [HttpPut]

        public async Task<ActionResult> PutAlunos(int id, [FromBody] Aluno aluno)
        {
            if (id != aluno.Matricula)
                return BadRequest();

            await _alunoRepository.Update(aluno);

            return NoContent();

        }

    }
}
