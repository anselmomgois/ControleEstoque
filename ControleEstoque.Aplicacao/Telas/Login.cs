using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using frmCriptografia = AmgSistemas.Framework.Criptografia;
using frmEmail = AmgSistemas.Framework.Email;
using Informatiz.ControleEstoque.Aplicacao.Classes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class Login : Form
    {

        public AgenteServico Agente { get; set; }
        private List<string> ControlesDesabilitados;
        public List<SDK.Operacoes.operacao> ServicosEmProcesamento { get; set; }

        public Login()
        {
            InitializeComponent();

            Agente = new AgenteServico();

            Agente.Agente.StatusOperacao += Agente_StatusOperacao;
            Agente.Agente.SetarCursorWait += Agente_SetarCursorWait;
            Agente.Agente.DesabilitarControles += Agente_DesabilitarControles;
            Agente.Agente.InicioOperacao += Agente_InicioOperacao;
            Agente.Agente.FimOperacao += Agente_FimOperacao;
        }


        private void Login_Load(object sender, EventArgs e)
        {
            Aplicacao.Classes.Util.ConfigurarFocoComponentes(this);
            Aplicacao.Classes.Util.ConfigurarEstilo(this);

            //' obtém a versão do sistema

            string Versao = Application.ProductVersion.Replace("1.0.", string.Empty);

            lblVersao.Text = "Versão: 1.0 Build(" + Versao + ")";

#if DEBUG

            if (System.Net.Dns.GetHostName() == "marcel")
            {
                txtUsuario.Text = "Marcel";
                txtSenha.Text = "1";
            }

#endif

        }

        #region "Propriedades"

        public Comum.Clases.Usuario objUsuario { get; set; }

        #endregion

        #region"Metodos"

        private void Agente_FimOperacao(SDK.Operacoes.operacao operacao, List<string> NomeControles, Boolean ExecutarFimProcesamento, Boolean NaoDesabilitarControles)
        {
            try
            {
                if (ServicosEmProcesamento != null)
                {
                    ServicosEmProcesamento.Remove(operacao);

                    if (ServicosEmProcesamento.Count == 0)
                    {
                        if (!NaoDesabilitarControles) DesabilitarControles(NomeControles, true, operacao);
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = txtUsuario.Text });
            }
        }

        private void Agente_InicioOperacao(SDK.Operacoes.operacao operacao)
        {
            try
            {
                if (ServicosEmProcesamento == null) { ServicosEmProcesamento = new List<SDK.Operacoes.operacao>(); }
                ServicosEmProcesamento.Add(operacao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = txtUsuario.Text });
            }
        }

        private void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {

            objUsuario = new Comum.Clases.Usuario();

            objUsuario = ((ContratoServico.Usuario.Logar.RespostaLogar)objSaida).Usuario;

            if (objUsuario == null)
            {
                Classes.Util.ExibirMensagemErro("Usuário sem permissão.");
            }
            else
            {

                ControleEstoque.Parametros.Parametros.InformacaoUsuario = objUsuario;

                if (objUsuario.AlterarSenha)
                {
                    AlterarSenha frmAlterarSenha = new AlterarSenha(objUsuario.Identificador, false);
                    frmAlterarSenha.ShowDialog();
                }

                this.Close();
            }
        }

        private void SetarCursor(Cursor objCursor)
        {
            Cursor = objCursor;
        }

        protected void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }


        #endregion

        #region"Eventos"

        private void Agente_DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            try
            {
                DesabilitarControles(NomeControles, Habilitado, operacao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = txtUsuario.Text });
            }
        }

        private void Agente_SetarCursorWait(object sender, EventArgs e)
        {
            try
            {
                SetarCursor(Cursors.WaitCursor);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = txtUsuario.Text });
            }
        }


        private void Agente_StatusOperacao(Exception ex, object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                SetarCursor(Cursors.Default);

                if (objSaida != null)
                {


                    ContratoServico.RespostaGenerica objSaidaConvertido = (ContratoServico.RespostaGenerica)objSaida;

                    if (objSaidaConvertido.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO))
                    {
                        throw new Exception(objSaidaConvertido.DescricaoErro);
                    }

                    RespostaAgente(objSaida, operacao, Parametros);

                }
                else
                {
                    Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = txtUsuario.Text });
                }

            }
            catch (Exception ex1)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex1.Message, Usuario = txtUsuario.Text });
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }
        }


        private void btnLogar_Click(object sender, EventArgs e)
        {

            try
            {

                if (!frmUtil.Validacao.ValidarValorCampo("http://www.google.com.br", frmUtil.Enumeradores.TipoValidacao.CONEXAOINTERNET))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Sem conexão com o servidor.");
                }

                if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Usuário obrigatório.");
                }

                if (string.IsNullOrEmpty(txtSenha.Text.Trim()))
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Senha obrigatória.");
                }

                ContratoServico.Usuario.Logar.PeticaoLogar Peticao = new ContratoServico.Usuario.Logar.PeticaoLogar();
                ContratoServico.Usuario.Logar.RespostaLogar Resposta;

                Peticao.Usuario = txtUsuario.Text;
                Peticao.Senha = txtSenha.Text;

                Agente.Agente.InvocarServico<ContratoServico.Usuario.Logar.RespostaLogar, ContratoServico.Usuario.Logar.PeticaoLogar>(Peticao,
               SDK.Operacoes.operacao.Logar, new Comum.ParametrosTela.Generica()
               {
                   PreencherObjeto = true,
                   ExibirMensagemNenhumRegistro = false
               }, null, true);



            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message });
            }

            #endregion

        }

    }
}
