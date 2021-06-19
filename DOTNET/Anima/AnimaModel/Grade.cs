
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace AnimaModel
{
    public class Grade
    {
        public int CodGrade { get; set; }

        [JsonIgnore]
        public int? CodParentGrade { get; set; }
        public String Turma { get; set; }

        public String Disciplina { get; set; }

        public String Curso { get; set; }

        public int CodFuncionario { get; set; }

        public string NomeProfessor { get; set; }

        public string CpfProfessor { get; set; }

        public string EmailProfessor { get; set; }

        public List<AlunoGrade> Alunos { get; set; }

        public Grade()
        {
            this.Alunos = new List<AlunoGrade>();
        }
    }
}
