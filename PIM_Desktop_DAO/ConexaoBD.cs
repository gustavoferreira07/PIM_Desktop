using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace PIM_Desktop_DAO
{
    public class ConexaoBD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionBD"].ConnectionString);

        public SqlConnection ConectarBD()
        {

            try
            {
                con.Open();

            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao conectar.\nDetalhes do erro: " + e);
            }
            return con;
        }

        public SqlConnection DesconectarBD()
        {
            try
            {
                con.Close();
                //MessageBox.Show("Desconectado com sucesso!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Falha ao desconectar.\nDetalhes do erro: " + e);
            }
            return con;
        }
    }
}
