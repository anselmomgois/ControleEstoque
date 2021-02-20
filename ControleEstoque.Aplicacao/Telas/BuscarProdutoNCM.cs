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
    public partial class BuscarProdutoNCM : TelaBase.BaseCE
    {
        public BuscarProdutoNCM()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.ProdutoNCM> NCMs = null;

        #endregion

        #region"Metodos"

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_NCM, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_NCM, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PRODUTO_NCM, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarNCMs()
        {
            NCMs = LogicaNegocio.ProdutoNCM.PesquisarProdutoNCM(txtNome.Text.Trim(), ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvNCM.Rows.Clear();

            if (NCMs != null && NCMs.Count > 0)
            {


                foreach (Comum.Clases.ProdutoNCM c in NCMs)
                {

                    dgvNCM.Rows.Add();
                    dgvNCM.Rows[dgvNCM.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvNCM.Rows[dgvNCM.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;

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
            GuardarProdutoNCM frmCores = new GuardarProdutoNCM(Identificador.Value);

            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarNCMs();
                ExecutarPreencherGrid(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            LogicaNegocio.ProdutoNCM.DeletarProdutoNCM(Identificador.Value, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            base.objNotificacao.ExibirMensagem("Código NCM deletado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
            RecuperarNCMs();
            ExecutarPreencherGrid(false);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarNCMs();
                ExecutarPreencherGrid(true);

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

                NCMs = null;
                dgvNCM.Rows.Clear();
                txtNome.Text = string.Empty;

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
                GuardarProdutoNCM frmCor = new GuardarProdutoNCM(string.Empty);

                if (frmCor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarNCMs();
                    ExecutarPreencherGrid(false);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvNCM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvNCM.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarProdutoNCM frmCores = new GuardarProdutoNCM(dgvNCM.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarNCMs();
                                    ExecutarPreencherGrid(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                LogicaNegocio.ProdutoNCM.DeletarProdutoNCM(dgvNCM.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
                                base.objNotificacao.ExibirMensagem("Código NCM deletado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                                RecuperarNCMs();
                                ExecutarPreencherGrid(false);
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

        private void dgvNCM_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvNCM.RowCount > 0)
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
