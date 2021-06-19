using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Anima
{
    public partial class TbUsuario
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public byte[] Senha { get; set; }

        [JsonIgnore]
        public virtual TbAluno TbAluno { get; set; }

        [JsonIgnore]
        public virtual TbProfessor TbProfessor { get; set; }
    }
}
