using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace AlunosAPI.Models
{
    public enum EnumeradorSexo
    {
        Masculino = 0,
        Feminino = 1
    }
    public class Aluno
    {
        [Key]
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        //[DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        public EnumeradorSexo Sexo { get; set; }

    }
}
