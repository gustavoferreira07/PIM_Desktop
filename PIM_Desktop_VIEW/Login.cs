using PIM_Desktop_BLL.Login_BLL;
using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM_Desktop_VIEW
{
    public partial class Login : Form
    {
        LoginBLL loginBLL = new LoginBLL();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginModel loginModel = new LoginModel()
            {
                Usuario = txtlogin.Text,
                Senha = txtSenha.Text
            };
            bool retorno = loginBLL.EfetuaLogin(loginModel);
            if (retorno)
            {
                MessageBox.Show(this, "Login efetuado com sucesso !", "Bem vindo !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MenuPrincipal menuPrincipal = new MenuPrincipal();
                menuPrincipal.Show();
                LimpaCampos();
                this.Hide();
            }
            else
            {
                MessageBox.Show(this, "Senha ou Usuario Incorretos!", "Incorreto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LimpaCampos();
            }

        }
        public void LimpaCampos()
        {
            txtlogin.Text = "";
            txtSenha.Text = "";
            txtlogin.Focus();
        }
        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click((object)sender, (EventArgs)e);
            }
        }
    }
}
