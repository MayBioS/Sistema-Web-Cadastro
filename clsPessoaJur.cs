using System;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace WsClientes
{
    /// <summary>
    /// Criando a classe clsPessoaJur que herda da classe clsPessoa
    /// </summary>
    public class clsPessoaJur : clsPessoa
    {
        //Definindo propriedades da classe herdada
        private string _cnpj;
        private string _razao_social;
        private string _insc_estatual;
        private string _salario_juridico; //adicionado
private string _logradouro;
        private string _numero;
        private string _complemento;
        private string _tipoEndereco;

        public string cnpj
        {
            get { return _cnpj; }
            set { _cnpj = value; }
        }

        public string razao_social
        {
            get { return _razao_social; }
            set { _razao_social = value; }
        }

        public string insc_estatual
        {
            get { return _insc_estatual; }
            set { _insc_estatual = value; }
        }

        public string salario_juridico //adicionado 
        {
            get { return _salario_juridico; }
            set { _salario_juridico = value; }
        }

public string logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

public string numero
        {
            get { return _numero; }
            set { _numero = value; }
        }

public string complemento
        {
            get { return _complemento; }
            set { _complemento = value; }
        }

public string tipoEndereco
        {
            get { return _tipoEndereco; }
            set { _tipoEndereco = value; }
        }

        public clsPessoaJur()
        {
            this.cod = 0;
            this.email = "";
            this.telefone = "";
            this.login = "";
            this.senha = "";
            this.cnpj = "";
            this.razao_social = "";
            this.insc_estatual = "";
            this.salario_juridico = "";//adicionado
this.logradouro = "";
this.numero = "";
this.complemento = "";
this.tipoEndereco = "";

        }

        public clsPessoaJur(long cod, string nome, string email, string telefone, string login, string senha, string cnpj, string razao_social, string insc_estatual, string salario_juridico, string logradouro, string numero, string complemento, string tipoEndereco) //adicionado
        {
            this.cod = cod;
            this.nome = nome;
            this.email = email;
            this.telefone = telefone;
            this.login = login;
            this.senha = senha;
            this.cnpj = cnpj;
            this.razao_social = razao_social;
            this.insc_estatual = insc_estatual;
            this.salario_juridico = salario_juridico;
this.logradouro = logradouro;
this.numero = numero;
this.complemento = complemento;
this.tipoEndereco = tipoEndereco;
        }

        public override void incluir()
        {
            string strConn = System.Configuration.ConfigurationSettings.AppSettings.Get("connectionstring").ToString();

            StringBuilder strSql = new StringBuilder("");
            strSql.Append("INSERT INTO clientes (nome, email, telefone, login, senha, cnpj, razao_social, insc_estatual)");
            strSql.Append("VALUES(@nome, @email, @telefone, @login, @senha, @cnpj, @razao_social, @insc_estatual, @salario_juridico, @logradouro, @numero, @complemento, @tipoEndereco)");

            OleDbConnection conn = new OleDbConnection(strConn);
            OleDbParameter[] param = new OleDbParameter[13];
            param[0] = new OleDbParameter("@nome", this.nome);
            param[1] = new OleDbParameter("@email", this.email);
            param[2] = new OleDbParameter("@telefone", this.telefone);
            param[3] = new OleDbParameter("@login", this.login);
            param[4] = new OleDbParameter("@senha", this.senha);
            param[5] = new OleDbParameter("@cnpj", this.cnpj);
            param[6] = new OleDbParameter("@razao_social", this.razao_social);
            param[7] = new OleDbParameter("@insc_estatual", this.insc_estatual);
            param[8] = new OleDbParameter("@salario_juridico", this.salario_juridico);
param[9] = new OleDbParameter("@logradouro", this.logradouro);
param[10] = new OleDbParameter("@numero", this.numero);
param[11] = new OleDbParameter("@complemento", this.complemento);
param[12] = new OleDbParameter("@tipoEndereco", this.tipoEndereco);
            OleDbCommand cmd = new OleDbCommand();
            for (byte i = 0; i < param.Length; i++)
            {
                cmd.Parameters.Add(param[i]);
            }

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                throw new Exception("ERRO BANCO DE DADOS: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO RUNTIME: " + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
        }

        public override void alterar()
        {
            string connString = System.Configuration.ConfigurationSettings.AppSettings.Get("connectionstring").ToString();

            StringBuilder strSql = new StringBuilder("");
            strSql.Append("UPDATE clientes SET ");
            strSql.Append("  nome = @nome, ");
            strSql.Append("  email = @email, ");
            strSql.Append("  telefone = @telefone, ");
            strSql.Append("  login = @login, ");
            strSql.Append("  senha = @senha, ");
            strSql.Append("  cnpj = @cnpj, ");
            strSql.Append("  razao_social = @razao_social, ");
            strSql.Append("  insc_estatual = @insc_estatual ");
            strSql.Append("  salario_juridico = @salario_juridico "); //adicionado
strSql.Append("  logradouro = @logradouro ");
strSql.Append("  numero = @numero ");
strSql.Append("  complemento = @complemento ");
strSql.Append("  tipoEndereco = @tipoEndereco ");
            strSql.Append("WHERE cod = @cod;");

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbParameter[] param = new OleDbParameter[10];
            param[0] = new OleDbParameter("@nome", this.nome);
            param[1] = new OleDbParameter("@email", this.email);
            param[2] = new OleDbParameter("@telefone", this.telefone);
            param[3] = new OleDbParameter("@login", this.login);
            param[4] = new OleDbParameter("@senha", this.senha);
            param[5] = new OleDbParameter("@cnpj", this.cnpj);
            param[6] = new OleDbParameter("@razao_social", this.razao_social);
            param[7] = new OleDbParameter("@insc_estatual", this.insc_estatual);
            param[8] = new OleDbParameter("@cod", this.cod);
            param[9] = new OleDbParameter("@salario_juridico", this.salario_juridico); //adicionado
param[10] = new OleDbParameter("@logradouro", this.logradouro);
param[11] = new OleDbParameter("@numero", this.numero);
param[12] = new OleDbParameter("@complemento", this.complemento);
param[13] = new OleDbParameter("@tipoEndereco", this.tipoEndereco);
            OleDbCommand cmd = new OleDbCommand();
            for (byte i = 0; i < param.Length; i++)
            {
                cmd.Parameters.Add(param[i]);
            }

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strSql.ToString();
                cmd.ExecuteNonQuery();
            }
            catch (OleDbException ex)
            {
                throw new Exception("ERRO BANCO DE DADOS: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO RUNTIME: " + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }
        }

        public override DataSet obter()
        {
            string connString = System.Configuration.ConfigurationSettings.AppSettings.Get("connectionstring").ToString();

            StringBuilder strSql = new StringBuilder("");
            strSql.Append("SELECT cod, nome, email, telefone, login, senha, cnpj, razao_social, insc_estatual, salario_juridico, logradouro, numero, complemento, tipoEndereco ");
            strSql.Append("FROM clientes WHERE cod = @cod");

            OleDbConnection conn = new OleDbConnection(connString);
            OleDbParameter param = new OleDbParameter("@cod", this.cod);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Parameters.Add(param);

            try
            {
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = strSql.ToString();
                cmd.CommandType = CommandType.Text;

                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (OleDbException ex)
            {
                throw new Exception("ERRO BANCO DE DADOS: " + ex.Message.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO RUNTIME: " + ex.Message.ToString());
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
            }

        }
        public override void PagarImposto() //adicionado
        {
            throw new NotImplementedException();
        }
    }
}

