using AmgSistemas.Framework.Componentes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class AcrescimoDescontoFechamentoVenda : TelaBase.BaseCE
    {

        #region "Variaveis"
        private CurrencyTextBox CurrencyTextBox;
        private decimal _valorVenda;
        #endregion

        #region "Propriedades"

        public decimal ValorInformado;
        public decimal ValorTotalModificado;
        public decimal ValorCalculado;
        public bool Desconto;
        public bool Acrescimo;
        public bool PorPorcentagem;
        public bool PorPreco;
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Construtor"

        public AcrescimoDescontoFechamentoVenda(decimal ValorVenda, decimal Valor, bool Acrescimo, bool Desconto, bool PorPorcentagem, bool PorPreco)
        {
            InitializeComponent();
            pnlBase.Controls.Add(tlpGeral);
            _valorVenda = ValorVenda;

            rbAcrescimo.Checked = Acrescimo;
            rbDesconto.Checked = Desconto;
            rbPorcentagem.Checked = PorPorcentagem;
            rbPreco.Checked = PorPreco;
            txtNovoValor.Text = Valor.ToString("N2");

            if (!Acrescimo && !Desconto)
            {
                rbAcrescimo.Checked = true;
            }

            if (!PorPorcentagem && !PorPreco)
            {
                rbPreco.Checked = true;
            }

            txtNovoValor.Focus();
            txtNovoValor.SelectAll();
        }

        #endregion

        #region "Metodos"

        protected override void Inicializar()
        {
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpGeral);
            MontarMenu(false);
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        #endregion

        #region "Eventos"
        private void btnAceitar_Click(object sender, EventArgs e)
        {
            try
            {
                Desconto = rbDesconto.Checked;
                Acrescimo = rbAcrescimo.Checked;
                PorPorcentagem = rbPorcentagem.Checked;
                PorPreco = rbPreco.Checked;
                ValorInformado = !string.IsNullOrEmpty(txtNovoValor.Text) ? Convert.ToDecimal(txtNovoValor.Text) : 0;

                if (Acrescimo && PorPorcentagem)
                {
                    ValorCalculado = (_valorVenda * ValorInformado) / 100;
                    ValorTotalModificado = _valorVenda + ValorCalculado;
                }

                if (Acrescimo && PorPreco)
                {
                    ValorCalculado = ValorInformado;
                    ValorTotalModificado = _valorVenda + ValorCalculado;
                }

                if (Desconto && PorPorcentagem)
                {
                    ValorCalculado = (_valorVenda * ValorInformado) / 100;
                    ValorTotalModificado = _valorVenda - ValorCalculado;
                }

                if (Desconto && PorPreco)
                {
                    ValorCalculado = ValorInformado;
                    ValorTotalModificado = _valorVenda - ValorCalculado;
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

        private void txtNovoValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtNovoValor_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtNovoValor);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }

}
