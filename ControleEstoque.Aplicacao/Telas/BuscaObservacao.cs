using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Aplicacao.Classes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscaObservacao : TelaBase.BaseCE
    {
        public BuscaObservacao()
        {
            InitializeComponent();

        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.ProdutoObservacao> objObservacoes = null;
        #endregion

        #region"Metodos"

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_OBSERVACAO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_OBSERVACAO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_OBSERVACAO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarObservacoes(Boolean ExibirMensagemNenhumRegistro, Boolean PreencherObjeto)
        {
            ContratoServico.Observacao.BuscarObservacao.PeticaoBuscarObservacao Peticao = new ContratoServico.Observacao.BuscarObservacao.PeticaoBuscarObservacao();

            Peticao.Descricao = txtNome.Text.Trim();
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Observacao.BuscarObservacao.RespostaBuscarObservacao, ContratoServico.Observacao.BuscarObservacao.PeticaoBuscarObservacao>(Peticao, SDK.Operacoes.operacao.BuscarObservacao,
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

            if (operacao == SDK.Operacoes.operacao.BuscarObservacao)
            {
                objObservacoes = ((ContratoServico.Observacao.BuscarObservacao.RespostaBuscarObservacao)objSaida).Observacoes;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.DeletarObservacao)
            {
                base.objNotificacao.ExibirMensagem("Observação deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarObservacoes(false, true);
            }

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvMarcas.Rows.Clear();

            if (objObservacoes != null && objObservacoes.Count > 0)
            {


                foreach (Comum.Clases.ProdutoObservacao c in objObservacoes)
                {

                    dgvMarcas.Rows.Add();
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
            ConfigurarVisualizacao();
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpClientes);
            tlpClientes.Dock = DockStyle.Fill;
        }

        
        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            GuardarTipoCrm frmCores = new GuardarTipoCrm(Identificador.Value);

            if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarObservacoes(false, true);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            ContratoServico.Observacao.DeletarObservacao.PeticaoDeletarObservacao Peticao = new ContratoServico.Observacao.DeletarObservacao.PeticaoDeletarObservacao();

            Peticao.Identificador = Identificador.Value;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Observacao.DeletarObservacao.RespostaDeletarObservacao, ContratoServico.Observacao.DeletarObservacao.PeticaoDeletarObservacao>(Peticao, SDK.Operacoes.operacao.DeletarObservacao, null, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarObservacoes(true, true);

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

                objObservacoes = null;
                dgvMarcas.Rows.Clear();
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

                GuardarObservacao frmCor = new GuardarObservacao(string.Empty);
                
                if (AbrirFormulario(frmCor) == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarObservacoes(false, true);
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

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarObservacao frmCores = new GuardarObservacao(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarObservacoes(false, true);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                ContratoServico.Observacao.DeletarObservacao.PeticaoDeletarObservacao Peticao = new ContratoServico.Observacao.DeletarObservacao.PeticaoDeletarObservacao();

                                Peticao.Identificador = dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string;
                                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

                                Agente.Agente.InvocarServico<ContratoServico.Observacao.DeletarObservacao.RespostaDeletarObservacao, ContratoServico.Observacao.DeletarObservacao.PeticaoDeletarObservacao>(Peticao, 
                                    SDK.Operacoes.operacao.DeletarObservacao, null, null, true);

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
