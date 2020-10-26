using PIM_Desktop_MODEL;
using System.Data;
using System.Data.SqlClient;
using System;
using PIM_Desktop_MODEL.Util;

namespace PIM_Desktop_DAO.Login_DAO
{
    public class LoginDAO
    {
        public bool ValidaLogin(LoginModel loginModel)
        {          
            using (ConexaoBD con = new ConexaoBD())
            {
                try
                {
                    SqlDataReader dr;
                    SqlCommand cmd = new SqlCommand("select * from tb_login where Usuario=@usu and Senha=@senha ", con.ConectarBD());
                    cmd.Parameters.Add("@usu", SqlDbType.VarChar).Value = loginModel.Usuario;
                    cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = loginModel.Senha;

                    dr = cmd.ExecuteReader();                    
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SessaoUsuarioLogado.IdUsuario = (int)dr[1];
                            SessaoUsuarioLogado.NomeUsuario = dr[2].ToString();
                        }

                        return true;
                    }                       
                    else
                        return false;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }                           
        }
    }
}
