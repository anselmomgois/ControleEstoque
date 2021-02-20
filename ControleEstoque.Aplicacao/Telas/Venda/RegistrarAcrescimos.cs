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
    public partial class RegistrarAcrescimos : TelaBase.BaseCE
    {

        #region "Variaveis"
        private CurrencyTextBox CurrencyTextBox;
        private List<Comum.Clases.ProdutoDisponivelVenda> ProdutosRegistrados = null;
        private List<Comum.Clases.ProdutoObservacao> _Observacoes = null;
        private decimal _Quantidade = 0;
        #endregion

        #region "Propriedades"
        public List<Comum.Clases.ProdutoDisponivelVenda> AcrescimosRetorno { get; set; }
        public List<Comum.Clases.ProdutoObservacao> ObservacoesRetorno { get; set; }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnAdicionarAcrescimo = "btnAdicionarAcrescimo";
        private const string btnAdicionarObservacao = "btnAdicionarObservacao";
        #endregion

        #region "Construtor"

        public RegistrarAcrescimos(List<Comum.Clases.ProdutoDisponivelVenda> pProdutos,
                                   List<Comum.Clases.ProdutoObservacao> Observacoes,
                                   decimal Quantidade)
        {
            InitializeComponent();

            _Observacoes = Observacoes;
            ProdutosRegistrados = pProdutos;
            _Quantidade = Quantidade;
        }

        #endregion

        #region "Metodos"

        protected override void Inicializar()
        {

            this.pnlBase.Controls.Add(tlpGeral);
            MontarMenu(false);
            base.Inicializar();
            CarregarTela();
        }

        private void CarregarTela()
        {
            ExecutarPreencherGrid(true);
            PreencherGridObservacoes();
            LimparSelecao();
            txtBuscarProduto.Focus();
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnAceitar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Adicionar Acrescimo (F3)", btnAdicionarAcrescimo, Properties.Resources.plus, new EventHandler(btnAdicionarAcrescimo_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Adicionar Observação (F4)", btnAdicionarObservacao, Properties.Resources.alert, new EventHandler(btnAdicionarObservacao_Click), Keys.F4, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar Acrescímo (F5)", btnAdicionarObservacao, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimparAcrescimo_Click), Keys.F5, false, false, false);

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

        private void PreencherGridObservacoes()
        {
            dgvObservacoes.Rows.Clear();

            if (_Observacoes != null && _Observacoes.Count > 0)
            {
                Int32 SequenciaObservacao = 0;

                foreach (Comum.Clases.ProdutoObservacao p in _Observacoes.OrderBy(o => o.Descricao))
                {

                    SequenciaObservacao += 1;
                    dgvObservacoes.Rows.Add();
                    dgvObservacoes.Rows[dgvObservacoes.Rows.Count - 1].Cells[colSequenciaObservacao.Index].Value = SequenciaObservacao;
                    dgvObservacoes.Rows[dgvObservacoes.Rows.Count - 1].Cells[colDescricaoObservacao.Index].Value = p.Descricao;
                    dgvObservacoes.Rows[dgvObservacoes.Rows.Count - 1].Cells[colIdentificadorObservacao.Index].Value = p.Identificador;

                }


            }
        }


        private void LimparSelecao()
        {
            dgvProdutos.ClearSelection();
            dgvProdutos.CurrentCell = null;
        }

        private void LimparSelecaoObservacao()
        {
            dgvObservacoes.ClearSelection();
            dgvObservacoes.CurrentCell = null;
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
                    decimal Quantidade = row.Cells[colQuantidade.Index].Value != null ? Convert.ToDecimal(row.Cells[colQuantidade.Index].Value) : 0;

                    if (Quantidade > 0)
                    {
                        string sequencia = row.Cells[colSequencia.Index].Value.ToString();

                        produto = (from p in ProdutosRegistrados
                                   where p.Sequencia == Convert.ToInt32(sequencia)
                                   select p).FirstOrDefault();

                        if (produto != null)
                        {

                            if (AcrescimosRetorno == null) { AcrescimosRetorno = new List<Comum.Clases.ProdutoDisponivelVenda>(); }

                            try
                            {
                                produto.NumQuantidadeVendido = (Convert.ToDecimal(row.Cells[colQuantidade.Index].Value));
                                AcrescimosRetorno.Add(produto.Clone<Comum.Clases.ProdutoDisponivelVenda>());

                            }
                            catch (Exception ex)
                            {
                                produto.NumQuantidadeVendido = 0;
                            }
                        }


                    }

                }

                if (dgvObservacoes != null && dgvObservacoes.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvObservacoes.Rows)
                    {
                        if (row.Cells[colSelecionar.Name].Value != null &&
                            Convert.ToBoolean(row.Cells[colSelecionar.Name].Value))
                        {
                            if (ObservacoesRetorno == null) { ObservacoesRetorno = new List<Comum.Clases.ProdutoObservacao>(); }

                            ObservacoesRetorno.Add(new Comum.Clases.ProdutoObservacao()
                            {
                                Descricao = row.Cells[colDescricaoObservacao.Name].Value as string,
                                Identificador = row.Cells[colIdentificadorObservacao.Name].Value as string
                            });
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

        private void btnAdicionarObservacao_Click(object sender, EventArgs e)
        {
            try
            {

                txtSequenciaObservacao.Text = string.Empty;
                txtSequenciaObservacao.Focus();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimparAcrescimo_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvProdutos.Rows)
                {
                    row.Selected = false;
                    row.Cells[colQuantidade.Index].Value = 0;
                    row.Cells[colValorTotal.Index].Value = 0;

                }

                txtBuscarProduto.Text = string.Empty;
                txtBuscarProduto.Focus();


            }

            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnAdicionarAcrescimo_Click(object sender, EventArgs e)
        {
            try
            {

                txtBuscarProduto.Text = string.Empty;
                txtBuscarProduto.Focus();


            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }



        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void txtSequenciaObservacao_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.Enter)
                {
                    if (txtSequenciaObservacao.Text.Length == 0)
                    {
                        LimparSelecaoObservacao();
                    }
                    else
                    {
                        int indiceRow = -1;
                        string valor = txtSequenciaObservacao.Text.Trim();
                        if (!string.IsNullOrEmpty(valor))
                        {
                            try
                            {
                                foreach (DataGridViewRow row in dgvObservacoes.Rows)
                                {
                                    row.Selected = false;
                                    string sequencia = row.Cells[colSequenciaObservacao.Index].Value.ToString();
                                    string[] sequencias = valor.Split(',');

                                    if (sequencias.Length > 1)
                                    {
                                        for (int item = 0; item <= sequencias.Length - 1; item++)
                                        {
                                            if (sequencia == sequencias[item].Trim())
                                            {
                                                row.Cells[colSelecionar.Index].Value = true;
                                                indiceRow = row.Index;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (valor == sequencia)
                                        {
                                            row.Cells[colSelecionar.Index].Value = true;
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
                            LimparSelecaoObservacao();
                        }

                        if (indiceRow >= 0)
                        {
                            dgvObservacoes.Rows[indiceRow].Selected = true;
                            dgvObservacoes.CurrentCell = dgvObservacoes.Rows[indiceRow].Cells[colSequenciaObservacao.Index];
                            txtSequenciaObservacao.Text = string.Empty;
                            txtSequenciaObservacao.Focus();

                        }
                        else
                        {
                            LimparSelecaoObservacao();
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


                            if (dgvProdutos.CurrentRow != null)
                            {
                                int indice = dgvProdutos.CurrentRow.Index;
                                int quantidadeAgrupacao = (int)dgvProdutos.CurrentRow.Cells[colQtdAgrupacao.Index].Value;



                                decimal novoValor = _Quantidade;
                                if (novoValor > 0)
                                {

                                    dgvProdutos.CurrentRow.Cells[colQuantidade.Index].Value = novoValor;

                                    decimal quantidade = Convert.ToDecimal(dgvProdutos.CurrentRow.Cells[colQuantidade.Index].Value);

                                    decimal valorProduto = Convert.ToDecimal(dgvProdutos.Rows[indice].Cells[colValor.Index].Value);
                                    novoValor = novoValor * quantidade;
                                    decimal valorFinal = (valorProduto * quantidade);
                                    dgvProdutos.Rows[indice].Cells[colValorTotal.Index].Value = valorFinal;



                                    txtBuscarProduto.Text = string.Empty;
                                    txtBuscarProduto.Focus();
                                }
                            }

                        }
                        else
                        {
                            LimparSelecao();
                        }

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
