using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Anima
{
    public partial class TbGrade
    {
        public TbGrade()
        {
            InverseCodParentGradeNavigation = new HashSet<TbGrade>();
            TbMatricula = new HashSet<TbMatricula>();
        }

        [JsonPropertyName("codGrade")]
        public int CodGrade { get; set; }

        [JsonPropertyName("turma")]
        public string NomeTurma { get; set; }

        [JsonPropertyName("disciplina")]
        public string NomeDisciplina { get; set; }

        [JsonPropertyName("curso")]
        public string NomeCurso { get; set; }

        [JsonPropertyName("codFuncionario")]
        public int CodFuncionario { get; set; }

        [JsonIgnore]
        public int? CodParentGrade { get; set; }

        [JsonIgnore]
        public virtual TbProfessor CodFuncionarioNavigation { get; set; }
        
        [JsonIgnore]
        public virtual TbGrade CodParentGradeNavigation { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<TbGrade> InverseCodParentGradeNavigation { get; set; }
        
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<TbMatricula> TbMatricula { get; set; }
    }
}
