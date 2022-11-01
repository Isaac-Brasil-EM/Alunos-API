﻿using System.ComponentModel.DataAnnotations;

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
        public DateTime Nascimento { get; set; }
        public EnumeradorSexo Sexo { get; set; }
    }
}