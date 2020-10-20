using PIM_Desktop_DAO.Login_DAO;
using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIM_Desktop_BLL.Login_BLL
{
    public class LoginBLL
    {
        LoginDAO loginDAO = new LoginDAO();
        public bool EfetuaLogin(LoginModel loginModel)
        {
            return loginDAO.ValidaLogin(loginModel);
        }
    }
}
