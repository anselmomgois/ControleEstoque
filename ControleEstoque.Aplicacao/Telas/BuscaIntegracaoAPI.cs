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
    public partial class BuscaIntegracaoAPI : TelaBase.BaseCE
    {
        public BuscaIntegracaoAPI()
        {
            InitializeComponent();
        }

        #region"Variaveis'

        private List<Comum.Clases.IntegracaoAPI> IntegracoesAPI = null;


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
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscaIntegracoesAPI)
            {
                IntegracoesAPI = ((ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.RespostaBuscaIntegracoesAPI)objSaida).IntegracoesAPI;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.DeletarIntegracaoAPI)
            {

                base.objNotificacao.ExibirMensagem("Integração deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarIntegracoes(false);
            }


        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_INTEGRACAOAPI, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_INTEGRACAOAPI, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_INTEGRACAOAPI, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarIntegracoes(Boolean ExibirMensagemNenhumRegistro)
        {
            ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.PeticaoBuscaIntegracoesAPI Peticao = new ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.PeticaoBuscaIntegracoesAPI()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.RespostaBuscaIntegracoesAPI, ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI.PeticaoBuscaIntegracoesAPI>(Peticao,
                  SDK.Operacoes.operacao.BuscaIntegracoesAPI, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);

        }
        protected override void PreencherGrid(Boolean ExibirMensagem)
        {

            dgvCores.Rows.Clear();

            if (IntegracoesAPI != null && IntegracoesAPI.Count > 0)
            {

                string[] objStrCor = null;

                foreach (Comum.Clases.IntegracaoAPI c in IntegracoesAPI)
                {

                    dgvCores.Rows.Add();
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Url;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colTipoIntegração.Index].Value = c.TipoIntegracao.RecuperarValor();
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
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
            RecuperarIntegracoes(false);
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            ModificarIntegracao(Identificador.Value);

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        private void ModificarIntegracao(string Identificador)
        {
            GuardarIntegracaoAPI frmCores = new GuardarIntegracaoAPI(Identificador);

            if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarIntegracoes(false);
            }
        }

        private void DeletarIntegracao(string Identificador)
        {
            if (MessageBox.Show("Deseja excluir o Registro?", "I - GERENCE", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.PeticaoDeletarIntegracaoAPI Peticao = new ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.PeticaoDeletarIntegracaoAPI()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    Identificador = Identificador
                };

                Agente.Agente.InvocarServico<ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.RespostaDeletarIntegracaoAPI, ContratoServico.IntegracaoAPI.DeletarIntegracaoAPI.PeticaoDeletarIntegracaoAPI>(Peticao,
                      SDK.Operacoes.operacao.DeletarIntegracaoAPI, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
            }
            }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            DeletarIntegracao(Identificador.Value);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"                

        private void btnInserir_Click(object sender, EventArgs e)
        {

            GuardarIntegracaoAPI frmCor = new GuardarIntegracaoAPI(string.Empty);

            if (AbrirFormulario(frmCor) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarIntegracoes(false);
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

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {
                                ModificarIntegracao(dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                DeletarIntegracao(dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);                               

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
