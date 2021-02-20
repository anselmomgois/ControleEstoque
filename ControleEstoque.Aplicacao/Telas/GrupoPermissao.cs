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
    public partial class GrupoPermissao : TelaBase.BaseCE
    {
        public GrupoPermissao()
        {
            InitializeComponent();

        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.GrupoPermissao> objGruposPermissoes = null;

        #endregion

        #region"Metodos"

        private void RecuperarGrupos()
        {

            ContratoServico.GrupoPermissao.RecuperarGrupos.PeticaoRecuperarGrupos Peticao = new ContratoServico.GrupoPermissao.RecuperarGrupos.PeticaoRecuperarGrupos()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                Nome = txtDescricao.Text.Trim()
            };

            Agente.Agente.InvocarServico<ContratoServico.GrupoPermissao.RecuperarGrupos.RespostaRecuperarGrupos, ContratoServico.GrupoPermissao.RecuperarGrupos.PeticaoRecuperarGrupos>(Peticao,
                  SDK.Operacoes.operacao.RecuperarGrupos, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        private void PreencherGrid()
        {
            dgvGrupo.Rows.Clear();

            if (objGruposPermissoes != null && objGruposPermissoes.Count > 0)
            {

                foreach (Comum.Clases.GrupoPermissao objGrupo in objGruposPermissoes)
                {

                    dgvGrupo.Rows.Add();
                    dgvGrupo.Rows[dgvGrupo.Rows.Count - 1].Cells[colIdGrupo.Index].Value = objGrupo.Identificador;
                    dgvGrupo.Rows[dgvGrupo.Rows.Count - 1].Cells[colDescricao.Index].Value = objGrupo.Nome;

                }
            }
        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPOPERMISSAO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPOPERMISSAO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPOPERMISSAO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
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

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarGrupos)
            {
                objGruposPermissoes = ((ContratoServico.GrupoPermissao.RecuperarGrupos.RespostaRecuperarGrupos)objSaida).GruposPermissoes;

                PreencherGrid();

            }
            else if (operacao == SDK.Operacoes.operacao.DeletarGrupoPermissao)
            {

                base.objNotificacao.ExibirMensagem("Registro deletado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarGrupos();
            }


        }

        #endregion

        #region "Eventos"

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {

                Permissoes frmPermissoes = new Permissoes(true, string.Empty, string.Empty);

                if (frmPermissoes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarGrupos();
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

                RecuperarGrupos();

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
                txtDescricao.Text = string.Empty;
                dgvGrupo.Rows.Clear();
                objGruposPermissoes = null;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion

        private void dgvGrupo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGrupo.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                Permissoes frmPermissoes = new Permissoes(true, dgvGrupo.Rows[e.RowIndex].Cells[colIdGrupo.Index].Value as string, string.Empty);

                                if (frmPermissoes.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarGrupos();
                                }


                            }
                            else
                            {


                                ContratoServico.GrupoPermissao.DeletarGrupoPermissao.PeticaoDeletarGrupoPermissao Peticao = new ContratoServico.GrupoPermissao.DeletarGrupoPermissao.PeticaoDeletarGrupoPermissao()
                                {
                                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                                    Identificador = dgvGrupo.Rows[e.RowIndex].Cells[colIdGrupo.Index].Value as string
                                };

                                Agente.Agente.InvocarServico<ContratoServico.GrupoPermissao.DeletarGrupoPermissao.RespostaDeletarGrupoPermissao, ContratoServico.GrupoPermissao.DeletarGrupoPermissao.PeticaoDeletarGrupoPermissao>(Peticao,
                                      SDK.Operacoes.operacao.DeletarGrupoPermissao, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);                               

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

        private void dgvGrupo_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvGrupo.RowCount > 0)
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

    }
}
