using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    public partial class ucGridVenda : UserControl
    {

        #region"Variaveis"
        private List<string> _CoresGeradas = new List<string>();
        private bool _TelaTouch = false;
        #endregion

        public ucGridVenda(bool TelaTouch)
        {
            InitializeComponent();
            _TelaTouch = TelaTouch;

            if(TelaTouch)
            {
                dgvMarcas.Columns[colCodigoBarras.Index].Visible = false;
                dgvMarcas.Columns[colDesconto.Index].Visible = false;
                dgvMarcas.Columns[colAcrescimo.Index].Visible = false;
            }
        }

        public void LimparGrid()
        {
            dgvMarcas.Rows.Clear();
            _CoresGeradas = new List<string>();
        }

        public void AdicionarItemGrid(Comum.Clases.ProdutoDisponivelVenda ProdutoVenda)
        {

            if (ProdutoVenda != null)
            {
                dgvMarcas.Rows.Add();
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Name].Value = ProdutoVenda.Produto.Identificador;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Name].Value = ProdutoVenda.Produto.Descricao;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCodigo.Name].Value = ProdutoVenda.Produto.Codigo;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colItem.Name].Value = ProdutoVenda.Sequencia;
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colQuantidade.Name].Value = ProdutoVenda.NumQuantidadeVendido;

                if (ProdutoVenda.Produto.CodigosBarras != null && ProdutoVenda.Produto.CodigosBarras.Count > 0)
                {
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCodigoBarras.Name].Value = System.String.Join(Environment.NewLine, ProdutoVenda.Produto.CodigosBarras.Select(cb => cb.CodigoBarras).ToArray());
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Height = 15 * ProdutoVenda.Produto.CodigosBarras.Count;
                }

                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = ProdutoVenda.NumValorVendaVarejo != null ? Convert.ToDecimal(ProdutoVenda.NumValorVendaVarejo).ToString("N2") : "0,00";
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDesconto.Name].Value = ProdutoVenda.NumValorDescontoCalculado.ToString("N2");
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescontoTotal.Name].Value = (ProdutoVenda.NumValorDescontoCalculado * ProdutoVenda.NumQuantidadeVendido).ToString("N2");

                if (ProdutoVenda.CalculoTotalEfetuado)
                {
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValorTotal.Name].Value = ProdutoVenda.NumValorProdutoCalculado.ToString("N2");
                }
                else
                {
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValorTotal.Name].Value = (ProdutoVenda.NumValorProdutoCalculado * ProdutoVenda.NumQuantidadeVendido).ToString("N2");
                }


                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAcrescimo.Name].Value = ProdutoVenda.NumValorAcrescimoCalculado.ToString("N2");
                dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAcrescimoTotal.Name].Value = (ProdutoVenda.NumValorAcrescimoCalculado * ProdutoVenda.NumQuantidadeVendido).ToString("N2");

                ColorConverter objconverter = new ColorConverter();

                Color color = Color.Black;

                if ((ProdutoVenda.Acrescimos != null && ProdutoVenda.Acrescimos.Count > 0) ||
                    (ProdutoVenda.Observacoes != null && ProdutoVenda.Observacoes.Count > 0))
                {

                    string strColor = RetornaNomeCor();
                    if (!string.IsNullOrEmpty(strColor))
                        color = (Color)objconverter.ConvertFromString(strColor);

                    color = ControlPaint.Light(color);
                }

                if (ProdutoVenda.Acrescimos != null && ProdutoVenda.Acrescimos.Count > 0)
                {


                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = color;

                    foreach (var a in ProdutoVenda.Acrescimos)
                    {

                        dgvMarcas.Rows.Add();
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = color;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvMarcas.DefaultCellStyle.Font, FontStyle.Bold);
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Green;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Name].Value = a.Identificador;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Name].Value = string.Format("{0} - Acrescímo Item: {1}", a.Descricao, ProdutoVenda.Sequencia);
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCodigo.Name].Value = a.Codigo;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colItem.Name].Value = "AC";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colQuantidade.Name].Value = a.Quantidade.ToString("N2");
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = a.ValorItem.ToString("N2");
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDesconto.Name].Value = "0,00";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescontoTotal.Name].Value = "0,00";

                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValorTotal.Name].Value = a.ValorTotal.ToString("N2");
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAcrescimo.Name].Value = "0,00";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAcrescimoTotal.Name].Value = "0,00";
                    }
                }

                if (ProdutoVenda.Observacoes != null && ProdutoVenda.Observacoes.Count > 0)
                {
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = color;

                    foreach (var a in ProdutoVenda.Observacoes)
                    {

                        dgvMarcas.Rows.Add();
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = color;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvMarcas.DefaultCellStyle.Font, FontStyle.Italic);
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Red;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Name].Value = a.Identificador;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Name].Value = string.Format("{0} - Observação Item: {1}", a.Descricao, ProdutoVenda.Sequencia);
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colItem.Name].Value = "OBS";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colQuantidade.Name].Value = "0,00";

                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValor.Name].Value = "0,00";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDesconto.Name].Value = "0,00";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescontoTotal.Name].Value = "0,00";

                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValorTotal.Name].Value = "0,00";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAcrescimo.Name].Value = "0,00";
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAcrescimoTotal.Name].Value = "0,00";
                    }
                }

                if (ProdutoVenda.Acrescimos != null && ProdutoVenda.Acrescimos.Count > 0)
                {
                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = color;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.Font = new Font(dgvMarcas.DefaultCellStyle.Font, FontStyle.Bold);
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.ForeColor = Color.Orange;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Name].Value = string.Format("Total Item: {0} - {1}", ProdutoVenda.Sequencia, ProdutoVenda.Produto.Descricao);
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colItem.Name].Value = "TOT";
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValorTotal.Name].Value = (((ProdutoVenda.NumValorProdutoCalculado * ProdutoVenda.NumQuantidadeVendido) + ProdutoVenda.Acrescimos.Sum(sa => sa.ValorTotal))).ToString("N2");

                }
            }

        }

        private string RetornaNomeCor()
        {
            Random random = new Random();
            string cor = string.Empty;
            Boolean _corexiste = true;

            while (_corexiste)
            {
                int r = int.Parse(random.Next(255).ToString());
                int g = int.Parse(random.Next(255).ToString());
                int b = int.Parse(random.Next(255).ToString());
                int a = int.Parse(random.Next(255).ToString());
                cor = string.Format("#{0}", Color.FromArgb(a, r, g, b).Name.ToUpper().Substring(0, 6));

                if (!_CoresGeradas.Exists(c => c == cor))
                {
                    _CoresGeradas.Add(cor);
                    _corexiste = false;
                }
            }


            return cor;
        }
    }
}
