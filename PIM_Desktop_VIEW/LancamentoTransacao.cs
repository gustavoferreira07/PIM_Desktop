using PIM_Desktop_BLL.ClienteBLL;
using PIM_Desktop_BLL.Moeda_BLL;
using PIM_Desktop_BLL.Transacao_BLL;
using PIM_Desktop_MODEL;
using PIM_Desktop_MODEL.Util;
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
    public partial class LancamentoTransacao : Form
    {
        MoedaBLL moedaBLL = new MoedaBLL();
        ClienteBLL ClienteBLL = new ClienteBLL();
        TransacaoBLL TransacaoBLL = new TransacaoBLL();
        public LancamentoTransacao()
        {
            InitializeComponent();            
            PreencheCbbCliente();
            PreencheCbbMoedas();
        }

        public void PreencheCbbCliente()
        {
            cbbCliente.DataSource = null;
            cbbCliente.DataSource = ClienteBLL.RetornaClienteCbb() ;
            cbbCliente.ValueMember = "idCliente";
            cbbCliente.DisplayMember = "nome";
            cbbCliente.SelectedItem = "";
            cbbCliente.Refresh();            
        }

        public void PreencheCbbMoedas()
        {            
            cbbMoeda.DataSource = null;
            cbbMoeda.DataSource = moedaBLL.PreencheCbbMoeda();
            cbbMoeda.ValueMember = "id";
            cbbMoeda.DisplayMember = "nomeMoeda";
            cbbMoeda.SelectedIndex = 0;
            cbbMoeda.Refresh();
        }

        private void cbbMoeda_SelectedIndexChanged(object sender, EventArgs e)
        {                      
            lblValor.Text = moedaBLL.RetornaValormoeda(cbbMoeda.SelectedIndex+1).ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblValorTranscao.Text = Convert.ToString(Convert.ToDouble(lblValor.Text) * Convert.ToDouble(txtQuantidadeAcoes.Text));
            }
            catch (Exception)
            {

                lblValorTranscao.Text = "0";
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                TransacaoModel transacaoModel = new TransacaoModel()
                {
                    DataTransacao = DateTime.Now,
                    IdCliente = SessaoUsuarioLogado.IdUsuario,
                    TipoTransacao = rdbCompra.Checked ? 1 : 2,
                    IdMoeda = cbbMoeda.SelectedIndex + 1,
                    QuantidadeAcoes = Convert.ToInt32(txtQuantidadeAcoes.Text)
                };
                bool retorno=TransacaoBLL.RegistraTransacao(transacaoModel);
                if (retorno)
                {
                    MessageBox.Show(this, "Transação registrada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        public void LimpaCampos()
        {
            txtQuantidadeAcoes.Clear();

        }
    }
}
