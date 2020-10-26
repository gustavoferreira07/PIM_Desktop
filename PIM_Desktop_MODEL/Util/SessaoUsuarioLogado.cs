using System;
using System.Collections.Generic;
using System.Text;

namespace PIM_Desktop_MODEL.Util
{
    public class SessaoUsuarioLogado
    {

        private static int _IdUsuario;
        public static int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        private static string _NomeUsuario;
        public static string NomeUsuario
        {
            get { return _NomeUsuario; }
            set { _NomeUsuario = value; }
        }
    }
}
