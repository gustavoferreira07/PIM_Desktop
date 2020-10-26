using PIM_Desktop_BLL.ClienteBLL;
using PIM_Desktop_DAO.Cliente_DAO;
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
    public partial class ConsultaCliente : Form
    {
        ClienteBLL clienteBLL = new ClienteBLL();
        public ConsultaCliente()
        {
            InitializeComponent();
        }

        private void ConsultaCliente_Load(object sender, EventArgs e)
        {
            txtNome.Focus();
            CarregaGrid();
        }

        public void CarregaGrid()
        {
            var ds = clienteBLL.RetornaClientes();
            dgCliente.DataSource = ds.Tables[0];
            dgCliente.Refresh();
        }

        public void CarregaGridByName(string nome)
        {
            var ds = clienteBLL.RetornaClienteByName(nome);
            dgCliente.DataSource = ds.Tables[0];
            dgCliente.Refresh();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            CarregaGridByName(txtNome.Text);
        }
    }
}
