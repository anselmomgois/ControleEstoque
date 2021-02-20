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
    public partial class CancelarItems : TelaBase.BaseCE
    {

        #region "Variaveis"
        private List<Comum.Clases.ItemVenda> ProdutosRegistrados = null;
        private string _IdentificadorVenda;
        private string _IdentificadorSupervisorCancelamento;
        #endregion

        #region "Propriedades"
        public List<Comum.Clases.ItemVenda> ProdutosCancelados { get; set; }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Construtor"

        public CancelarItems(List<Comum.Clases.ItemVenda> pProdutos, string IdentificadorVenda, string IdentificadorSupervisorCancelamento)
        {
            InitializeComponent();

            _IdentificadorVenda = IdentificadorVenda;
            _IdentificadorSupervisorCancelamento = IdentificadorSupervisorCancelamento;

            if (pProdutos != null && pProdutos.Count > 0)
            {
                ProdutosRegistrados = new List<Comum.Clases.ItemVenda>();

                foreach (Comum.Clases.ItemVenda item in pProdutos)
                {
                    Comum.Clases.ItemVenda item1 = item.Clone<Comum.Clases.ItemVenda>();
                    ProdutosRegistrados.Add(item1);
                }

            }
        }

        #endregion

        #region "Metodos"

        protected override void Inicializar()
        {
            this.pnlBase.Controls.Add(tlpGeral);
            MontarMenu(false);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {
            PreencherGrid(true);
            LimparSelecao();
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar Seleção (F3)", btnAceitar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimparSelecao_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CancelarItems)
            {

                ProdutosCancelados = (List<Comum.Clases.ItemVenda>)Parametros.ParametroGenerico;

                base.objNotificacao.ExibirMensagem("Items cancelados com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                this.DialogResult = DialogResult.OK;
            }

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvProdutos.Rows.Clear();

            if (ProdutosRegistrados != null && ProdutosRegistrados.Count > 0)
            {

                dgvProdutos.Columns[colValor.Index].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("pt-Br");

                int quantidade = 1;

                foreach (Comum.Clases.ItemVenda p in ProdutosRegistrados.OrderBy(p => p.Sequencia))
                {
                    dgvProdutos.Rows.Add();
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colSequencia.Index].Value = p.Sequencia;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colCodigo.Index].Value = p.Produto.Codigo;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colDescricao.Index].Value = p.Produto.Descricao;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colQuantidade.Index].Value = p.Quantidade;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValor.Index].Value = p.ValorItem;
                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Cells[colValorTotal.Index].Value = p.ValorTotal;

                    dgvProdutos.Rows[dgvProdutos.Rows.Count - 1].Tag = p;

                }

                base.PreencherGrid(ExibirMensagem);

            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }

        private void LimparSelecao()
        {
            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                row.Cells[colChkProduto.Name].Value = false;
            }

            dgvProdutos.ClearSelection();
            dgvProdutos.CurrentCell = null;
        }

        #endregion

        #region "Eventos"
        private void btnAceitar_Click(object sender, EventArgs e)
        {
            try
            {
                List<Comum.Clases.ItemVenda> produtos = new List<Comum.Clases.ItemVenda>();

                // Atualizar objeto ProdutosRegistrados e sair da tela
                foreach (DataGridViewRow row in dgvProdutos.Rows)
                {


                    if (row.Cells[colChkProduto.Name].Value != null && Convert.ToBoolean(row.Cells[colChkProduto.Name].Value))
                    {
                        produtos.Add((Comum.Clases.ItemVenda)row.Tag);
                    }

                }

                if (produtos != null && produtos.Count > 0)
                {

                    ContratoServico.Venda.CancelarItems.PeticaoCancelarItems Peticao = new ContratoServico.Venda.CancelarItems.PeticaoCancelarItems()
                    {
                        Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                        IdentificadorVenda = _IdentificadorVenda,
                        IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                        IdentificadorSupervisorCancelamento = _IdentificadorSupervisorCancelamento,
                        Items = produtos
                    };

                    Agente.Agente.InvocarServico<ContratoServico.Venda.CancelarItems.RespostaCancelarItems, ContratoServico.Venda.CancelarItems.PeticaoCancelarItems>(Peticao,
                          SDK.Operacoes.operacao.CancelarItems, new Comum.ParametrosTela.Generica() { ParametroGenerico = produtos }, null, true);

                }
                else
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, "Nenhum produto selecionado.");
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimparSelecao_Click(object sender, EventArgs e)
        {
            try
            {
                LimparSelecao();
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colChkProduto.Index)
                        {
                            dgvProdutos.Rows[e.RowIndex].Cells[colChkProduto.Name].Value = dgvProdutos.Rows[e.RowIndex].Cells[colChkProduto.Name].Value != null ?
                                                                                            !Convert.ToBoolean(dgvProdutos.Rows[e.RowIndex].Cells[colChkProduto.Name].Value) : true;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutos_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProdutos.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colChkProduto.Index)
                        {
                            //Define o cursor para Hand
                            Cursor.Current = Cursors.Hand;
                        }
                        else
                        {
                            //Define o cursor para default
                            Cursor.Current = Cursors.Default;
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtBuscarProduto_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (string.IsNullOrEmpty(txtBuscarProduto.Text.Trim()))
                    {
                        LimparSelecao();
                    }
                    else
                    {
                        int indiceRow = -1;
                        string[] valores = txtBuscarProduto.Text.Trim().Split(Convert.ToChar(";"));

                        foreach (var valor in valores)
                        {
                            foreach (DataGridViewRow row in dgvProdutos.Rows)
                            {
                                row.Selected = false;
                                string sequencia = row.Cells[colSequencia.Index].Value.ToString();

                                if (valor == sequencia)
                                {
                                    indiceRow = row.Index;
                                    break;
                                }
                            }

                            if (indiceRow >= 0)
                            {
                                dgvProdutos.Rows[indiceRow].Selected = true;
                                dgvProdutos.CurrentCell = dgvProdutos.Rows[indiceRow].Cells[0];
                                dgvProdutos.Rows[indiceRow].Cells[0].Value = true;

                            }
                            else
                            {
                                LimparSelecao();
                            }
                        }

                        txtBuscarProduto.Text = string.Empty;
                        txtBuscarProduto.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        #endregion
    }

}
