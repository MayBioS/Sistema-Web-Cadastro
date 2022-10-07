using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace WsClientes
{
	public class WsClientes : System.Web.Services.WebService
	{
		public WsClientes()
		{
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion

		/// <summary>
		/// Inclui um cliente pessoa física
		/// </summary>
		[WebMethod]
		public void incluirPF(string nome, string email, string telefone, string login, string senha, string cpf, DateTime dtnasc, string rg)
		{
			clsPessoaFis objPessoa = new clsPessoaFis();
			objPessoa.nome = nome;
			objPessoa.email = email;
			objPessoa.telefone = telefone;
			objPessoa.login = login;
			objPessoa.senha = senha;
			objPessoa.cpf = cpf;
			objPessoa.dtnasc = dtnasc;
			objPessoa.rg = rg;
			objPessoa.incluir();
		}
		
		/// <summary>
		/// Inclui um cliente pessoa jurídica
		/// </summary>
		[WebMethod]
		public void incluirPJ(string nome, string email, string telefone, string login, string senha, string cnpj, string razao_social, string insc_estadual)
		{
			clsPessoaJur objPessoa = new clsPessoaJur();
			objPessoa.nome = nome;
			objPessoa.email = email;
			objPessoa.telefone = telefone;
			objPessoa.login = login;
			objPessoa.senha = senha;
			objPessoa.cnpj = cnpj;
			objPessoa.razao_social = razao_social;
			objPessoa.insc_estatual = insc_estadual;
			objPessoa.incluir();
		}

		/// <summary>
		/// Altera um cliente pessoa física
		/// </summary>
		[WebMethod]
		public void alterarPF(long cod, string nome, string email, string telefone, string login, string senha, string cpf, DateTime dtnasc, string rg)
		{
			clsPessoaFis objPessoa = new clsPessoaFis();
			objPessoa.cod = cod;
			objPessoa.nome = nome;
			objPessoa.email = email;
			objPessoa.telefone = telefone;
			objPessoa.login = login;
			objPessoa.senha = senha;
			objPessoa.cpf = cpf;
			objPessoa.dtnasc = dtnasc;
			objPessoa.rg = rg;
			objPessoa.alterar();
		}

		/// <summary>
		/// Altera um cliente pessoa jurídica
		/// </summary>
		[WebMethod]
		public void alterarPJ(long cod, string nome, string email, string telefone, string login, string senha, string cnpj, string razao_social, string insc_estadual)
		{
			clsPessoaJur objPessoa = new clsPessoaJur();
			objPessoa.cod = cod;
			objPessoa.nome = nome;
			objPessoa.email = email;
			objPessoa.telefone = telefone;
			objPessoa.login = login;
			objPessoa.senha = senha;
			objPessoa.cnpj = cnpj;
			objPessoa.razao_social = razao_social;
			objPessoa.insc_estatual = insc_estadual;
			objPessoa.alterar();
		}

		/// <summary>
		/// Obtém um dataset contendo
		/// os dados de uma pessoa física
		/// </summary>
		[WebMethod]
		public DataSet obterPF(long cod)
		{
			clsPessoa objPessoa = new clsPessoaFis();
			objPessoa.cod = cod;
			return objPessoa.obter();
		}
			
		/// <summary>
		/// Obtém um dataset contendo
		/// os dados de uma pessoa jurídica
		/// </summary>
		[WebMethod]
		public DataSet obterPJ(long cod)
		{
			clsPessoa objPessoa = new clsPessoaJur();
			objPessoa.cod = cod;
			return objPessoa.obter();
		}

		/// <summary>
		/// Exclui um cliente
		/// </summary>
		[WebMethod]
		public void excluir(long cod)
		{
			clsPessoa objPessoa = new clsPessoaFis();
			objPessoa.cod = cod;
			objPessoa.excluir();
		}

		/// <summary>
		/// Autentica um cliente a partir do
		/// seu login e senha cadastrados
		/// </summary>
		[WebMethod]
		public long autenticar(string login, string senha)
		{
			clsPessoa objPessoa = new clsPessoaFis();
			objPessoa.login = login;
			objPessoa.senha = senha;
			long cod = objPessoa.autenticar();
			return cod;
		}

	}
}
