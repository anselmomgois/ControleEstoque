using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscarFormaPagamento : TelaBase.BaseCE
    {
        public BuscarFormaPagamento()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.FormaPagamento> objFormaPagamento = null;

        #endregion

        #region "Metodos"

        protected override void Inicializar()
        {
            MontarMenu(false);
            ConfigurarVisualizacao();
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpGeral);
            tlpGeral.Dock = DockStyle.Fill;

        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F4)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F4, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORMA_PAGAMENTO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORMA_PAGAMENTO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORMA_PAGAMENTO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarFormaPagamento(Boolean ExibirMensagemNenhumRegistro, Boolean PreencherObjeto)
        {
            ContratoServico.FormaPagamento.BuscarFormaPagamento.PeticaoBuscarFormaPagamento Peticao = new ContratoServico.FormaPagamento.BuscarFormaPagamento.PeticaoBuscarFormaPagamento();

            Peticao.Descricao = txtDescricao.Text.Trim();
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.FormaPagamento.BuscarFormaPagamento.RespostaBuscarFormaPagamento, ContratoServico.FormaPagamento.BuscarFormaPagamento.PeticaoBuscarFormaPagamento>(Peticao, SDK.Operacoes.operacao.BuscarFormaPagamento,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro,
                    PreencherObjeto = PreencherObjeto
                }, null, true);
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

            if (operacao == SDK.Operacoes.operacao.BuscarFormaPagamento)
            {
                objFormaPagamento = ((ContratoServico.FormaPagamento.BuscarFormaPagamento.RespostaBuscarFormaPagamento)objSaida).FormaPagamento;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.ExcluirSetFormaPagamento)
            {
                base.objNotificacao.ExibirMensagem("Forma de pagamento deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarFormaPagamento(false, true);
            }

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvFormaPagamento.Rows.Clear();

            if (objFormaPagamento != null && objFormaPagamento.Count > 0)
            {


                foreach (Comum.Clases.FormaPagamento c in objFormaPagamento)
                {

                    dgvFormaPagamento.Rows.Add();
                    dgvFormaPagamento.Rows[dgvFormaPagamento.Rows.Count - 1].Cells[colCodigo.Index].Value = c.Codigo;
                    dgvFormaPagamento.Rows[dgvFormaPagamento.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvFormaPagamento.Rows[dgvFormaPagamento.Rows.Count - 1].Cells[colId.Index].Value = c.Identificador;

                }

                base.PreencherGrid(ExibirMensagem);

            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            GuardarFormaPagamento frmFP = new GuardarFormaPagamento(Identificador.Value);

            if (AbrirFormulario(frmFP) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarFormaPagamento(false, true);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.PeticaoExcluirSetFormaPagamento Peticao = new ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.PeticaoExcluirSetFormaPagamento();

            Peticao.IdentificadorFormaPagamento = Identificador.Value;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.RespostaExcluirSetFormaPagamento, ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.PeticaoExcluirSetFormaPagamento>(Peticao, SDK.Operacoes.operacao.ExcluirSetFormaPagamento, null, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarFormaPagamento(true, true);

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

                objFormaPagamento = null;
                dgvFormaPagamento.Rows.Clear();
                txtDescricao.Text = string.Empty;

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

                GuardarFormaPagamento frmFP = new GuardarFormaPagamento(string.Empty);

                if (AbrirFormulario(frmFP) == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarFormaPagamento(false, true);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvFormaPagamento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            {
                try
                {
                    if (dgvFormaPagamento.RowCount > 0)
                    {
                        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                        {

                            if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                            {

                                if (e.ColumnIndex == colEditar.Index)
                                {

                                    GuardarFormaPagamento frmFP = new GuardarFormaPagamento(dgvFormaPagamento.Rows[e.RowIndex].Cells[colId.Index].Value as string);

                                    if (AbrirFormulario(frmFP) == System.Windows.Forms.DialogResult.OK)
                                    {
                                        RecuperarFormaPagamento(false, true);
                                    }
                                }
                                else if (e.ColumnIndex == colExcluir.Index)
                                {

                                    ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.PeticaoExcluirSetFormaPagamento Peticao = new ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.PeticaoExcluirSetFormaPagamento();

                                    Peticao.IdentificadorFormaPagamento = dgvFormaPagamento.Rows[e.RowIndex].Cells[colId.Index].Value as string;
                                    Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                                    Agente.Agente.InvocarServico<ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.RespostaExcluirSetFormaPagamento, ContratoServico.FormaPagamento.ExcluirSetFormaPagamento.PeticaoExcluirSetFormaPagamento>(Peticao, SDK.Operacoes.operacao.ExcluirSetFormaPagamento, null, null, true);

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
        }

        private void dgvFormaPagamento_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvFormaPagamento.RowCount > 0)
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
