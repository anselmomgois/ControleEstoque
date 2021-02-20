using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class ResumoPagamentoVenda : TelaBase.BaseCE
    {
        #region "Construtor"

        public ResumoPagamentoVenda(List<Comum.Clases.Pagamento> Pagamentos, decimal ValorTotalVenda, decimal Troco)
        {
            InitializeComponent();

            _Pagamentos = Pagamentos;
            _ValorTotalVenda = ValorTotalVenda;
            _Troco = Troco;
        }

        #endregion

        #region"Variaveis"

        private List<Comum.Clases.Pagamento> _Pagamentos;
        private decimal _ValorTotalVenda;
        private decimal _Troco;
        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {


            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbPagamentos);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {
            ExecutarPreencherGrid(false);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvMarcas.Rows.Clear();

            if (_Pagamentos != null && _Pagamentos.Count > 0)
            {

                var Somatorio = from Comum.Clases.Pagamento p in _Pagamentos
                                group p by p.FormaPagamento.Codigo into Soma
                                select new
                                {
                                    FormaPagamento = Soma.First().FormaPagamento.Descricao,
                                    Total = Soma.Sum(su => su.Valor),
                                    Identificador = Soma.First().FormaPagamento.Identificador
                                };


                foreach (var p in Somatorio.OrderBy(p => p.FormaPagamento))
                {
                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = p.FormaPagamento;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = p.Total;


                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Tag = p;

                }

                decimal ValorPagamentos = _Pagamentos.Sum(s => s.Valor);

                dgvMarcas.Rows.Add();
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = "TOTAL VENDA";
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = _ValorTotalVenda;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Style.ForeColor = Color.Red;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Style.Font = new Font(dgvMarcas.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold);
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Style.Font = new Font(dgvMarcas.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold);

                dgvMarcas.Rows.Add();
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = "TOTAL PAGO";
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = ValorPagamentos;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Style.ForeColor = Color.Blue;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Style.Font = new Font(dgvMarcas.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold);
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Style.Font = new Font(dgvMarcas.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold);



                if (_Troco > 0)
                {

                    decimal troco = ValorPagamentos - _ValorTotalVenda;

                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = "TROCO";
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = _Troco;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Style.ForeColor = Color.Green;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Style.Font = new Font(dgvMarcas.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold);
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Style.Font = new Font(dgvMarcas.DefaultCellStyle.Font.FontFamily, 12, FontStyle.Bold);


                }

                base.PreencherGrid(ExibirMensagem);

            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

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

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }


        #endregion
    }
}
