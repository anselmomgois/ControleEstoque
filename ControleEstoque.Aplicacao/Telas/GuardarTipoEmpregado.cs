using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Aplicacao.Classes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarTipoEmpregado : Telas.TelaBase.BaseCE
    {

        #region"Variaveis"

        private string _IdentificadorTipoEmpregado;
        private Comum.Clases.TipoEmpregado objTipoEmpregado;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        public GuardarTipoEmpregado(string IdentificadorTipoEmpregado)
        {
            InitializeComponent();

            _IdentificadorTipoEmpregado = IdentificadorTipoEmpregado;
        }

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpGeral);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {

            RecuperarTipoEmpregado();
        }


        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscarTipoEmpregado)
            {
                objTipoEmpregado = ((ContratoServico.TipoEmpregado.BuscarTipoEmpregado.RespostaBuscarTipoEmpregado)objSaida).TipoEmpregado;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    PreencherControles();
                }

            }
            else if (operacao == SDK.Operacoes.operacao.SetTipoEmpregado)
            {
                // Atualizar os valores que já estão em memória, para não precisa buscar na base novamente
                ControleEstoque.Parametros.Parametros.InformacaoUsuario.Supervisor = chkSupervisor.Checked;
                ControleEstoque.Parametros.Parametros.InformacaoUsuario.ResponsavelFinanceiro = chkrespfinanceiro.Checked;
                ControleEstoque.Parametros.Parametros.InformacaoUsuario.Entregador = chkEntregador.Checked;
                ControleEstoque.Parametros.Parametros.InformacaoUsuario.Gerente = chkGerente.Checked;

                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            DesabilitarControles(this, Habilitado, NomeControles);

        }

        private void DesabilitarControles(Control objcontrole, Boolean Habilitado, List<string> NomeControles)
        {
            if (NomeControles != null && NomeControles.Count > 0)
            {
                if (NomeControles.Exists(c => c == objcontrole.Name))
                {
                    objcontrole.Enabled = Habilitado;
                }
            }
            else
            {
                objcontrole.Enabled = Habilitado;
            }

            if (objcontrole.Controls != null && objcontrole.Controls.Count > 0)
            {
                foreach (Control c in objcontrole.Controls)
                {
                    DesabilitarControles(c, Habilitado, NomeControles);
                }
            }
        }

        private void RecuperarTipoEmpregado()
        {

            if (!string.IsNullOrEmpty(_IdentificadorTipoEmpregado))
            {
                ContratoServico.TipoEmpregado.BuscarTipoEmpregado.PeticaoBuscarTipoEmpregado Peticao = new ContratoServico.TipoEmpregado.BuscarTipoEmpregado.PeticaoBuscarTipoEmpregado();
                Peticao.Identificador = _IdentificadorTipoEmpregado;
                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.TipoEmpregado.BuscarTipoEmpregado.RespostaBuscarTipoEmpregado, ContratoServico.TipoEmpregado.BuscarTipoEmpregado.PeticaoBuscarTipoEmpregado>(Peticao,
                    SDK.Operacoes.operacao.BuscarTipoEmpregado, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }

        }

        private void PreencherControles()
        {

            if (objTipoEmpregado != null)
            {

                txtNome.Text = objTipoEmpregado.Descricao;
                chkSupervisor.Checked = objTipoEmpregado.Supervisor;
                chkrespfinanceiro.Checked = objTipoEmpregado.ResponsavelFinanceiro;
                chkEntregador.Checked = objTipoEmpregado.Entregador;
                chkGerente.Checked = objTipoEmpregado.Gerente;
                chkEnviarEmailFechamento.Checked = objTipoEmpregado.EnviarEmailFechamento;
            }
        }

        private void ExecutarGravar()
        {

            ContratoServico.TipoEmpregado.SetTipoEmpregado.PeticaoSetTipoEmpregado Peticao = new ContratoServico.TipoEmpregado.SetTipoEmpregado.PeticaoSetTipoEmpregado();

            Peticao.TipoEmpregado = new Comum.Clases.TipoEmpregado();
            Peticao.TipoEmpregado.Descricao = txtNome.Text.Trim();
            Peticao.TipoEmpregado.Identificador = _IdentificadorTipoEmpregado;
            Peticao.TipoEmpregado.Supervisor = chkSupervisor.Checked;
            Peticao.TipoEmpregado.ResponsavelFinanceiro = chkrespfinanceiro.Checked;
            Peticao.TipoEmpregado.Entregador = chkEntregador.Checked;
            Peticao.TipoEmpregado.Gerente = chkGerente.Checked;
            Peticao.TipoEmpregado.EnviarEmailFechamento = chkEnviarEmailFechamento.Checked;

            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;

            Agente.Agente.InvocarServico<ContratoServico.TipoEmpregado.SetTipoEmpregado.RespostaSetTipoEmpregado, ContratoServico.TipoEmpregado.SetTipoEmpregado.PeticaoSetTipoEmpregado>(Peticao, SDK.Operacoes.operacao.SetTipoEmpregado, null, null, true);

        }

        #endregion

        #region "Eventos"    

       
        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {
                ExecutarGravar();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        

        #endregion

    }
}
