using PIM_Desktop_DAO.Moeda_DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PIM_Desktop_BLL.Moeda_BLL
{
    public class MoedaBLL
    {
        MoedaDAO moedaDAO = new MoedaDAO();
        public DataTable PreencheCbbMoeda()
        {
            return moedaDAO.RetornaCbbMoeda();
        }

        public double? RetornaValormoeda(int id)
        {
            return moedaDAO.RetornaValorMoeda(id);
        }
    }
}
