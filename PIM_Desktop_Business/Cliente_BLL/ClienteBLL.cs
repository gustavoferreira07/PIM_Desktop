using PIM_Desktop_DAO.Cliente_DAO;
using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PIM_Desktop_BLL.ClienteBLL
{
    public class ClienteBLL
    {
        ClienteDAO clienteDAO = new ClienteDAO();
        public bool AdicionaCliente(ClienteModel clienteModel)
        {
            return clienteDAO.SalvaCliente(clienteModel);
        }
    }
}
