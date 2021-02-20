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
    public partial class BuscaPublicidade : TelaBase.BaseCE
    {
        public BuscaPublicidade()
        {
            InitializeComponent();
        }

        #region"Variaveis"

        private List<Comum.Clases.Publicidade> Publicidades = null;

        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Metodos"

        private void RecuperarPublicidades()
        {
            Publicidades = LogicaNegocio.Publicidade.RecuperarPublicidades(txtNome.Text.Trim(), ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvMarcas.Rows.Clear();

            if (Publicidades != null && Publicidades.Count > 0)
            {


                foreach (Comum.Clases.Publicidade c in Publicidades)
                {

                    dgvMarcas.Rows.Add();
                    if (c.Codigo == Comum.Clases.Constantes.COD_PUBLICIDADE_AMIGO ||
                        c.Codigo == Comum.Clases.Constantes.COD_PUBLICIDADE_CONSULTOR)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].ReadOnly = true;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGray;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colEditar.Index].Value = Properties.Resources.edit_gray;
                    }

                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;

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
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpClientes);
            tlpClientes.Dock = DockStyle.Fill;
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            GuardarPublicidade frmPublicidade = new GuardarPublicidade(Identificador.Value);

            if (frmPublicidade.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarPublicidades();
                ExecutarPreencherGrid(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            LogicaNegocio.Publicidade.DeletarPublicidade(Identificador.Value, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            base.objNotificacao.ExibirMensagem("Publiciade deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
            RecuperarPublicidades();
            ExecutarPreencherGrid(false);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarPublicidades();
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

                Publicidades = null;
                dgvMarcas.Rows.Clear();
                txtNome.Text = string.Empty;

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

                        if ((e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index) &&
                  (!dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value.Equals("1") &&
                    !dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value.Equals("2")))
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarPublicidade frmPublicidade = new GuardarPublicidade( dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (frmPublicidade.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarPublicidades();
                                    ExecutarPreencherGrid(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {


                                LogicaNegocio.Publicidade.DeletarPublicidade(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
                                base.objNotificacao.ExibirMensagem("Publiciade deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                                RecuperarPublicidades();
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

        private void dgvMarcas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if ((e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index) &&
                             (!dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value.Equals("1") &&
                               !dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value.Equals("2")))
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
                GuardarPublicidade frmPublicidade = new GuardarPublicidade(string.Empty);

                if (frmPublicidade.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarPublicidades();
                    ExecutarPreencherGrid(false);
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
