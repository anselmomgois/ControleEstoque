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
    public partial class CancelarItemsTouch : TelaBase.BaseCE
    {

        #region "Variaveis"
        private List<Comum.Clases.ItemVenda> ProdutosRegistrados = null;
        private string _IdentificadorVenda;
        private string _IdentificadorSupervisorCancelamento;
        private Controles.ucTexboxTeclado _ucTextBoxBuscaProduto = null;
        private decimal _Quantidade = 0;
        #endregion

        #region "Propriedades"
        public List<Comum.Clases.ItemVenda> ProdutosCancelados { get; set; }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Construtor"

        public CancelarItemsTouch(List<Comum.Clases.ItemVenda> pProdutos, string IdentificadorVenda, string IdentificadorSupervisorCancelamento)
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
            this.CarregarControleBuscaProduto();
            this.PreencherGrid(true);
            this.LimparSelecao();
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar", btnAceitar, Properties.Resources.save, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar Seleção", btnAceitar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimparSelecao_Click), Keys.F3, false, false, false);

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

        private void CarregarControleBuscaProduto()
        {
            _ucTextBoxBuscaProduto = new Controles.ucTexboxTeclado(pnlTxtBuscaProduto.Location.X + 8, pnlTxtBuscaProduto.Location.Y + 135, new FontFamily("Arial"), true, 25, this, true, 50, 50);

            _ucTextBoxBuscaProduto.Dock = DockStyle.Fill;

            _ucTextBoxBuscaProduto.GetValorDigitado += _ucTextBoxBuscaProduto_GetValorDigitado;
            _ucTextBoxBuscaProduto.LimparValor += _ucTextBoxBuscaProduto_LimparValor;
            _ucTextBoxBuscaProduto.Focus();

            pnlTxtBuscaProduto.Controls.Add(_ucTextBoxBuscaProduto);
        }

        private void _ucTextBoxBuscaProduto_GetValorDigitado(string Item)
        {
            try
            {
                if (string.IsNullOrEmpty(Item))
                {
                    LimparSelecao();
                }
                else
                {
                    int indiceRow = -1;
                    string valor = Item.Trim();
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


                        if (dgvProdutos.CurrentRow != null)
                        {
                            int indice = dgvProdutos.CurrentRow.Index;
                           
                            decimal novoValor = _Quantidade;
                            if (novoValor > 0)
                            {

                                dgvProdutos.CurrentRow.Cells[colQuantidade.Index].Value = novoValor;

                                decimal quantidade = Convert.ToDecimal(dgvProdutos.CurrentRow.Cells[colQuantidade.Index].Value);

                                decimal valorProduto = Convert.ToDecimal(dgvProdutos.Rows[indice].Cells[colValor.Index].Value);
                                novoValor = novoValor * quantidade;
                                decimal valorFinal = (valorProduto * quantidade);
                                dgvProdutos.Rows[indice].Cells[colValorTotal.Index].Value = valorFinal;



                                _ucTextBoxBuscaProduto.Focus();
                            }
                        }

                    }
                    else
                    {
                        LimparSelecao();
                    }
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

        private void _ucTextBoxBuscaProduto_LimparValor(object sender, EventArgs e)
        {
            try
            {
                _ucTextBoxBuscaProduto.SetarValor(null);
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
