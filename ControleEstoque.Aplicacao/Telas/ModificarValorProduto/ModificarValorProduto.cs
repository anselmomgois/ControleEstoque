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
    public partial class ModificarValorProduto : TelaBase.BaseCE
    {

        #region "Variaveis"
        private CurrencyTextBox CurrencyTextBox;
        private List<Comum.Clases.ProdutoDisponivelVenda> ProdutosRegistrados = null;
        #endregion

        #region "Propriedades"
        public List<Comum.Clases.ProdutoDisponivelVenda> ProdutosRegistradosModificados { get; set; }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Construtor"

        public ModificarValorProduto(List<Comum.Clases.ProdutoDisponivelVenda> pProdutos)
        {
            InitializeComponent();

            if (pProdutos != null && pProdutos.Count > 0)
            {
                ProdutosRegistradosModificados = new List<Comum.Clases.ProdutoDisponivelVenda>();
                ProdutosRegistrados = new List<Comum.Clases.ProdutoDisponivelVenda>();

                foreach (Comum.Clases.ProdutoDisponivelVenda item in pProdutos)
                {
                    Comum.Clases.ProdutoDisponivelVenda item1 = item.Clone<Comum.Clases.ProdutoDisponivelVenda>();
                    ProdutosRegistrados.Add(item1);
                    Comum.Clases.ProdutoDisponivelVenda item2 = item.Clone<Comum.Clases.ProdutoDisponivelVenda>();
                    ProdutosRegistradosModificados.Add(item2);
                }                

            }
        }

        #endregion

        #region "Metodos"

        protected override void Inicializar()
        {
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpGeral);
            MontarMenu(false);
            CarregarTela();
        }

        private void CarregarTela()
        {
            if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
            CurrencyTextBox.Inicializar(ref txtNovoValor);

            rbAcrescimo.Checked = true;
            rbPreco.Checked = true;
            PreencherGrid(true);
            LimparSelecao();
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



        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvProdutos.Rows.Clear();

            List<Comum.Clases.ProdutoDisponivelVenda> ProdutosAgrupados = new List<Comum.Clases.ProdutoDisponivelVenda>();



            foreach (Comum.Clases.ProdutoDisponivelVenda p in ProdutosRegistrados.OrderBy(o => o.Produto.Codigo))
            {
                p.SequenciaAgrupada = Convert.ToString(p.Sequencia);
                Comum.Clases.ProdutoDisponivelVenda pg = null;
                if (ProdutosAgrupados != null && ProdutosAgrupados.Count > 0)
                {
                    pg = ProdutosAgrupados.FirstOrDefault(e => e.Produto.Codigo == p.Produto.Codigo);
                }

                if (pg != null)
                {
                    pg.SequenciaAgrupada += ", " + p.Sequencia;
                    pg.CantidadAgrupada += 1;
                    pg.NumValorVendaVarejo = p.NumValorVendaVarejo;
                    pg.NumQuantidadeVendido += p.NumQuantidadeVendido;
                    pg.NumValorAcrescimoCalculado += p.NumValorAcrescimoCalculado;
                    pg.NumValorDescontoCalculado += p.NumValorDescontoCalculado;
                    pg.NumValorPercentualModificado += p.NumValorPercentualModificado;
                    pg.NumValorProdutoCalculado += p.NumValorProdutoCalculado * p.NumQuantidadeVendido;
                }
                else
                {
                    p.NumValorProdutoCalculado = p.NumValorProdutoCalculado * p.NumQuantidadeVendido;
                    ProdutosAgrupados.Add(p);
                }
            }

            if (ProdutosAgrupados != null && ProdutosAgrupados.Count > 0)
            {

                dgvProdutos.Columns[colValor.Index].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-Br");

                int quantidade = 1;

                foreach (Comum.Clases.ProdutoDisponivelVenda p in ProdutosAgrupados)
                {
                    quantidade = p.SequenciaAgrupada.Split(',').Length;

                    dgvProdutos.Rows.Add();
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colSequencia.Index].Value = p.SequenciaAgrupada;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colQtdAgrupacao.Index].Value = quantidade;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colCodigo.Index].Value = p.Produto.Codigo;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colDescricao.Index].Value = p.Produto.Descricao;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colQuantidade.Index].Value = p.NumQuantidadeVendido;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colAcrescimo.Index].Value = p.NumValorAcrescimoCalculado;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colDesconto.Index].Value = p.NumValorDescontoCalculado;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colPorcentagem.Index].Value = p.NumValorPercentualModificado;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValor.Index].Value = p.NumValorVendaVarejo;

                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValorTotal.Index].Value = p.NumValorProdutoCalculado;

                }

                base.PreencherGrid(ExibirMensagem);

            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }

        #endregion

        #region "Eventos"
        private void btnAceitar_Click(object sender, EventArgs e)
        {
            try
            {
                // Atualizar objeto ProdutosRegistrados e sair da tela
                foreach (DataGridViewRow row in dgvProdutos.Rows)
                {

                    Comum.Clases.ProdutoDisponivelVenda produto = null;

                    string[] sequencias = (string[])row.Cells[colSequencia.Index].Value.ToString().Split(',');

                    for (int indice = 0; indice <= sequencias.Length - 1; indice++)
                    {
                        produto = (from p in ProdutosRegistradosModificados
                                   where p.Sequencia == Convert.ToInt32(sequencias[indice].Trim())
                                   select p).FirstOrDefault();

                        if (produto != null)
                        {
                            try
                            {
                                produto.NumValorAcrescimoCalculado = (Convert.ToDecimal(row.Cells[colAcrescimo.Index].Value));
                            }
                            catch (Exception ex)
                            {
                                produto.NumValorAcrescimoCalculado = 0;
                            }
                            try
                            {
                                produto.NumValorDescontoCalculado = (Convert.ToDecimal(row.Cells[colDesconto.Index].Value));
                            }
                            catch (Exception ex)
                            {
                                produto.NumValorDescontoCalculado = 0;
                            }
                            try
                            {
                                produto.NumValorPercentualModificado = (Convert.ToDecimal(row.Cells[colPorcentagem.Index].Value));
                            }
                            catch (Exception ex)
                            {
                                produto.NumValorPercentualModificado = 0;
                            }

                            try
                            {
                                if (sequencias.Length == 1)
                                {
                                    produto.NumValorProdutoCalculado = (Convert.ToDecimal(row.Cells[colValorTotal.Index].Value));
                                }
                                else
                                {
                                    if (produto.NumValorAcrescimoCalculado > 0)
                                    {
                                        produto.NumValorProdutoCalculado = (Convert.ToDecimal(row.Cells[colValor.Index].Value) * produto.NumQuantidadeVendido) + (produto.NumValorAcrescimoCalculado * produto.NumQuantidadeVendido);
                                    }
                                    else if (produto.NumValorDescontoCalculado > 0)
                                    {
                                        produto.NumValorProdutoCalculado = (Convert.ToDecimal(row.Cells[colValor.Index].Value) * produto.NumQuantidadeVendido) - (produto.NumValorDescontoCalculado * produto.NumQuantidadeVendido);
                                    }
                                    else
                                    {
                                        produto.NumValorProdutoCalculado = (Convert.ToDecimal(row.Cells[colValor.Index].Value) * produto.NumQuantidadeVendido);
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                produto.NumValorProdutoCalculado = 0;
                            }

                            produto.NumValorVendaVarejo = (decimal)row.Cells[colValor.Index].Value;

                        }

                    }

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

        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            txtNovoValor.Focus();
        }

        private void rbAcrescimo_CheckedChanged(object sender, EventArgs e)
        {
            txtNovoValor.Focus();
        }

        private void rbDesconto_CheckedChanged(object sender, EventArgs e)
        {
            txtNovoValor.Focus();
        }

        private void rbValorUnitario_CheckedChanged(object sender, EventArgs e)
        {
            rbPorcentagem.Visible = !rbValorUnitario.Checked;
            if (!rbPorcentagem.Visible)
            {
                rbPreco.Checked = true;
            }
            txtNovoValor.Focus();
        }

        private void ModificarValorProduto_Load(object sender, EventArgs e)
        {
            txtNovoValor.Focus();
        }

        private void txtNovoValor_Leave(object sender, EventArgs e)
        {
            try
            {
                if (dgvProdutos.CurrentRow != null)
                {
                    int indice = dgvProdutos.CurrentRow.Index;
                    int quantidadeAgrupacao = (int)dgvProdutos.CurrentRow.Cells[colQtdAgrupacao.Index].Value;

                    decimal quantidade = Convert.ToDecimal(dgvProdutos.CurrentRow.Cells[colQuantidade.Index].Value);

                    string[] sequencias = dgvProdutos.CurrentRow.Cells[colSequencia.Index].Value.ToString().Split(',');

                    decimal novoValor = Convert.ToDecimal(txtNovoValor.Text);
                    if (novoValor > 0)
                    {

                        if (rbAcrescimo.Checked)
                        {
                            if (rbPreco.Checked)
                            {

                                dgvProdutos.Rows[indice].Cells[colAcrescimo.Index].Value = novoValor;

                                decimal valorProduto = Convert.ToDecimal(dgvProdutos.Rows[indice].Cells[colValor.Index].Value);
                                novoValor = novoValor * quantidade;
                                decimal valorFinal = (valorProduto * quantidade) + novoValor;
                                dgvProdutos.Rows[indice].Cells[colValorTotal.Index].Value = valorFinal;

                                dgvProdutos.Rows[indice].Cells[colPorcentagem.Index].Value = "0";

                            }
                            else if (rbPorcentagem.Checked)
                            {

                                dgvProdutos.Rows[indice].Cells[colPorcentagem.Index].Value = novoValor;

                                decimal valorProduto = Convert.ToDecimal(dgvProdutos.Rows[indice].Cells[colValor.Index].Value);
                                decimal valorPorPorcentagem = (valorProduto * novoValor) / 100;

                                dgvProdutos.Rows[indice].Cells[colAcrescimo.Index].Value = valorPorPorcentagem;

                                valorPorPorcentagem = valorPorPorcentagem * quantidade;
                                dgvProdutos.Rows[indice].Cells[colValorTotal.Index].Value = valorProduto + valorPorPorcentagem;

                            }

                            dgvProdutos.Rows[indice].Cells[colDesconto.Index].Value = "0";
                            dgvProdutos.Rows[indice].Cells[colDesconto.Index].Value = "0";

                        }
                        else if (rbDesconto.Checked)
                        {

                            if (rbPreco.Checked)
                            {
                                decimal valorProduto = Convert.ToDecimal(dgvProdutos.Rows[indice].Cells[colValor.Index].Value);

                                if (novoValor > valorProduto)
                                {
                                    base.objNotificacao.ExibirMensagem("Valor do desconto não pode ser maior que o valor unitário do produto!", Controles.UcNotificacao.TipoImagem.INFORMACAO);
                                    return;
                                }

                                dgvProdutos.Rows[indice].Cells[colDesconto.Index].Value = novoValor;

                                novoValor = novoValor * quantidade;
                                decimal valorTotal = valorProduto * quantidade;

                                decimal valorFinal = valorTotal - novoValor;
                                if (valorFinal < 0)
                                {
                                    valorFinal = 0;
                                }
                                dgvProdutos.Rows[indice].Cells[colValorTotal.Index].Value = valorFinal;

                                dgvProdutos.Rows[indice].Cells[colPorcentagem.Index].Value = "0";

                            }
                            else if (rbPorcentagem.Checked)
                            {

                                decimal valorProduto = Convert.ToDecimal(dgvProdutos.Rows[indice].Cells[colValor.Index].Value);
                                decimal valorPorPorcentagem = (valorProduto * novoValor) / 100;

                                if ((valorPorPorcentagem * quantidade) > valorProduto)
                                {
                                    base.objNotificacao.ExibirMensagem("Valor do desconto não pode ser maior que o valor unitário do produto!", Controles.UcNotificacao.TipoImagem.INFORMACAO);
                                    return;
                                }

                                dgvProdutos.Rows[indice].Cells[colPorcentagem.Index].Value = novoValor;

                                decimal valorTotal = valorProduto * quantidade;

                                decimal valorFinal = valorTotal - (valorPorPorcentagem * quantidade);
                                if (valorFinal < 0)
                                {
                                    valorFinal = 0;
                                }

                                dgvProdutos.Rows[indice].Cells[colDesconto.Index].Value = valorPorPorcentagem;

                                dgvProdutos.Rows[indice].Cells[colValorTotal.Index].Value = valorFinal;

                            }

                            dgvProdutos.Rows[indice].Cells[colAcrescimo.Index].Value = "0";

                        }
                        else if (rbValorUnitario.Checked)
                        {
                            if (rbPreco.Checked)
                            {
                                dgvProdutos.Rows[indice].Cells[colValor.Index].Value = novoValor;
                                dgvProdutos.Rows[indice].Cells[colValorTotal.Index].Value = novoValor * quantidade;

                            }

                            dgvProdutos.Rows[indice].Cells[colDesconto.Index].Value = "0";
                            dgvProdutos.Rows[indice].Cells[colPorcentagem.Index].Value = "0";
                            dgvProdutos.Rows[indice].Cells[colAcrescimo.Index].Value = "0";

                        }

                        txtNovoValor.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void LimparSelecao()
        {
            dgvProdutos.ClearSelection();
            dgvProdutos.CurrentCell = null;
        }

        private void txtBuscarProduto_Leave(object sender, EventArgs e)
        {

            if (txtBuscarProduto.Text.Length == 0)
            {
                LimparSelecao();
            }
            else
            {
                int indiceRow = -1;
                string valor = txtBuscarProduto.Text.Trim();
                if (!string.IsNullOrEmpty(valor))
                {
                    try
                    {
                        foreach (DataGridViewRow row in dgvProdutos.Rows)
                        {
                            row.Selected = false;
                            string sequencia = row.Cells[colSequencia.Index].Value.ToString();
                            string[] sequencias = sequencia.Split(',');

                            if (sequencias.Length > 1)
                            {
                                for (int item = 0; item <= sequencias.Length - 1; item++)
                                {
                                    if (valor == sequencias[item].Trim())
                                    {
                                        indiceRow = row.Index;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (valor == sequencias[0])
                                {
                                    indiceRow = row.Index;
                                    break;
                                }
                            }

                        }

                    }
                    catch (Exception ex)
                    {
                        Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                    }

                }
                else
                {
                    LimparSelecao();
                }

                if (indiceRow >= 0)
                {
                    dgvProdutos.Rows[indiceRow].Selected = true;
                    dgvProdutos.CurrentCell = dgvProdutos.Rows[indiceRow].Cells[0];

                }
                else
                {
                    LimparSelecao();
                }

            }
        }

        private void txtBuscarProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.')
            {
                e.Handled = true;
            }
        }

        private void txtNovoValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            bool bHandled = false;
            // switch case is the easy way, a hash or map would be better, 
            // but more work to get set up.
            switch (keyData)
            {
                case Keys.F3:
                    txtBuscarProduto.Focus();
                    txtBuscarProduto.SelectAll();
                    break;
                case Keys.F4:
                    txtNovoValor.Focus();
                    txtNovoValor.SelectAll();
                    break;
                case Keys.F5:
                    rbAcrescimo.Checked = true;
                    break;
                case Keys.F6:
                    rbDesconto.Checked = true;
                    break;
                case Keys.F7:
                    rbValorUnitario.Checked = true;
                    break;
                case Keys.F8:
                    rbPreco.Checked = true;
                    break;
                case Keys.F9:
                    if (rbPorcentagem.Visible)
                    {
                        rbPorcentagem.Checked = true;
                    }
                    break;
            }
            return bHandled;
        }

    }

}
