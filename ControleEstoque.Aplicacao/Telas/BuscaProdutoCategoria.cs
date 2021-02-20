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
    public partial class BuscaProdutoCategoria : TelaBase.BaseCE
    {
        public BuscaProdutoCategoria()
        {
            InitializeComponent();
        }

        #region"Variaveis"

        private List<Comum.Clases.ProdutoCategoria> Categorias = null;

        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Metodos"

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CATEGORIA, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CATEGORIA, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_CATEGORIA, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarCategorias(Boolean ExibirMensagemNenhumRegistro)
        {
            ContratoServico.ProdutoCategoria.RecuperarCategorias.PeticaoRecuperarCategorias Peticao = new ContratoServico.ProdutoCategoria.RecuperarCategorias.PeticaoRecuperarCategorias();

            Peticao.Descricao = txtNome.Text.Trim();
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.ProdutoCategoria.RecuperarCategorias.RespostaRecuperarCategorias, ContratoServico.ProdutoCategoria.RecuperarCategorias.PeticaoRecuperarCategorias>(Peticao,
                SDK.Operacoes.operacao.RecuperarCategorias,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro,
                    PreencherObjeto = true
                }, null, true);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvCategorias.Rows.Clear();

            if (Categorias != null && Categorias.Count > 0)
            {


                foreach (Comum.Clases.ProdutoCategoria c in Categorias)
                {

                    dgvCategorias.Rows.Add();
                    dgvCategorias.Rows[dgvCategorias.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvCategorias.Rows[dgvCategorias.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;

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
            GuardarProdutoCategoria frmCores = new GuardarProdutoCategoria(Identificador.Value);

            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarCategorias(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
             DeletarCategoria(Identificador.Value);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

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

            if (operacao == SDK.Operacoes.operacao.RecuperarCategorias)
            {

                Categorias = ((ContratoServico.ProdutoCategoria.RecuperarCategorias.RespostaRecuperarCategorias)objSaida).Categorias;
                ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);

            }
            else if (operacao == SDK.Operacoes.operacao.DeletarProdutoCategoria)
            {
                base.objNotificacao.ExibirMensagem("Categoria deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarCategorias(false);
            }

        }

        private void DeletarCategoria(string Identificador)
        {
            ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.PeticaoDeletarProdutoCategoria Peticao = new ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.PeticaoDeletarProdutoCategoria();

            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorProdutoCategoria = Identificador;

            Agente.Agente.InvocarServico<ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.RespostaDeletarProdutoCategoria, ContratoServico.ProdutoCategoria.DeletarProdutoCategoria.PeticaoDeletarProdutoCategoria>(Peticao,
                SDK.Operacoes.operacao.DeletarProdutoCategoria,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = false,
                    PreencherObjeto = true
                }, null, true);
        }
        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarCategorias(true);

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

                Categorias = null;
                dgvCategorias.Rows.Clear();
                txtNome.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            GuardarProdutoCategoria frmCor = new GuardarProdutoCategoria(string.Empty);

            if (frmCor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarCategorias(false);
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCategorias.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarProdutoCategoria frmCores = new GuardarProdutoCategoria(dgvCategorias.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarCategorias(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {


                                DeletarCategoria(dgvCategorias.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);
                                
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

        private void dgvCategorias_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (dgvCategorias.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
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
