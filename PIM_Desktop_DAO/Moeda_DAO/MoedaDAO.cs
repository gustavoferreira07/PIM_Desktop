using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PIM_Desktop_DAO.Moeda_DAO
{
    public class MoedaDAO
    {
        public DataTable RetornaCbbMoeda()
        {
            using (ConexaoBD con = new ConexaoBD())
            {
                String scom = "select * from tb_moeda";
                SqlDataAdapter da = new SqlDataAdapter(scom, con.ConectarBD());
                DataTable dtResultado = new DataTable();
                dtResultado.Clear();
                da.Fill(dtResultado);
                return dtResultado;
            }
        }

        public double? RetornaValorMoeda(int id)
        {
            SqlDataReader dr;

            using (ConexaoBD conexao = new ConexaoBD())
            {
                var retorno = 0.0;
                SqlCommand cmd = new SqlCommand("select valorMoeda from tb_moeda where id=@id", conexao.ConectarBD());
                cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = id;
                dr = cmd.ExecuteReader();
                try
                {
                    if (dr.HasRows == false)
                    {
                        return null;
                    }
                    else
                    {
                        while (dr.Read())
                        {
                            retorno = Convert.ToDouble(dr[0]);
                        }
                        return retorno;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao buscar valor da moeda");
                }
            }
        }
    }
}
