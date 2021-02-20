using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GerarConexao : Form
    {
        public GerarConexao()
        {
            InitializeComponent();
        }

        public System.Configuration.ConnectionStringSettings objConexaoString { get; set; }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder objErros = new StringBuilder();

                if (string.IsNullOrEmpty(txtServidor.Text.Trim()))
                {
                    objErros.Append("Nome do servidor é obrigatório.");
                }

                if (string.IsNullOrEmpty(txtBanco.Text.Trim()))
                {
                    objErros.Append("Nome do banco é obrigatório.");
                }

                if (!chkAutenticacao.Checked)
                {
                    if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                    {
                        objErros.Append("Nome do usuário é obrigatório.");
                    }

                    if (string.IsNullOrEmpty(txtNovaSenha.Text.Trim()))
                    {
                        objErros.Append("A senha é obrigatória.");
                    }
                }

                if (objErros.Length > 0)
                {
                    Aplicacao.Classes.Util.ExibirMensagemErro(objErros.ToString());
                    return;
                }

                AmgSistemas.Framework.AcessoDados.DadosConexao objDados = new AmgSistemas.Framework.AcessoDados.DadosConexao();

                objDados.AutenticacaoIntegrada = chkAutenticacao.Checked;
                objDados.DataBase = txtBanco.Text;

                if (!string.IsNullOrEmpty(txtPorta.Text))
                {
                    objDados.Server += "," + txtPorta.Text.Trim();
                }

                if (chkAutenticacao.Checked)
                {
                    objDados.DataSource = txtServidor.Text.Trim();
                }
                else
                {
                    objDados.Server = txtServidor.Text.Trim();
                     objDados.UID = txtUsuario.Text;
                    objDados.pwd = txtNovaSenha.Text;
                }

                AmgSistemas.Framework.AcessoDados.Conexao.GerarArquivoConexao(objDados, Comum.Clases.Constantes.ARQUIVO_CONEXAO);

                string objStringConexao = string.Empty;
                Boolean ConexaoOk = AmgSistemas.Framework.AcessoDados.Conexao.TestarConexao(Comum.Clases.Constantes.ARQUIVO_CONEXAO, "INFM_TIPOPESSOA",ref objStringConexao);

                if (!ConexaoOk)
                {
                    Aplicacao.Classes.Util.ExibirMensagemErro("Dados da conexão incorretos");
                    string Arquivo = AmgSistemas.Framework.AcessoDados.Conexao.RetornarDiretorio() + "Conexao.xml";

                    if (System.IO.File.Exists(Arquivo))
                    {
                     System.IO.File.Delete(Arquivo);
                    }
                }
                else
                {
                    objConexaoString = AmgSistemas.Framework.AcessoDados.Conexao.GerarStringConexao(Comum.Clases.Constantes.ARQUIVO_CONEXAO);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.ToString());

                string Arquivo = AmgSistemas.Framework.AcessoDados.Conexao.RetornarDiretorio() + Comum.Clases.Constantes.ARQUIVO_CONEXAO + ".xml";

                if (System.IO.File.Exists(Arquivo))
                {
                    System.IO.File.Delete(Arquivo);
                }

            }
        }

        private void chkAutenticacao_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkAutenticacao.Checked)
                {
                    txtUsuario.Enabled = false;
                    txtUsuario.Text = string.Empty;
                    txtNovaSenha.Text = string.Empty;
                    txtNovaSenha.Enabled = false;
                }
                else
                {
                    txtUsuario.Enabled = true;
                    txtNovaSenha.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro("Dados da conexão incorretos");
                return;
            }
        }

        private void GerarConexao_Load(object sender, EventArgs e)
        {
            try
            {

                Aplicacao.Classes.Util.ConfigurarEstilo(this);
                Aplicacao.Classes.Util.ConfigurarFocoComponentes(this);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }

        private void txtPorta_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }
    }
}
