using PIM_Desktop_BLL.ClienteBLL;
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
    public partial class CadastroCliente : Form
    {
        ClienteBLL clienteBLL = new ClienteBLL();
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

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
            var oi = cbbPlano.SelectedIndex;
            ClienteModel clienteModel = new ClienteModel()
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                DataNascimento = Convert.ToDateTime(txtData.Text),
                Cpf = txtCpf.Text,
                IdPlano = (int)cbbPlano.SelectedIndex
            };

            if (clienteBLL.AdicionaCliente(clienteModel))
            {
                MessageBox.Show(this, "Cliente cadastrado com sucesso !", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, "Erro ao cadastrar cliente!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
