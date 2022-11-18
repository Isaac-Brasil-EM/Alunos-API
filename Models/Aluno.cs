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

        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        public EnumeradorSexo Sexo { get; set; }


        public static List<Aluno> ListarTabela(DataTable dt)
        {
            List<Aluno> lista = new();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Aluno alunos = new()
                {
                    Matricula = (int)dt.Rows[i]["MATRICULA"],
                    Nome = dt.Rows[i]["NOME"].ToString(),
                    Cpf = dt.Rows[i]["CPF"].ToString(),
                    Nascimento = (DateTime)dt.Rows[i]["NASCIMENTO"],
                    Sexo = (EnumeradorSexo)(int)dt.Rows[i]["SEXO"],

                };
                lista.Add(alunos);
            }

            return lista;
        }
    }
}
