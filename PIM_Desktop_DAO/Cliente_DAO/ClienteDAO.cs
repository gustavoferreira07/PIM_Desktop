using PIM_Desktop_MODEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace PIM_Desktop_DAO.Cliente_DAO
{
    public class ClienteDAO
    {
        SqlCommand comando = new SqlCommand();
        public bool EfetivaRegistro(ClienteModel clienteModel, EnderecoModel enderecoModel, TelefoneModel telefoneModel, LoginModel loginModel)
        {
            try
            {
                SalvaCliente(clienteModel);
                int? IdCliente = RetornaIdClienteByEmail(clienteModel.Email);
                enderecoModel.IdCliente = IdCliente ?? default(int);
                telefoneModel.IdCliente = IdCliente ?? default(int);
                loginModel.IdCliente = IdCliente ?? default(int);
                SalvaEnderecoCliente(enderecoModel);
                SalvaTelefoneCliente(telefoneModel);
                SalvaLoginCliente(loginModel);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void SalvaCliente(ClienteModel clienteModel)
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {
                try
                {
                    comando.CommandText = "insert into tb_cliente values('" + clienteModel.Email + "','" + clienteModel.Nome + "','" + clienteModel.DataNascimento + "','" + clienteModel.Cpf + "'," + clienteModel.IdPlano + ")";
                    comando.Connection = conexao.ConectarBD();
                    comando.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar Cliente");
                }
            }
        }
        public DataSet RetornaClientes()
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {

                DataSet ds = new DataSet();
                SqlDataAdapter da;
                da = new SqlDataAdapter("select * from tb_cliente", conexao.ConectarBD());
                da.Fill(ds);
                conexao.DesconectarBD();
                return ds;
            }
        }

        public DataSet RetornaClientesByName(string nome)
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {

                DataSet ds = new DataSet();
                SqlDataAdapter da;
                da = new SqlDataAdapter($"select * from tb_cliente where nome like '%{nome}%'", conexao.ConectarBD());
                da.Fill(ds);
                conexao.DesconectarBD();
                return ds;
            }
        }

        public DataTable RetornaClienteCbb()
        {
            using (ConexaoBD con = new ConexaoBD())
            {
                String scom = "select * from tb_cliente order by nome asc";
                SqlDataAdapter da = new SqlDataAdapter(scom, con.ConectarBD());
                DataTable dtResultado = new DataTable();
                dtResultado.Clear();
                da.Fill(dtResultado);
                return dtResultado;
            }
        }

        public void SalvaEnderecoCliente(EnderecoModel enderecoModel)
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {
                try
                {
                    comando.CommandText = "insert into tb_endereco values('" + enderecoModel.Logradouro + "','" + enderecoModel.Cep + "'," + enderecoModel.IdCliente + ")";
                    comando.Connection = conexao.ConectarBD();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar endereço");
                }
            }
        }
        public void SalvaTelefoneCliente(TelefoneModel telefoneModel)
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {
                try
                {
                    comando.CommandText = "insert into tb_telefone values(" + telefoneModel.IdCliente + ",'" + telefoneModel.Telefone + "')";
                    comando.Connection = conexao.ConectarBD();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar endereço");
                }
            }
        }

        public void SalvaLoginCliente(LoginModel loginModel)
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {
                try
                {
                    comando.CommandText = "insert into tb_login values('" + loginModel.IdCliente + "','" + loginModel.Usuario + "','" + loginModel.Senha + "')";
                    comando.Connection = conexao.ConectarBD();
                    comando.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao salvar Login");
                }
            }
        }
        public int? RetornaIdClienteByEmail(string email)
        {
            using (ConexaoBD conexao = new ConexaoBD())
            {
                SqlDataReader dr;
                SqlCommand cmd = new SqlCommand("select IdCliente from tb_cliente where email=@email", conexao.ConectarBD());
                cmd.Parameters.Add("@email", SqlDbType.VarChar).Value = email;

                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    int id = 0;
                    while (dr.Read())
                    {
                        id = (int)dr[0];
                    }
                    return id;
                }
                else
                    return null;
            }
        }       
    }    
}
