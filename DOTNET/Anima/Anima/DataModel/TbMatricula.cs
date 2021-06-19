using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anima
{
    public partial class TbMatricula
    {
        [JsonPropertyName("ra")]
        public int Ra { get; set; }

        [JsonPropertyName("codGrade")]
        public int CodGrade { get; set; }

        public virtual TbGrade CodGradeNavigation { get; set; }
        public virtual TbAluno RaNavigation { get; set; }
    }
}
