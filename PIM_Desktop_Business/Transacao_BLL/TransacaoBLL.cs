using PIM_Desktop_DAO.Transacao_DAO;
using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIM_Desktop_BLL.Transacao_BLL
{
    public class TransacaoBLL
    {
        TransacaoDAO transacaoDAO = new TransacaoDAO();

        public bool RegistraTransacao(TransacaoModel transacaoModel) 
        {
            return transacaoDAO.RegistraTransacao(transacaoModel);
        }
    }
}
