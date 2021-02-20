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
    public partial class Cor : TelaBase.BaseCE
    {

        #region"Variaveis"

        private string _CorARGB;
        private string _IdentificadorCor;
        private Comum.Clases.Cor objCor;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        public Cor(string IdentificadorCor)
        {
            InitializeComponent();

            _IdentificadorCor = IdentificadorCor;

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
            CarregarTela();
            base.Inicializar();
        }

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

            if (operacao == SDK.Operacoes.operacao.RecuperarCor)
            {
                objCor = ((ContratoServico.Cor.RecuperarCor.RespostaRecuperarCor)objSaida).Cor;

                PreencherControles();
                
            }
            else if (operacao == SDK.Operacoes.operacao.SetCor)
            {


                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }


        }

        private void CarregarTela()
        {

            RecuperarCor();
            
        }

        private void RecuperarCor()
        {

            if (!string.IsNullOrEmpty(_IdentificadorCor))
            {

                ContratoServico.Cor.RecuperarCor.PeticaoRecuperarCor Peticao = new ContratoServico.Cor.RecuperarCor.PeticaoRecuperarCor()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    Identificador = _IdentificadorCor
                };

                Agente.Agente.InvocarServico<ContratoServico.Cor.RecuperarCor.RespostaRecuperarCor, ContratoServico.Cor.RecuperarCor.PeticaoRecuperarCor>(Peticao,
                      SDK.Operacoes.operacao.RecuperarCor, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
                                
            }

        }

        private Color ConverterStringEmCor(string Cor)
        {

            if (!string.IsNullOrEmpty(Cor))
            {
                string[] objStrCor = objCor.CodigoRGB.Split(Convert.ToChar("|"));

                Int32 A = Convert.ToInt32(objStrCor[0]);
                Int32 R = Convert.ToInt32(objStrCor[1]);
                Int32 G = Convert.ToInt32(objStrCor[2]);
                Int32 B = Convert.ToInt32(objStrCor[3]);

                return Color.FromArgb(A, R, G, B);
            }

            return new Color();
        }

        private void PreencherControles()
        {

            if (objCor != null)
            {

                txtNome.Text = objCor.Descricao;
                _CorARGB = objCor.CodigoRGB;

                pnlCor.BackColor = ConverterStringEmCor(objCor.CodigoRGB);
            }
        }

        private void ExecutarGravar()
        {

            Comum.Clases.Cor objCor = new Comum.Clases.Cor();

            objCor.Descricao = txtNome.Text.Trim();
            objCor.CodigoRGB = _CorARGB;
            objCor.Identificador = _IdentificadorCor;


            ContratoServico.Cor.SetCor.PeticaoSetCor Peticao = new ContratoServico.Cor.SetCor.PeticaoSetCor()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Cor = objCor,
                IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Cor.SetCor.RespostaSetCor, ContratoServico.Cor.SetCor.PeticaoSetCor>(Peticao,
                  SDK.Operacoes.operacao.SetCor, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        #endregion

        #region "Eventos"

        private void btnCidade_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(_CorARGB))
                {

                    frmColor.Color = ConverterStringEmCor(_CorARGB);
                }


                if (frmColor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pnlCor.BackColor = frmColor.Color;
                    _CorARGB = frmColor.Color.A + "|" + frmColor.Color.R + "|" + frmColor.Color.G + "|" + frmColor.Color.B;
                }
                
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

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
