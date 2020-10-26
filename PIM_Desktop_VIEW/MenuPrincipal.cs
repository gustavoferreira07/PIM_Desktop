using System;
using System.Windows.Forms;

namespace PIM_Desktop_VIEW
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroCliente objForm = new CadastroCliente();
            objForm.TopLevel = false;
            panelPrincipal.Controls.Add(objForm);
            objForm.FormBorderStyle = FormBorderStyle.Sizable;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaCliente objForm = new ConsultaCliente();
            objForm.TopLevel = false;
            panelPrincipal.Controls.Add(objForm);
            objForm.FormBorderStyle = FormBorderStyle.Sizable;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }

        private void lançarTransaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LancamentoTransacao objForm = new LancamentoTransacao();
            objForm.TopLevel = false;
            panelPrincipal.Controls.Add(objForm);
            objForm.FormBorderStyle = FormBorderStyle.Sizable;
            objForm.Dock = DockStyle.Fill;
            objForm.Show();
        }
    }
}
