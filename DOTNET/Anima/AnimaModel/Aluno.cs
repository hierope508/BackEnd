using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace AnimaModel
{
    public class Aluno : Usuario
    {
        [JsonPropertyName("ra")]
        public int RA { get; set; }
    }
}
