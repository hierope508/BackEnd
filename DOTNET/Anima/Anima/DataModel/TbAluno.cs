using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Anima
{
    public partial class TbAluno
    {
        public TbAluno()
        {
            TbMatricula = new HashSet<TbMatricula>();
        }

        [JsonPropertyName("ra")]
        public int Ra { get; set; }

        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }


        [JsonIgnore]
        public virtual TbUsuario CpfNavigation { get; set; }

        [NotMapped]
        public virtual ICollection<TbMatricula> TbMatricula { get; set; }

    }
}
