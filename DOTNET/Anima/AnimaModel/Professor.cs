using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;

namespace AnimaModel
{
    public class Professor : Usuario
    {
        
        
        [JsonPropertyName("codigo")]
        public int CodFuncionario { get; set; }

        public int TotalGrades { get; set; }

        public int TotalAlunos { get; set; }

        public double salario { get; set; }
    }
}
