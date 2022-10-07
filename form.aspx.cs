using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace WsClientes
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button4;
		protected System.Web.UI.WebControls.Button Button5;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button3;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static clsPessoaFis obj;

		private void Button1_Click(object sender, System.EventArgs e)
		{
			obj = new clsPessoaFis();
			obj.nome = "JONES";
			obj.email = "jones@premiosparavoce.com.br";
			obj.telefone = "8111-1697";
			obj.login = "jones";
			obj.senha = "senha";
			obj.cpf = "08026094735";
			obj.dtnasc = new DateTime(1980,9,15);
			obj.rg = "1536971-ES";
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			StringBuilder str = new StringBuilder("");
			str.Append("Nome: <b>" + obj.nome.ToString() + "</b><br>");
			str.Append("Email: <b>" + obj.email.ToString() + "</b><br>");
			str.Append("CPF: <b>" + obj.cpf.ToString() + "</b><br>");
			Label1.Text = str.ToString();
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			obj.incluir();
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			string ConnString = System.Configuration.ConfigurationSettings.AppSettings.Get("connectionstring").ToString();

			StringBuilder strSql = new StringBuilder("");
			strSql.Append("INSERT INTO clientes (nome, email, login, senha) ");
			strSql.Append("VALUES (@nome, @email, @login, @senha)");

			OleDbConnection conn = new OleDbConnection(ConnString);
			OleDbParameter[] param = new OleDbParameter[4];
			param[0] = new OleDbParameter("@nome", "JONES");
			param[1] = new OleDbParameter("@email", "jones@premiosparavoce.com.br");
			param[2] = new OleDbParameter("@login", "jones");
			param[3] = new OleDbParameter("@senha", "senha");
			OleDbCommand cmd = new OleDbCommand();
			for(byte i = 0;i < param.Length; i++)
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
			catch(OleDbException ex)
			{
				Response.Write("ERRO BD");
				Label1.Text = ex.Message.ToString();
			}
			catch(Exception)
			{
				Response.Write("ERRO RUNTIME");
			}
			finally
			{
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
			}
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			/*
			string connString = System.Configuration.ConfigurationSettings.AppSettings.Get("connectionstring").ToString();

			StringBuilder strSql = new StringBuilder("");
			strSql.Append("SELECT cod, nome, email, telefone, login, senha, cpf, dtnasc, rg ");
			strSql.Append("FROM clientes WHERE cod = @cod");

			OleDbConnection conn = new OleDbConnection(connString);
			OleDbParameter param = new OleDbParameter("@cod", 6);
			OleDbCommand cmd = conn.CreateCommand();
			cmd.Parameters.Add(param);
			cmd.CommandText = strSql.ToString();
			cmd.CommandType = CommandType.Text;
			*/

			try
			{
				/*
				conn.Open();
				OleDbDataAdapter da = new OleDbDataAdapter(cmd);
				DataSet ds = new DataSet();
				da.Fill(ds);
				DataGrid1.DataSource = ds;
				*/
				clsPessoa objPessoa = new clsPessoaFis();
				objPessoa.cod = 6;
				DataSet ds = objPessoa.obter();
				DataGrid1.DataSource = ds;
				DataGrid1.DataBind();
			}
			finally
			{
				/*
				conn.Close();
				conn.Dispose();
				cmd.Dispose();
				*/
			}
		
		}

	}
}
