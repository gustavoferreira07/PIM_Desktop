using PIM_Desktop_BLL.ClienteBLL;
using PIM_Desktop_MODEL;
using System;
using System.Windows.Forms;

namespace PIM_Desktop_VIEW
{
    public partial class CadastroCliente : Form
    {
        ClienteBLL clienteBLL = new ClienteBLL();
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void cbbPlano_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbbPlano.SelectedIndex)
            {
                case 1:
                    lblValorPlano.Text = "R$ 50,99";
                    break;

                case 2:
                    lblValorPlano.Text = "R$ 75,99";
                    break;
                case 3:
                    lblValorPlano.Text = "R$ 89,99";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            ClienteModel clienteModel = new ClienteModel()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                DataNascimento = Convert.ToDateTime(txtData.Text),
                Cpf = txtCpf.Text,
                IdPlano = (int)cbbPlano.SelectedIndex
            };

            EnderecoModel enderecoModel = new EnderecoModel()
            {
                Logradouro = txtEndereco.Text,
                Cep = txtCep.Text
            };

            TelefoneModel telefoneModel = new TelefoneModel()
            {
                Telefone = txtTelefone.Text
            };

            LoginModel loginModel = new LoginModel()
            {
                Usuario = txtLogin.Text,
                Senha = txtSenha.Text
            };


            if (clienteBLL.AdicionaCliente(clienteModel,enderecoModel, telefoneModel, loginModel))
            {
                MessageBox.Show(this, "Cliente cadastrado com sucesso !", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparCampos();
            }
            else
            {
                MessageBox.Show(this, "Erro ao cadastrar cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public void LimparCampos()
        {
            txtCep.Clear();
            txtConfirmaSenha.Clear();
            txtCpf.Clear();
            txtData.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtLogin.Clear();
            txtNome.Clear();
            txtSenha.Clear();
            txtTelefone.Clear();
            txtNome.Focus();
        }
    }
}
