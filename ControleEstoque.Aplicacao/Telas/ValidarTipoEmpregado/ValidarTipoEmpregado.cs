using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas.ValidarTiposEmpregados
{
    public partial class ValidarTipoEmpregado : TelaBase.BaseCE
    {

        #region "Variaveis"
        // define se a validação será feita por permissão de usuario. Case esteja True, tem que validar a permissao, caso seja False, tem que validar com usuario logado
        private bool validarPermissao = false;
        // define se o usuario informado tem que ser o mesmo usuario logado
        private bool usuarioLogado = false;
        private List<Comum.Enumeradores.Enumeradores.TipoEmpregado> tiposEmpregado;

        public bool UsuarioTemPermissao = false;
        public Comum.Clases.Usuario objUsuario { get; set; }


        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Construtor"

        public ValidarTipoEmpregado(bool pValidarPermissao, bool pUsuarioLogado)
        {
            InitializeComponent();
            validarPermissao = pValidarPermissao;
            usuarioLogado = pUsuarioLogado;
        }

        #endregion

        #region "Propriedades"
        public string IdentificadorUsuario { get; set; }
        public string NomeUsuario { get; set; }
        #endregion
        #region "Metodos

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpGeral);
            base.Inicializar();
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Validar Usuário (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnValidarUsuario_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        private void btnValidarUsuario_Click(object sender, EventArgs e)
        {

            try
            {

                if (string.IsNullOrEmpty(txtUsuario.Text))
                {
                    txtUsuario.Focus();
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar o Usuário.");
                }
                else if (string.IsNullOrEmpty(txtSenha.Text))
                {
                    txtSenha.Focus();
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "É obrigatório informar a Senha.");
                }

                ExecutarValidarUsuario();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void ExecutarValidarUsuario()
        {

            if (!validarPermissao)
            {

                if (usuarioLogado)
                {

                    if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login == txtUsuario.Text)
                    {
                        ContratoServico.Usuario.ValidarTipoEmpregado.PeticaoValidarTipoEmpregado Peticao = new ContratoServico.Usuario.ValidarTipoEmpregado.PeticaoValidarTipoEmpregado();

                        Peticao.nomeUsuario = txtUsuario.Text;
                        Peticao.senhaUsuario = txtSenha.Text;
                        Peticao.validarPermissao = validarPermissao;
                        Peticao.usuarioLogado = usuarioLogado;
                        Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                        Agente.Agente.InvocarServico<ContratoServico.Usuario.ValidarTipoEmpregado.RespostaValidarTipoEmpregado, ContratoServico.Usuario.ValidarTipoEmpregado.PeticaoValidarTipoEmpregado>(Peticao,
                                SDK.Operacoes.operacao.ValidarTipoEmpregado, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
                    }
                    else
                    {
                        UsuarioTemPermissao = false;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                {
                    // serviço de login
                    Logar();
                }
            }
            else
            {

                ContratoServico.Usuario.ValidarTipoEmpregado.PeticaoValidarTipoEmpregado Peticao = new ContratoServico.Usuario.ValidarTipoEmpregado.PeticaoValidarTipoEmpregado();

                Peticao.nomeUsuario = txtUsuario.Text;
                Peticao.senhaUsuario = txtSenha.Text;
                Peticao.TiposEmpregado = new List<Comum.Enumeradores.Enumeradores.TipoEmpregado>();
                Peticao.TiposEmpregado.Add(Comum.Enumeradores.Enumeradores.TipoEmpregado.SUPERVISOR);
                Peticao.TiposEmpregado.Add(Comum.Enumeradores.Enumeradores.TipoEmpregado.GERENTE);
                Peticao.validarPermissao = validarPermissao;
                Peticao.usuarioLogado = usuarioLogado;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Usuario.ValidarTipoEmpregado.RespostaValidarTipoEmpregado, ContratoServico.Usuario.ValidarTipoEmpregado.PeticaoValidarTipoEmpregado>(Peticao,
                        SDK.Operacoes.operacao.ValidarTipoEmpregado, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.ValidarTipoEmpregado)
            {
                ContratoServico.Usuario.ValidarTipoEmpregado.RespostaValidarTipoEmpregado resposta = ((ContratoServico.Usuario.ValidarTipoEmpregado.RespostaValidarTipoEmpregado)objSaida);

                if (validarPermissao)
                {
                    tiposEmpregado = resposta.TiposEmpregado;
                }

                UsuarioTemPermissao = resposta.AcessoPermitido;
                IdentificadorUsuario = resposta.IdentificadorUsuario;
                NomeUsuario = resposta.NomeUsuario;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else if (operacao == SDK.Operacoes.operacao.Logar)
            {

                objUsuario = ((ContratoServico.Usuario.Logar.RespostaLogar)objSaida).Usuario;

                if(objUsuario != null)
                {
                    UsuarioTemPermissao = true;
                    IdentificadorUsuario =  objUsuario.Identificador;
                    NomeUsuario = objUsuario.Nome;
                }
               

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void Logar()
        {
            try
            {

                if (!AmgSistemas.Framework.Utilitarios.Validacao.ValidarValorCampo("http://www.google.com.br", AmgSistemas.Framework.Utilitarios.Enumeradores.TipoValidacao.CONEXAOINTERNET))
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
        }

        #endregion

    }
}
