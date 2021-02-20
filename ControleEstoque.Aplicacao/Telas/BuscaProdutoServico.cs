using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscaProdutoServico : TelaBase.BaseCE
    {
        public BuscaProdutoServico()
        {
            InitializeComponent();
        }

        #region"Variaveis"

        private List<Comum.Clases.ProdutoServico> ProdutosServicos = null;

        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region "Metodos"

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

        private void ConfigurarVisualizacao()
        {

            Boolean ExibirInformacoesFilial = false;

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_SERVICO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
            }
            else
            {
                ExibirInformacoesFilial = true;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_SERVICO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_SERVICO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }
            else
            {
                ExibirInformacoesFilial = true;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_SERVICO, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
            {
                colConsultar.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GUARDARESTOQUEATUAL, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR) &&
                !Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GUARDARESTOQUEATUAL, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colDefinirEstoqueAtual.Visible = false;
            }

            if (!ExibirInformacoesFilial)
            {
                colInformacoesFilial.Visible = false;
            }
            
        }

        private void RecuperarProdutosServicos(Boolean ExibirMensagemNenhumRegistro)
        {
            Nullable<Int32> Codigo = null;

            if (!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
            {
                Codigo = Convert.ToInt32(txtCodigo.Text.Trim());
            }
           
            ContratoServico.ProdutoServico.RecuperarProdutosServicos.PeticaoRecuperarProdutosServicos Peticao = new ContratoServico.ProdutoServico.RecuperarProdutosServicos.PeticaoRecuperarProdutosServicos()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                Codigo = Codigo,
                CodigoBarras = txtCodigoBarras.Text.Trim(),
                CodigoTipoProduto = string.Empty,
                Descricao = txtDescricao.Text.Trim(),
                RecuperarImagensProduto = true
            };

            Agente.Agente.InvocarServico<ContratoServico.ProdutoServico.RecuperarProdutosServicos.RespostaRecuperarProdutosServicos, ContratoServico.ProdutoServico.RecuperarProdutosServicos.PeticaoRecuperarProdutosServicos>(Peticao,
                  SDK.Operacoes.operacao.RecuperarProdutosServicos, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);

        }
        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarProdutosServicos)
            {
                ProdutosServicos = ((ContratoServico.ProdutoServico.RecuperarProdutosServicos.RespostaRecuperarProdutosServicos)objSaida).ProdutosServicos;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.DeletarProdutoServico)
            {

                base.objNotificacao.ExibirMensagem("Produto deletado com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarProdutosServicos(false);
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
                    dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                    dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colCodigo.Index].Value = c.Codigo;
                    dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colCodigoBarras.Index].Value = (c.CodigosBarras != null && c.CodigosBarras.Count > 0 ? string.Join(Environment.NewLine,c.CodigosBarras.Select(cb => cb.CodigoBarras)) : string.Empty);

                    if(c.CodigosBarras != null && c.CodigosBarras.Count > 1)
                    {
                        dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Height = 20 * c.CodigosBarras.Count;
                    }
                    if (c.ImgProduto != null)
                    {

                        MemoryStream imgBits = new MemoryStream(c.ImgProduto);
                        Bitmap img = new Bitmap(imgBits);
                        Image objFoto = img;
                        dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colImgProduto.Index].Value = objFoto;
                        dgvProdutoServico.Rows[dgvProdutoServico.Rows.Count - 1].Cells[colAtalhoImagem.Index].ToolTipText = "Clique na imagem para aumentar o zoom.";
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
            GuardarProdutoServico frmProdutoServico = new GuardarProdutoServico(Identificador.Value,false);

            if (frmProdutoServico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarProdutosServicos(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ContratoServico.ProdutoServico.DeletarProdutoServico.PeticaoDeletarProdutoServico peticao = new ContratoServico.ProdutoServico.DeletarProdutoServico.PeticaoDeletarProdutoServico()
            {
                Identificador = Identificador.Value,
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
            };

            Agente.Agente.InvocarServico<ContratoServico.ProdutoServico.DeletarProdutoServico.RespostaDeletarProdutoServico, ContratoServico.ProdutoServico.DeletarProdutoServico.PeticaoDeletarProdutoServico>(peticao,
                  SDK.Operacoes.operacao.DeletarProdutoServico, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region "Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarProdutosServicos(true);
                

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
                txtDescricao.Text = string.Empty;
                txtCodigo.Text = string.Empty;
                txtCodigoBarras.Text = string.Empty;

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
                GuardarProdutoServico frmProdutoServico = new GuardarProdutoServico(string.Empty, false);

                if (frmProdutoServico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarProdutosServicos(false);
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
                if (dgvProdutoServico.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colConsultar.Index
                            || e.ColumnIndex == colAtalhoImagem.Index || e.ColumnIndex == colInformacoesFilial.Index || e.ColumnIndex == colDefinirEstoqueAtual.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colConsultar.Index)
                            {

                                GuardarProdutoServico frmProdutoServico = new GuardarProdutoServico(dgvProdutoServico.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string,
                                                                                                    (e.ColumnIndex == colConsultar.Index));

                                if (frmProdutoServico.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarProdutosServicos(false);
                                }
                            }
                            else if (e.ColumnIndex == colAtalhoImagem.Index && dgvProdutoServico.Rows[e.RowIndex].Cells[colImgProduto.Index].Value != null)
                            {

                                ExibirFoto frmFoto = new ExibirFoto((Image)(dgvProdutoServico.Rows[e.RowIndex].Cells[colImgProduto.Index].Value));
                                frmFoto.ShowDialog();

                            }
                            else if (e.ColumnIndex == colInformacoesFilial.Index)
                            {

                                GuardarProdutoFilial frmProdutoFilial = new GuardarProdutoFilial(ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.First().Identificador,
                                                                                                 dgvProdutoServico.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                 frmProdutoFilial.ShowDialog();

                            }
                            else if (e.ColumnIndex == colDefinirEstoqueAtual.Index)
                            {

                                GuardarProdutoCompraEstoqueAtual frmEstoqueAtual = new GuardarProdutoCompraEstoqueAtual(dgvProdutoServico.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                frmEstoqueAtual.ShowDialog();

                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                ContratoServico.ProdutoServico.DeletarProdutoServico.PeticaoDeletarProdutoServico peticao = new ContratoServico.ProdutoServico.DeletarProdutoServico.PeticaoDeletarProdutoServico()
                                {
                                    Identificador = dgvProdutoServico.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string,
                                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
                                };

                                Agente.Agente.InvocarServico<ContratoServico.ProdutoServico.DeletarProdutoServico.RespostaDeletarProdutoServico, ContratoServico.ProdutoServico.DeletarProdutoServico.PeticaoDeletarProdutoServico>(peticao,
                                      SDK.Operacoes.operacao.DeletarProdutoServico, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
                                                               
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

        private void dgvMarcas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvProdutoServico.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || (e.ColumnIndex == colAtalhoImagem.Index && dgvProdutoServico.Rows[e.RowIndex].Cells[colImgProduto.Index].Value != null)
                            || e.ColumnIndex == colConsultar.Index || e.ColumnIndex == colInformacoesFilial.Index || e.ColumnIndex == colDefinirEstoqueAtual.Index)
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

        #endregion

    }
}
