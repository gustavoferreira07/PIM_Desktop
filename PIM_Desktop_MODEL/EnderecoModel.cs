using System;
using System.Collections.Generic;
using System.Text;

namespace PIM_Desktop_MODEL
{
    public class EnderecoModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
        public int IdCliente { get; set; }
    }
}
