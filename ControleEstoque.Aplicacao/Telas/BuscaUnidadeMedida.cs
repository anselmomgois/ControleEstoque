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
    public partial class BuscaUnidadeMedida : TelaBase.BaseCE
    {
        public BuscaUnidadeMedida()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis'

        private List<Comum.Clases.UnidadeMedida> UnidadesMedida = null;

        #endregion

        #region"Metodos"

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

            if (operacao == SDK.Operacoes.operacao.RecuperarUnidadesMedida)
            {

                UnidadesMedida = ((ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida)objSaida).UnidadesMedida;
                ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);

            }
            else if (operacao == SDK.Operacoes.operacao.DeletarUnidadeMedida)
            {
                base.objNotificacao.ExibirMensagem("Unidade de medida deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarUnidadesMedida(false);
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

        private void RecuperarUnidadesMedida(Boolean ExibirMensagemNenhumRegistro)
        {

            ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida Peticao = new ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida();

            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.RecuperarUnidadesFilhas = true;
            Peticao.Descricao = txtNome.Text.Trim();

            Agente.Agente.InvocarServico<ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.RespostaRecuperarUnidadesMedida, ContratoServico.UnidadeMedida.RecuperarUnidadesMedida.PeticaoRecuperarUnidadesMedida>(Peticao,
                    SDK.Operacoes.operacao.RecuperarUnidadesMedida,
                    new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvUnidadesMedida.Rows.Clear();

            if (UnidadesMedida != null && UnidadesMedida.Count > 0)
            {

                foreach (Comum.Clases.UnidadeMedida un in UnidadesMedida)
                {

                    dgvUnidadesMedida.Rows.Add();
                    dgvUnidadesMedida.Rows[dgvUnidadesMedida.Rows.Count - 1].Cells[colDescricao.Index].Value = un.Descricao;
                    dgvUnidadesMedida.Rows[dgvUnidadesMedida.Rows.Count - 1].Cells[colIdCor.Index].Value = un.Identificador;
                    dgvUnidadesMedida.Rows[dgvUnidadesMedida.Rows.Count - 1].Cells[colCodigo.Index].Value = un.Codigo;

                    if (un.UnidademedidaPai != null)
                    {
                        dgvUnidadesMedida.Rows[dgvUnidadesMedida.Rows.Count - 1].Cells[colDescUnidadePai.Index].Value = "Um(a) " + un.Descricao + " vale " + un.NumValorUnidadePai + " " + un.UnidademedidaPai.Descricao + "(s)";
                    }
                }

                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);
            }

        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_UNIDADE_MEDIDA, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_UNIDADE_MEDIDA, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_UNIDADE_MEDIDA, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            GuardarUnidadeMedida frmUnidadeMedida = new GuardarUnidadeMedida(Identificador.Value);

            if (frmUnidadeMedida.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarUnidadesMedida(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ContratoServico.UnidadeMedida.DeletarUnidadeMedida.PeticaoDeletarUnidadeMedida Peticao = new ContratoServico.UnidadeMedida.DeletarUnidadeMedida.PeticaoDeletarUnidadeMedida();

            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorUnidadeMedida = Identificador.Value;

            Agente.Agente.InvocarServico<ContratoServico.UnidadeMedida.DeletarUnidadeMedida.RespostaDeletarUnidadeMedida, ContratoServico.UnidadeMedida.DeletarUnidadeMedida.PeticaoDeletarUnidadeMedida>(Peticao,
                    SDK.Operacoes.operacao.DeletarUnidadeMedida,
                    new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarUnidadesMedida(true);                

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

                UnidadesMedida = null;
                dgvUnidadesMedida.Rows.Clear();
                txtNome.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            GuardarUnidadeMedida frmUnidadeMedida = new GuardarUnidadeMedida(string.Empty);

            if (frmUnidadeMedida.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarUnidadesMedida(false);
            }
        }     

        private void dgvUnidadesMedida_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvUnidadesMedida.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarUnidadeMedida frmUnidadeMedida = new GuardarUnidadeMedida(dgvUnidadesMedida.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (frmUnidadeMedida.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarUnidadesMedida(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {


                                ContratoServico.UnidadeMedida.DeletarUnidadeMedida.PeticaoDeletarUnidadeMedida Peticao = new ContratoServico.UnidadeMedida.DeletarUnidadeMedida.PeticaoDeletarUnidadeMedida();

                                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
                                Peticao.IdentificadorUnidadeMedida = dgvUnidadesMedida.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string;

                                Agente.Agente.InvocarServico<ContratoServico.UnidadeMedida.DeletarUnidadeMedida.RespostaDeletarUnidadeMedida, ContratoServico.UnidadeMedida.DeletarUnidadeMedida.PeticaoDeletarUnidadeMedida>(Peticao,
                                        SDK.Operacoes.operacao.DeletarUnidadeMedida,
                                        new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
                              
                            }

                        }
                    }
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
                return;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvUnidadesMedida_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvUnidadesMedida.RowCount > 0)
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
