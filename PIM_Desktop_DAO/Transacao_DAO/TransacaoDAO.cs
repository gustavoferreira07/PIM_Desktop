using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PIM_Desktop_DAO.Transacao_DAO
{
    public class TransacaoDAO
    {
        SqlCommand comando = new SqlCommand();
        public bool RegistraTransacao(TransacaoModel transacaoModel)
        {            
            using (ConexaoBD conexao = new ConexaoBD())
            {
                try
                {
                    comando.CommandText = "insert into tb_transacao values('" + transacaoModel.DataTransacao + "'," + transacaoModel.IdCliente + "," + transacaoModel.TipoTransacao + "," + transacaoModel.IdMoeda + "," + transacaoModel.QuantidadeAcoes + ")";
                    comando.Connection = conexao.ConectarBD();
                    comando.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar Transação. \n "+ex.Message);
                }            
            }
        }
    }
}
