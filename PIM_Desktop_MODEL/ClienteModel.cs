using System;
using System.Collections.Generic;
using System.Text;

namespace PIM_Desktop_MODEL
{
    public class ClienteModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public int IdPlano { get; set; }
    }
}
