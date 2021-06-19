using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anima
{
    public partial class TbProfessor
    {
        public TbProfessor()
        {
            TbGrade = new HashSet<TbGrade>();
        }

        [JsonPropertyName("codigo")]
        public int CodFuncionario { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }

        [JsonIgnore]
        public virtual TbUsuario CpfNavigation { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<TbGrade> TbGrade { get; set; }
    }
}
