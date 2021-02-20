using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoCompra : TelaBase.BaseCE
    {
        public GuardarProdutoCompra(List<Comum.Clases.ProdutoCompra> Produtos, string IdentificadorFilial)
        {
            InitializeComponent();
            _produtos = Produtos;
            _IdentificadorFilial = IdentificadorFilial;
        }

        #region "Variaveis"

        private List<Comum.Clases.ProdutoServico> ProdutosServicos = null;
        private List<Comum.Clases.ProdutoServico> ProdutosServicosMemoria = null;
        private List<Comum.Clases.ProdutoServico> ProdutosServicosCombo = null;
        private List<Comum.Clases.ProdutoCompra> _produtos;
        private string _IdentificadorFilial;
        private ControleFoco ControleCorrete;

        #endregion
        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        private const string btnCancelar = "btnCancelar";
        #endregion
        #region "Ënum"
        private enum ControleFoco
        {
            CodigoProduto = 1,
            CodigoBarras = 2,
            Descricao = 3
        }

        #endregion

        #region  "Propriedades"
        public List<Comum.Clases.ProdutoCompra> ProdutosSelecionados { get; set; }
        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo, Boolean GerarBotaoSair)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources.aceitar, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F4)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F4, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Sair (F11)", btnCancelar, Properties.Resources.exit, new EventHandler(btnCancelar_Click), Keys.F11, false, false, false);
            base.MontarMenu(GerarGrupo,false);
        }

        protected override void Inicializar()
        {
            MontarMenu(false,false);
            base.Inicializar();
            PreencherGridProdutosSelecionados();
            RecuperarProdutosServicos(true, false);
            this.pnlBase.Controls.Add(tlpClientes);
            tlpClientes.Dock = DockStyle.Fill;
        }

        private void SetarFocoControle(ControleFoco Foco)
        {
            switch (Foco)
            {
                case ControleFoco.CodigoBarras:
                    txtCodigoBarras.Focus();
                    break;
                case ControleFoco.CodigoProduto:
                    txtCodigo.Focus();
                    break;
                case ControleFoco.Descricao:
                    cmbDescricao.Focus();
                    break;
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

            txtCodigoBarras.Focus();
        }

        private void RecuperarProdutosServicos(Boolean ExibirMensagemNenhumRegistro, Boolean Enter)
        {
            
            ContratoServico.ProdutoServico.RecuperarProdutosServicos.PeticaoRecuperarProdutosServicos Peticao = new ContratoServico.ProdutoServico.RecuperarProdutosServicos.PeticaoRecuperarProdutosServicos()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                IdentificadorFilial = _IdentificadorFilial,
                RecuperarUnidadeMedida = true
            };

            Agente.Agente.InvocarServico<ContratoServico.ProdutoServico.RecuperarProdutosServicos.RespostaRecuperarProdutosServicos, ContratoServico.ProdutoServico.RecuperarProdutosServicos.PeticaoRecuperarProdutosServicos>(Peticao,
                  SDK.Operacoes.operacao.RecuperarProdutosServicos, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, Enter = Enter, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarProdutosServicos)
            {
                ProdutosServicosMemoria = ((ContratoServico.ProdutoServico.RecuperarProdutosServicos.RespostaRecuperarProdutosServicos)objSaida).ProdutosServicos;

            }

        }

        private void ListarProdutos()
        {
            if (ProdutosServicosMemoria != null && ProdutosServicosMemoria.Count > 0)
            {
                ProdutosServicos = (from Comum.Clases.ProdutoServico ps in ProdutosServicosMemoria
                                    where (string.IsNullOrEmpty(txtCodigo.Text) || (!string.IsNullOrEmpty(txtCodigo.Text) && ps.Codigo == Convert.ToInt32(txtCodigo.Text))) &&
                                          (string.IsNullOrEmpty(txtCodigoBarras.Text) || (!string.IsNullOrEmpty(txtCodigoBarras.Text) && (ps.CodigosBarras != null && ps.CodigosBarras.Count > 0 && ps.CodigosBarras.Exists(cb => cb.CodigoBarras == txtCodigoBarras.Text)))) &&
                                          (string.IsNullOrEmpty(cmbDescricao.SelectedText) || (!string.IsNullOrEmpty(cmbDescricao.SelectedText) &&
                                           (ps.Descricao.ToUpper().Contains(cmbDescricao.Text.ToUpper()) ||
                                         ps.Codigo.ToString().Contains(cmbDescricao.Text.ToUpper()) ||
                                         (ps.CodigosBarras != null && ps.CodigosBarras.Count > 0 && ps.CodigosBarras.Exists(cb => cb.CodigoBarras.Contains(cmbDescricao.Text.ToUpper()))))))
                                    select ps).ToList();

                if (ProdutosServicos != null)
                {
                    ProdutosServicos.RemoveAll(ps => _produtos != null && _produtos.Exists(p => p.Produto != null && p.Produto.Identificador == ps.Identificador));
                }

                if (ProdutosServicos != null && ProdutosServicos.Count == 1)
                {
                    AdicionarProduto(ProdutosServicos.FirstOrDefault().Identificador);
                }
                else
                {
                    ExecutarPreencherGrid(true);
                    dgvProdutoServico.Focus();
                    dgvProdutoServico.Rows[0].Selected = true;
                }
            }
        }

        private void ListarProdutosCombo()
        {
            if (ProdutosServicosMemoria != null && ProdutosServicosMemoria.Count > 0 && !cmbDescricao.DroppedDown)
            {
                cmbDescricao.Items.Clear();

                ProdutosServicosCombo = (from Comum.Clases.ProdutoServico ps in ProdutosServicosMemoria
                                         where !string.IsNullOrEmpty(cmbDescricao.Text) &&
                                         (ps.Descricao.ToUpper().Contains(cmbDescricao.Text.ToUpper()) ||
                                          ps.Codigo.ToString().Contains(cmbDescricao.Text.ToUpper()) ||
                                          (ps.CodigosBarras != null && ps.CodigosBarras.Count > 0 && ps.CodigosBarras.Exists(cb => cb.CodigoBarras.ToUpper().Contains(cmbDescricao.Text.ToUpper()))))
                                         select ps).ToList();

                if (ProdutosServicosCombo != null)
                {
                    ProdutosServicosCombo.RemoveAll(ps => _produtos != null && _produtos.Exists(p => p.Produto != null && p.Produto.Identificador == ps.Identificador));

                    if (ProdutosServicosCombo != null && ProdutosServicosCombo.Count > 0)
                    {
                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(ProdutosServicosCombo, "Identificador", "Descricao");
                        cmbDescricao = frmWindows.Util.PreencherCombobox(cmbDescricao, Items);
                        cmbDescricao.DroppedDown = true;

                    }
                }

            }
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {

            dgvProdutoServico.Rows.Clear();

            if (ProdutosServicos != null && ProdutosServicos.Count > 0)
            {


                foreach (Comum.Clases.ProdutoServico c in ProdutosServicos)
                {

                    dgvProdutoServico.Rows.Add();
                    dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colIdProdutoServico.Index].Value = c.Identificador;
                    dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colCodigo.Index].Value = c.Codigo;
                    dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colCodigoBarras.Index].Value = (c.CodigosBarras != null && c.CodigosBarras.Count > 0 ? string.Join(Environment.NewLine, c.CodigosBarras.Select(cb => cb.CodigoBarras)) : string.Empty);

                    if (c.CodigosBarras != null && c.CodigosBarras.Count > 1)
                    {
                        dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Height = 20 * c.CodigosBarras.Count;
                    }

                }
            }
        }

        private void PreencherGridProdutosSelecionados()
        {
            dgvProdutosSelecionados.Rows.Clear();

            if (_produtos != null && _produtos.Count > 0)
            {


                foreach (Comum.Clases.ProdutoCompra c in _produtos)
                {

                    dgvProdutosSelecionados.Rows.Add();
                    dgvProdutosSelecionados.Rows[dgvProdutosSelecionados.Rows.Count - 1].Cells[colIdProdutoServSel.Index].Value = c.Produto.Identificador;
                    dgvProdutosSelecionados.Rows[dgvProdutosSelecionados.Rows.Count - 1].Cells[colCodigoBarrasSel.Index].Value = (c.Produto.CodigosBarras != null && c.Produto.CodigosBarras.Count > 0 ? string.Join(Environment.NewLine, c.Produto.CodigosBarras.Select(cb => cb.CodigoBarras)) : string.Empty);
                    dgvProdutosSelecionados.Rows[dgvProdutosSelecionados.Rows.Count - 1].Cells[colCodigoSelecionado.Index].Value = c.Produto.Codigo;
                    dgvProdutosSelecionados.Rows[dgvProdutosSelecionados.Rows.Count - 1].Cells[colDescricaoSelecionado.Index].Value = c.Produto.Descricao;

                   if (c.Produto.CodigosBarras != null && c.Produto.CodigosBarras.Count > 1)
                    {
                        dgvProdutosSelecionados.Rows[dgvProdutosSelecionados.Rows.Count - 1].Height = 20 * c.Produto.CodigosBarras.Count;
                    }

                }
            }

        }

        private void AdicionarProduto(string IdentificadorProdutoServico)
        {


            Comum.Clases.ProdutoCompra objProduto = (from Comum.Clases.ProdutoServico p in ProdutosServicos
                                                     where p.Identificador == IdentificadorProdutoServico
                                                     select new Comum.Clases.ProdutoCompra()
                                                     {
                                                         Produto = p,
                                                         IdentificadorProdutoFilial = p.IdentificadorProdutoFilial
                                                     }).FirstOrDefault();

            if (objProduto != null)
            {
                if (_produtos == null) { _produtos = new List<Comum.Clases.ProdutoCompra>(); }

                if (!_produtos.Exists(p => p.Produto.Identificador == objProduto.Produto.Identificador))
                {
                    ProdutosServicos.RemoveAll(p => p.Identificador == objProduto.Produto.Identificador);
                    _produtos.Add(objProduto);
                }
                ExecutarPreencherGrid(false);
                PreencherGridProdutosSelecionados();
                AdicionarInformacoesProduto(objProduto.Produto.Identificador);
            }
        }

        private void AdicionarInformacoesProduto(string IdentificadorProdutoServico)
        {
            Comum.Clases.ProdutoCompra Produto = (from Comum.Clases.ProdutoCompra pc in _produtos
                                                  where pc.Produto.Identificador == IdentificadorProdutoServico
                                                  select pc).FirstOrDefault();

            if (Produto != null)
            {

                GuardarQuantidadeProdutoCompra frmQuantidadeProduto = new GuardarQuantidadeProdutoCompra(Produto);

                if (frmQuantidadeProduto.ShowDialog() == DialogResult.OK)
                {
                    Produto.NumeroQuantidadeCompra = frmQuantidadeProduto.ProdutoRetorno.NumeroQuantidadeCompra;
                    Produto.UnidadeMedidaCompra = frmQuantidadeProduto.ProdutoRetorno.UnidadeMedidaCompra;
                    Produto.UnidadeMedidaValorProduto = frmQuantidadeProduto.ProdutoRetorno.UnidadeMedidaValorProduto;
                    Produto.ValorCompra = frmQuantidadeProduto.ProdutoRetorno.ValorCompra;
                }

            }

            txtCodigoBarras.Text = string.Empty;
            txtCodigo.Text = string.Empty;
            cmbDescricao.SelectedText = string.Empty;
            cmbDescricao.Text = string.Empty;
            cmbDescricao.DroppedDown = false;
            SetarFocoControle(ControleCorrete);
        }
        #endregion

        #region "Eventos"
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                ListarProdutos();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {

                ProdutosServicos = null;
                dgvProdutoServico.Rows.Clear();
                cmbDescricao.SelectedText = string.Empty;
                txtCodigo.Text = string.Empty;
                txtCodigoBarras.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutoServico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProdutoServico.RowCount > 0 && ProdutosServicos != null && ProdutosServicos.Count > 0)
                {
                    if (e.ColumnIndex == colAdicionar.Index)
                    {
                        AdicionarProduto(dgvProdutoServico.Rows[e.RowIndex].Cells[colIdProdutoServico.Index].Value as string);
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutoServico_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProdutoServico.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colAdicionar.Index)
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


        private void GuardarProdutoCompra_Load(object sender, EventArgs e)
        {
            try
            {
                base.Inicializar();
                PreencherGridProdutosSelecionados();
                RecuperarProdutosServicos(true, false);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutosSelecionados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvProdutosSelecionados.RowCount > 0 && _produtos != null && _produtos.Count > 0)
                {
                    if (e.ColumnIndex == colRemover.Index)
                    {

                        _produtos.RemoveAll(p => p.Produto.Identificador == dgvProdutosSelecionados.Rows[e.RowIndex].Cells[colIdProdutoServSel.Index].Value as string);

                        PreencherGridProdutosSelecionados();

                    }
                    else if (e.ColumnIndex == colInfCompraVenda.Index)
                    {
                        AdicionarInformacoesProduto(dgvProdutosSelecionados.Rows[e.RowIndex].Cells[colIdProdutoServSel.Index].Value as string);
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutosSelecionados_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProdutosSelecionados.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colRemover.Index || e.ColumnIndex == colInfCompraVenda.Index)
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutosSelecionados = _produtos;

                this.DialogResult = DialogResult.OK;

                this.Close();



            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ListarProdutos();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ListarProdutos();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void cmbDescricao_TextChanged(object sender, EventArgs e)
        {
            try
            {

                ListarProdutosCombo();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void cmbDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ListarProdutos();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCodigoBarras_Enter(object sender, EventArgs e)
        {
            try
            {
                ControleCorrete = ControleFoco.CodigoBarras;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCodigo_Enter(object sender, EventArgs e)
        {
            try
            {
                ControleCorrete = ControleFoco.CodigoProduto;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void cmbDescricao_Enter(object sender, EventArgs e)
        {
            try
            {
                ControleCorrete = ControleFoco.Descricao;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvProdutoServico_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    AdicionarProduto(dgvProdutoServico.Rows[dgvProdutoServico.CurrentRow.Index].Cells[colIdProdutoServico.Index].Value as string);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
              

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;

                this.Close();
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
    }
}
