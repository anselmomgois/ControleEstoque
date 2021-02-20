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
    public partial class BuscaPromocao : TelaBase.BaseCE
    {
        public BuscaPromocao()
        {
            InitializeComponent();
        }

        #region"Variaveis"

        private List<Comum.Clases.ProdutoPromocao> Promocoes = null;

        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region "Metodos"

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

             if (operacao == SDK.Operacoes.operacao.DesativarProdutoPromocao)
            {
                base.objNotificacao.ExibirMensagem("Promoção desativada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarPromocoes(false);
               
            }
             else if (operacao == SDK.Operacoes.operacao.PesquisarProdutoPromocao)
            {
                Promocoes = ((ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.RespostaPesquisarProdutoPromocao)objSaida).Promocoes;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }

        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_PROMOCAO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_PROMOCAO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_PROMOCAO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_PROMOCAO, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
            {
                colConsultar.Visible = false;
            }

        }

        private void RecuperarPromocoes(Boolean ExibirMensagemNenhumRegistro)
        {

            ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.PeticaoPesquisarProdutoPromocao Peticao = new ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.PeticaoPesquisarProdutoPromocao();

            Peticao.Descricao = txtNome.Text.Trim();
            Peticao.DescricaoProduto = txtDescricaoProduto.Text.Trim();
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.RespostaPesquisarProdutoPromocao, ContratoServico.ProdutoPromocao.PesquisarProdutoPromocao.PeticaoPesquisarProdutoPromocao>(Peticao,
                SDK.Operacoes.operacao.PesquisarProdutoPromocao,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro,
                    PreencherObjeto = true
                }, null, true);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvMarcas.Rows.Clear();

            if (Promocoes != null && Promocoes.Count > 0)
            {


                foreach (Comum.Clases.ProdutoPromocao c in Promocoes)
                {

                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDesconto.Index].Value = c.Valor;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colEstoque.Index].Value = c.Estoque;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colTipo.Index].Value = "PROM";
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colPercentual.Index].Value = c.PercentualDesconto;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExibirProdutos.Index].Value = Properties.Resources.sub_blue_add;

                    if (!c.Habilitada)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                    }
                    else
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x;
                    }

                    if (c.Produtos != null && c.Produtos.Count > 0)
                    {

                        foreach (Comum.Clases.ProdutoServico ps in c.Produtos)
                        {
                            dgvMarcas.Rows.Add();

                            //if (string.IsNullOrEmpty(ps.CodigoBarras))
                            //{
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = ps.Descricao;
                            //}
                            //else
                            //{
                            //    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = ps.CodigoBarras + " - " + ps.Descricao;
                            //}

                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colEstoque.Index].Value = ps.Estoque;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colTipo.Index].Value = "PROD";
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdPai.Index].Value = c.Identificador;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExibirProdutos.Index].Value = Properties.Resources.fundo_azul_claro;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.fundo_azul_claro;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colEditar.Index].Value = Properties.Resources.fundo_azul_claro;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colConsultar.Index].Value = Properties.Resources.fundo_azul_claro;
                            dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Visible = false;
                        }
                    }

                }

                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);
            }

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F4)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F4, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            ConfigurarVisualizacao();
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpClientes);
            tlpClientes.Dock = DockStyle.Fill;
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            GuardarProdutoPromocao frmCores = new GuardarProdutoPromocao(Identificador.Value,false);

            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarPromocoes(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.PeticaoDesativarProdutoPromocao Peticao = new ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.PeticaoDesativarProdutoPromocao();

            Peticao.IdentificadorProdutoPromocao = Identificador.Value;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.RespostaDesativarProdutoPromocao, ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.PeticaoDesativarProdutoPromocao>(Peticao, 
                SDK.Operacoes.operacao.DesativarProdutoPromocao,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = false,
                    PreencherObjeto = false
                }, null, true);                     

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion


        #region"Eventos"

        private void btnInserir_Click(object sender, EventArgs e)
        {

            try
            {
                GuardarProdutoPromocao frmPromocao = new GuardarProdutoPromocao(string.Empty, false);

                if (frmPromocao.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarPromocoes(false);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvMarcas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if ((e.ColumnIndex == colConsultar.Index || e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colExibirProdutos.Index) && dgvMarcas.Rows[e.RowIndex].Cells[colTipo.Index].Value == "PROM")
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

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if ((e.ColumnIndex == colConsultar.Index || e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colExibirProdutos.Index) && dgvMarcas.Rows[e.RowIndex].Cells[colTipo.Index].Value == "PROM")
                        {

                            if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colConsultar.Index)
                            {

                                GuardarProdutoPromocao frmCores = new GuardarProdutoPromocao(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, (e.ColumnIndex == colConsultar.Index));

                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarPromocoes(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.PeticaoDesativarProdutoPromocao Peticao = new ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.PeticaoDesativarProdutoPromocao();

                                Peticao.IdentificadorProdutoPromocao = dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string;
                                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                                Agente.Agente.InvocarServico<ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.RespostaDesativarProdutoPromocao, ContratoServico.ProdutoPromocao.DesativarProdutoPromocao.PeticaoDesativarProdutoPromocao>(Peticao,
                                    SDK.Operacoes.operacao.DesativarProdutoPromocao,
                                    new Comum.ParametrosTela.Generica
                                    {
                                        ExibirMensagemNenhumRegistro = false,
                                        PreencherObjeto = false
                                    }, null, true);
                            }
                            else if (e.ColumnIndex == colExibirProdutos.Index)
                            {
                                Boolean LinhasVisiveis = false;

                                foreach (DataGridViewRow dr in (from DataGridViewRow drp in dgvMarcas.Rows where drp.Cells[colIdPai.Index].Value == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value select drp))
                                {
                                    dr.Visible = !dr.Visible;
                                    LinhasVisiveis = dr.Visible;
                                }

                                if (LinhasVisiveis)
                                {
                                    dgvMarcas.Rows[e.RowIndex].Cells[colExibirProdutos.Index].Value = Properties.Resources.sub_blue_minus;
                                }
                                else
                                {
                                    dgvMarcas.Rows[e.RowIndex].Cells[colExibirProdutos.Index].Value = Properties.Resources.sub_blue_add;
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarPromocoes(true);

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

                Promocoes = null;
                dgvMarcas.Rows.Clear();
                txtNome.Text = string.Empty;
                txtDescricaoProduto.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
            

        #endregion

    }
}
