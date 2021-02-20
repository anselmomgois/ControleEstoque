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
    public partial class GuardarSetorEmpresa : Telas.TelaBase.BaseCE
    {

        #region"Variaveis"

        private string _IdentificadorSetorEmpresa;
        private Comum.Clases.SetorEmpresa objSetorEmpresa;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        public GuardarSetorEmpresa(string IdentificadorSetorEmpresa)
        {
            InitializeComponent();

            _IdentificadorSetorEmpresa = IdentificadorSetorEmpresa;
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

            RecuperarSetorEmpresa();
        }


        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscarSetor)
            {
                objSetorEmpresa = ((ContratoServico.Setor.BuscarSetor.RespostaBuscarSetor)objSaida).Setor;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    PreencherControles();
                }

            }
            else if (operacao == SDK.Operacoes.operacao.SetSetor)
            {                

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

        private void RecuperarSetorEmpresa()
        {

            if (!string.IsNullOrEmpty(_IdentificadorSetorEmpresa))
            {
                ContratoServico.Setor.BuscarSetor.PeticaoBuscarSetor Peticao = new ContratoServico.Setor.BuscarSetor.PeticaoBuscarSetor();
                Peticao.IdentificadorSetorEmpresa = _IdentificadorSetorEmpresa;
                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Setor.BuscarSetor.RespostaBuscarSetor, ContratoServico.Setor.BuscarSetor.PeticaoBuscarSetor>(Peticao,
                    SDK.Operacoes.operacao.BuscarSetor, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }

        }

        private void PreencherControles()
        {

            if (objSetorEmpresa != null)
            {

                txtNome.Text = objSetorEmpresa.DescricaoSetorEmpresa;
                txtImpressora.Text = objSetorEmpresa.DescricaoImpressora;   
            }
        }

        private void ExecutarGravar()
        {

            ContratoServico.Setor.SetSetor.PeticaoSetSetor Peticao = new ContratoServico.Setor.SetSetor.PeticaoSetSetor();

            Peticao.SetorEmpresa = new Comum.Clases.SetorEmpresa();
            Peticao.SetorEmpresa.DescricaoSetorEmpresa = txtNome.Text.Trim();
            Peticao.SetorEmpresa.DescricaoImpressora = txtImpressora.Text.Trim();
            Peticao.SetorEmpresa.IdentificadorSetorEmpresa = _IdentificadorSetorEmpresa;

            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;

            Agente.Agente.InvocarServico<ContratoServico.Setor.SetSetor.RespostaSetSetor, ContratoServico.Setor.SetSetor.PeticaoSetSetor>(Peticao, 
                SDK.Operacoes.operacao.SetSetor, null, null, true);

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
