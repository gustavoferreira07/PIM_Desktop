using PIM_Desktop_DAO.Cliente_DAO;
using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PIM_Desktop_BLL.ClienteBLL
{
    public class ClienteBLL
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        public bool AdicionaCliente(ClienteModel clienteModel, EnderecoModel enderecoModel, TelefoneModel telefoneModel, LoginModel loginModel)
        {
            return clienteDAO.EfetivaRegistro(clienteModel,enderecoModel,telefoneModel, loginModel);
        }
        public DataSet RetornaClienteByName(string nome)
        {
            DataSet ds = new DataSet();
            return clienteDAO.RetornaClientesByName(nome);
        }

        public DataSet RetornaClientes()
        {
            DataSet ds = new DataSet();
            return clienteDAO.RetornaClientes();
        }

        public DataTable RetornaClienteCbb()
        {
            return clienteDAO.RetornaClienteCbb();
        }
    }
}
