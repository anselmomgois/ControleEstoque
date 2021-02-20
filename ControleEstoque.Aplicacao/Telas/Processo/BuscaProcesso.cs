using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscaProcesso : TelaBase.BaseCE
    {
        public BuscaProcesso()
        {
            InitializeComponent();
        }

        #region"Variaveis'

        private List<Comum.Clases.Processo> _Processos = null;


        #endregion

        #region"Constantes"
        private const string btnInserir = "btnInserir";
        #endregion

        #region "Metodos"


        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado, operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarProcessos)
            {
                _Processos = ((ContratoServico.Processo.RecuperarProcessos.RespostaRecuperarProcessos)objSaida).Processos;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.SetProcesso)
            {

                base.objNotificacao.ExibirMensagem("Integração desativada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarProcessos(false);
            }


        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROCESSO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROCESSO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROCESSO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarProcessos(Boolean ExibirMensagemNenhumRegistro)
        {
            ContratoServico.Processo.RecuperarProcessos.PeticaoRecuperarProcessos Peticao = new ContratoServico.Processo.RecuperarProcessos.PeticaoRecuperarProcessos()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Processo.RecuperarProcessos.RespostaRecuperarProcessos, ContratoServico.Processo.RecuperarProcessos.PeticaoRecuperarProcessos>(Peticao,
                  SDK.Operacoes.operacao.RecuperarProcessos, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);

        }
        protected override void PreencherGrid(Boolean ExibirMensagem)
        {

            dgvCores.Rows.Clear();

            if (_Processos != null && _Processos.Count > 0)
            {

                string[] objStrCor = null;
                string strTipoProcesso = string.Empty;

                foreach (Comum.Clases.Processo c in _Processos)
                {

                    strTipoProcesso = string.Empty;

                    switch (c.Tipo)
                    {
                        case Comum.Enumeradores.TipoProcesso.API:
                            strTipoProcesso = "Integração API";
                            break;

                        case Comum.Enumeradores.TipoProcesso.EMAILFECHAMENTOCAIXA:

                            strTipoProcesso = "Email Fechamento Caixa";
                            break;                        
                    }

                    dgvCores.Rows.Add();
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colTipoProcesso.Index].Value = strTipoProcesso;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colIntervalo.Index].Value = c.IntervaloExecucao;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colExcluir.Index].Value = (c.Ativo ? Properties.Resources.x : Properties.Resources.x_gray);
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

            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            ConfigurarVisualizacao();
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpClientes);
            tlpClientes.Dock = DockStyle.Fill;
            RecuperarProcessos(false);
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            ModificarIntegracao(Identificador.Value);

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        private void ModificarIntegracao(string Identificador)
        {
            GuardarProcesso frmCores = new GuardarProcesso(Identificador);

            if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarProcessos(false);
            }
        }

        private void DeletarProcesso(string Identificador)
        {
            if (MessageBox.Show("Deseja desativar o processo?", "I - GERENCE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Comum.Clases.Processo objProcesso = _Processos.Find(p => p.Identificador == Identificador);

                if (objProcesso != null)
                {
                    objProcesso.Ativo = false;

                    ContratoServico.Processo.SetProcesso.PeticaoSetProcesso Peticao = new ContratoServico.Processo.SetProcesso.PeticaoSetProcesso()
                    {
                        Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                        IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                        Processo = objProcesso
                    };

                    Agente.Agente.InvocarServico<ContratoServico.Processo.SetProcesso.RespostaSetProcesso, ContratoServico.Processo.SetProcesso.PeticaoSetProcesso>(Peticao,
                          SDK.Operacoes.operacao.SetProcesso, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
                }
            }
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            DeletarProcesso(Identificador.Value);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"                

        private void btnInserir_Click(object sender, EventArgs e)
        {

            GuardarProcesso frmCor = new GuardarProcesso(string.Empty);

            if (AbrirFormulario(frmCor) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarProcessos(false);
            }
        }

        private void dgvCores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCores.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {
                        if (e.ColumnIndex == colEditar.Index || (e.ColumnIndex == colExcluir.Index && _Processos != null && _Processos.Find(p => p.Identificador == dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string).Ativo))
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {
                                ModificarIntegracao(dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                DeletarProcesso(dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

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

        private void dgvCores_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvCores.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || (e.ColumnIndex == colExcluir.Index && _Processos != null && _Processos.Find(p => p.Identificador == dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string).Ativo))
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
