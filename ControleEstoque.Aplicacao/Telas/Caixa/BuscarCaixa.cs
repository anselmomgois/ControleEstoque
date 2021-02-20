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
    public partial class BuscarCaixa : TelaBase.BaseCE
    {
        public BuscarCaixa()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.Caixa> objCaixas = null;

        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F4)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F4, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CAIXA, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                //btnInserir.Visible = false;

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CAIXA, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CAIXA, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarCaixa(Boolean ExibirMensagemNenhumRegistro, Boolean PreencherObjeto)
        {
            ContratoServico.Caixa.BuscarCaixa.PeticaoBuscarCaixa Peticao = new ContratoServico.Caixa.BuscarCaixa.PeticaoBuscarCaixa();

            Peticao.Codigo = !string.IsNullOrEmpty(txtCodigo.Text) ? int.Parse(txtCodigo.Text) : 0;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Caixa.BuscarCaixa.RespostaBuscarCaixa, ContratoServico.Caixa.BuscarCaixa.PeticaoBuscarCaixa>(Peticao, SDK.Operacoes.operacao.BuscarCaixa,
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

            if (operacao == SDK.Operacoes.operacao.BuscarCaixa)
            {
                objCaixas = ((ContratoServico.Caixa.BuscarCaixa.RespostaBuscarCaixa)objSaida).Caixas;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.ExcluirSetCaixa)
            {
                base.objNotificacao.ExibirMensagem("Caixa deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarCaixa(false, true);
            }

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {

            dgvCaixa.Rows.Clear();

            if (objCaixas != null && objCaixas.Count > 0)
            {


                foreach (Comum.Clases.Caixa c in objCaixas)
                {

                    dgvCaixa.Rows.Add();
                    dgvCaixa.Rows[dgvCaixa.Rows.Count - 1].Cells[colCodigo.Index].Value = c.Codigo;
                    dgvCaixa.Rows[dgvCaixa.Rows.Count - 1].Cells[colId.Index].Value = c.Identificador;
                    dgvCaixa.Rows[dgvCaixa.Rows.Count - 1].Cells[colEstaAberto.Index].Value = c.EstaAberto;
                    dgvCaixa.Rows[dgvCaixa.Rows.Count - 1].Cells[colHostName.Index].Value = c.HostName;

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
            GuardarCaixa frmCX = new GuardarCaixa(Identificador.Value);

            if (AbrirFormulario(frmCX) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarCaixa(false, true);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ContratoServico.Caixa.ExcluirSetCaixa.PeticaoExcluirSetCaixa Peticao = new ContratoServico.Caixa.ExcluirSetCaixa.PeticaoExcluirSetCaixa();

            Peticao.IdentificadorCaixa = Identificador.Value;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Caixa.ExcluirSetCaixa.RespostaExcluirSetCaixa, ContratoServico.Caixa.ExcluirSetCaixa.PeticaoExcluirSetCaixa>(Peticao, SDK.Operacoes.operacao.ExcluirSetCaixa, null, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarCaixa(true, true);

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

                objCaixas = null;
                dgvCaixa.Rows.Clear();
                txtCodigo.Text = string.Empty;

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

                GuardarCaixa frmCX = new GuardarCaixa(string.Empty);

                if (AbrirFormulario(frmCX) == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarCaixa(false, true);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvCaixa_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvCaixa.RowCount > 0)
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

        private void BuscarFormaPagamento_Load(object sender, EventArgs e)
        {
            try
            {

                MontarMenu(false);
                ConfigurarVisualizacao();
                base.Inicializar();
                this.pnlBase.Controls.Add(tlpGeral);
                tlpGeral.Dock = DockStyle.Fill;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvCaixa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCaixa.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarCaixa frmCX = new GuardarCaixa(dgvCaixa.Rows[e.RowIndex].Cells[colId.Index].Value as string);

                                if (AbrirFormulario(frmCX) == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarCaixa(false, true);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                ContratoServico.Caixa.ExcluirSetCaixa.PeticaoExcluirSetCaixa Peticao = new ContratoServico.Caixa.ExcluirSetCaixa.PeticaoExcluirSetCaixa();

                                Peticao.IdentificadorCaixa = dgvCaixa.Rows[e.RowIndex].Cells[colId.Index].Value as string;
                                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                                Agente.Agente.InvocarServico<ContratoServico.Caixa.ExcluirSetCaixa.RespostaExcluirSetCaixa, ContratoServico.Caixa.ExcluirSetCaixa.PeticaoExcluirSetCaixa>(Peticao, SDK.Operacoes.operacao.ExcluirSetCaixa, null, null, true);

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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        #endregion

    }
}
