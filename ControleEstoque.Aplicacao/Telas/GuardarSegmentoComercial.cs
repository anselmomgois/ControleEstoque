using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarSegmentoComercial : TelaBase.BaseCE
    {
        public GuardarSegmentoComercial(string IdentificadorSegmentoComercial)
        {
            InitializeComponent();

            _IdentificadorSegmentoComercial = IdentificadorSegmentoComercial;
            
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private string _IdentificadorSegmentoComercial;
        private Comum.Clases.SegmentoComercial _objSegmentoComercial;

        #endregion

        #region"Metodos"

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarSegmentoComercial)
            {
                _objSegmentoComercial = ((ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.RespostaRecuperarSegmentoComercial)objSaida).SegmentoComercial;

                PreencherControles();
            }
            else if (operacao == SDK.Operacoes.operacao.SetSegmentoComercial)
            {


                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }


        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(txtNome);
            this.pnlBase.Controls.Add(lblNome);
            CarregarTela();
            base.Inicializar();
        }
        private void CarregarTela()
        {

            RecuperarProdutoMarca();            
        }

        private void RecuperarProdutoMarca()
        {

            if (!string.IsNullOrEmpty(_IdentificadorSegmentoComercial))
            {
                ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.PeticaoRecuperarSegmentoComercial Peticao = new ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.PeticaoRecuperarSegmentoComercial()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    Identificador = _IdentificadorSegmentoComercial
                };

                Agente.Agente.InvocarServico<ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.RespostaRecuperarSegmentoComercial, ContratoServico.SegmentoComercial.RecuperarSegmentoComercial.PeticaoRecuperarSegmentoComercial>(Peticao,
                      SDK.Operacoes.operacao.RecuperarSegmentoComercial, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
               
            }

        }

        private void PreencherControles()
        {

            if (_objSegmentoComercial != null)
            {

                txtNome.Text = _objSegmentoComercial.Descricao;
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.SegmentoComercial objSegmentoComercial = new Comum.Clases.SegmentoComercial();

            objSegmentoComercial.Descricao = txtNome.Text.Trim();
            objSegmentoComercial.Identificador = _IdentificadorSegmentoComercial;

            ContratoServico.SegmentoComercial.SetSegmentoComercial.PeticaoRecuperarSetSegmentoComercial Peticao = new ContratoServico.SegmentoComercial.SetSegmentoComercial.PeticaoRecuperarSetSegmentoComercial()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                SegmentoComercial = objSegmentoComercial
            };

            Agente.Agente.InvocarServico<ContratoServico.SegmentoComercial.SetSegmentoComercial.RespostaSetSegmentoComercial, ContratoServico.SegmentoComercial.SetSegmentoComercial.PeticaoRecuperarSetSegmentoComercial>(Peticao,
                  SDK.Operacoes.operacao.SetSegmentoComercial, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);

            

        }

        #endregion

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

    }
}
