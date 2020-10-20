using System;
using System.Collections.Generic;
using System.Text;

namespace PIM_Desktop_MODEL
{
    public class CarteiraModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdMoeda { get; set; }
        public decimal QuantidadeAcoes { get; set; }
    }
}
