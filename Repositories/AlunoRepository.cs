using AlunosAPI.Models;
using FirebirdSql.Data.FirebirdClient;
using Microsoft.EntityFrameworkCore;
using MVCAlunos.Data.Banco;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace AlunosAPI.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private static string User = "SYSDBA";
        private static string Password = "masterkey";
        private static string Database = "localhost:D:\\DBALUNO.fdb";
        private static int Port = 3054;
        private static string Dialect = "3";
        private static string Charset = FbCharset.None.ToString();


        FbConnectionStringBuilder conn = new FbConnectionStringBuilder()
        {
            Port = Port,
            Password = Password,
            Database = Database,
            UserID = User,
            Charset = Charset,

        };
        public bool Add(Aluno aluno)
        {
            string query = "insert into TBALUNO values('" + aluno.Matricula + "','" + aluno.Nome + "','" + aluno.Cpf + "'," + aluno.Nascimento + ",'" + (int)aluno.Sexo + "')";
            using (var con = new FbConnection(conn.ToString()))
            {
                con.Open();

                using (var transaction = con.BeginTransaction())
                {
                    using (var command = new FbCommand(query, con, transaction))
                    {
                        command.Connection = con;
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        int i = command.ExecuteNonQuery();
                        if (i >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }
        }



        public bool Remove(int id)
        {
            string query = "delete from TBALUNO where MATRICULA='" + id + "'";
            using (var con = new FbConnection(conn.ToString()))
            {
                con.Open();

                using (var transaction = con.BeginTransaction())
                {
                    using (var command = new FbCommand(query, con, transaction))
                    {
                        command.Connection = con;
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        int i = command.ExecuteNonQuery();
                        if (i >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }

                }
            }
        }

        public IEnumerable<Aluno> Get()
        {
            List<Aluno> list = new List<Aluno>();
            string query = "Select * from TBALUNO ";
            using (var con = new FbConnection(conn.ToString()))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {

                    using (var command = new FbCommand(query, con, transaction))
                    {
                        command.Connection = con;
                        FbDataAdapter fbda = new(command);
                        DataTable dt = new DataTable();
                        fbda.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            list.Add(new Aluno { Matricula = Convert.ToInt32(dr[0]), Nome = Convert.ToString(dr[1]), Cpf = Convert.ToString(dr[2]), Nascimento = Convert.ToDateTime(dr[3]), Sexo = (EnumeradorSexo)Convert.ToInt32(dr[4]) });
                        }
                    }

                }
            }
            return list;
        }

        public Aluno Get(int id)
        {
       

            List<Aluno> list = new List<Aluno>();
            string query = $"select * from TBALUNO WHERE TBALUNO.MATRICULA = {id}";
            using (var con = new FbConnection(conn.ToString()))
            {
                con.Open();
                using (var transaction = con.BeginTransaction())
                {

                    using (var command = new FbCommand(query, con, transaction))
                    {
                        command.Connection = con;
                        FbDataAdapter fbda = new(command);
                        DataTable dt = new DataTable();
                        fbda.Fill(dt);
                        foreach (DataRow dr in dt.Rows)
                        {
                            list.Add(new Aluno { Matricula = Convert.ToInt32(dr[0]), Nome = Convert.ToString(dr[1]), Cpf = Convert.ToString(dr[2]), Nascimento = Convert.ToDateTime(dr[3]), Sexo = (EnumeradorSexo)Convert.ToInt32(dr[4]) });
                        }
                    }

                }
            }
            return list.FirstOrDefault();



        }

        public bool Update(int id, Aluno aluno)
        {
            string query = "update TBALUNO set Nome= '" + aluno.Nome + "', Matricula='" + aluno.Matricula + "', Cpf='" + aluno.Cpf + "', Nascimento ='" + aluno.Nascimento.Date + "', Sexo ='" + (int)aluno.Sexo + "' where Matricula ='" + id + "' ";
            using (var con = new FbConnection(conn.ToString()))
            {
                con.Open();


                using (var transaction = con.BeginTransaction())
                {

                    using (var command = new FbCommand(query, con, transaction))
                    {
                        command.Connection = con;

                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        int i = command.ExecuteNonQuery();

                        if (i >= 1)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }



            /*aluno.Matricula = id;
            var dt = CONNECTAR.RetornoTabela($"SELECT * FROM TBALUNO WHERE TBALUNO.MATRICULA = {id}");
            List<Aluno> Listar_alunos = Aluno.ListarTabela(dt);
            return Listar_alunos.FirstOrDefault();

            return aluno;*/

        }
    }
}
