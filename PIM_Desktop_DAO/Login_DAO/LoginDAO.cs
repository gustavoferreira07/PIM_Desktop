using PIM_Desktop_MODEL;
using System.Data;
using System.Data.SqlClient;

namespace PIM_Desktop_DAO.Login_DAO
{
    public class LoginDAO
    {
        public bool ValidaLogin(LoginModel loginModel)
        {
            try
            {
                SqlDataReader dr;
                ConexaoBD con = new ConexaoBD();
                SqlCommand cmd = new SqlCommand("select * from tb_login where" +
               " Usuario=@usu and Senha=@senha ", con.ConectarBD());
                cmd.Parameters.Add("@usu", SqlDbType.VarChar).Value = loginModel.Usuario;
                cmd.Parameters.Add("@senha", SqlDbType.VarChar).Value = loginModel.Senha;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                    return true;
                else
                    return false;
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
