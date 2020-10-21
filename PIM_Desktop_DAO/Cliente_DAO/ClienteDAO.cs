using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PIM_Desktop_DAO.Cliente_DAO
{
    public class ClienteDAO
    {
        SqlCommand comando = new SqlCommand();
        public bool SalvaCliente(ClienteModel clienteModel)
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {
                try
                {
                    comando.CommandText = "insert into tb_cliente values('" + clienteModel.Email + "','" + clienteModel.Nome + "','" + clienteModel.DataNascimento + "','" + clienteModel.Cpf + "',"+clienteModel.IdPlano+")";
                    comando.Connection = conexao.ConectarBD();                   
                    comando.ExecuteNonQuery();
                    return true;                                                                                
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }
    }
}
