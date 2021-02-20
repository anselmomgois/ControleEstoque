using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Server.Classes;

namespace Informatiz.ControleEstoque.Server.Telas.TelaBase
{
    public partial class BaseCE : TelaBase.Base
    {
        public BaseCE()
        {
            InitializeComponent();

            Agente = new AgenteServico();

            Agente.Agente.StatusOperacao += Agente_StatusOperacao;
            Agente.Agente.SetarCursorWait += Agente_SetarCursorWait;
            Agente.Agente.DesabilitarControles += Agente_DesabilitarControles;
            Agente.Agente.InicioOperacao += Agente_InicioOperacao;
            Agente.Agente.FimOperacao += Agente_FimOperacao;
            ModificarRegistro += Base_Modificar;
            DeletarRegistro += Base_Deletar;
            InserirRegistro += BaseCE_InserirRegistro;
        }


        #region"Propriedades"

        public List<string> ControlesDesabilitados;
        public object DadoRetornar { get; set; }
        public Controles.UcNotificacao objNotificacao { get; set; }
        public BaseCE objFormulario { get; set; }
        public Form objFormularioNormal { get; set; }
        public AgenteServico Agente { get; set; }
        public List<SDK.Operacoes.operacao> ServicosEmProcesamento { get; set; }

        #endregion

        #region"Metodos"



        protected virtual void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {

        }
        protected virtual void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

        }

        protected virtual void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

        }

        protected virtual void Inserir(string NomeGrid)
        {

        }

        protected virtual void FimProcesamento()
        {

        }

        protected virtual void SetarCursor(Cursor objCursor)
        {

        }

        protected virtual void DesabilitarControles(List<string> NomeControles, bool Habilitado)
        {

        }

        private void SelecionarItemGrid(Control controle)
        {
            if (controle is DataGridView && LinhaSelecionadaGrid != null && LinhaSelecionadaGrid.Count > 0 && LinhaSelecionadaGrid.ContainsKey(controle.Name))
            {
                DataGridView objGrid = (DataGridView)(controle);
                KeyValuePair<string, string> objdic;
                LinhaSelecionadaGrid.TryGetValue(objGrid.Name, out objdic);

                if (!string.IsNullOrEmpty(objdic.Key))
                {

                    DataGridViewRow rowGrid = (from DataGridViewRow row in objGrid.Rows where row.Cells[objdic.Key].Value as string == objdic.Value select row).FirstOrDefault();
                    if (rowGrid != null)
                    {
                        rowGrid.Selected = true;
                    }

                }
            }

            if (controle.Controls != null && controle.Controls.Count > 0)
            {
                foreach (Control controleFilho in controle.Controls)
                {
                    SelecionarItemGrid(controleFilho);
                }
            }
        }

        public DialogResult AbrirFormulario(BaseCE objFormularioRecebido)
        {

            objFormulario = objFormularioRecebido;

            Formularios.AdicionarFormulario(objFormulario);
            DialogResult objResultado = objFormulario.ShowDialog();

            Formularios.RemoverFormulario(objFormulario);
            objFormulario = null;

            return objResultado;

        }

        public void DesabilitarSelecaoGrid()
        {
            if (LinhaSelecionadaGrid != null && LinhaSelecionadaGrid.Count > 0)
            {
                DesabilitarSelecaoLinha = true;
            }
        }

        protected virtual void PreencherGrid(Boolean ExibirMensagem)
        {

            SelecionarItemGrid(this);
        }

        public void ExecutarPreencherGrid(Boolean ExibirMensagem)
        {
            DesabilitarSelecaoGrid();
            PreencherGrid(ExibirMensagem);
            HabilitarSelecaoGrid();
        }

        protected virtual void PreencherGrid(Boolean ExibirMensagem, string NomeGrid)
        {

            SelecionarItemGrid(this);
        }

        public void ExecutarPreencherGrid(Boolean ExibirMensagem, string NomeGrid)
        {
            DesabilitarSelecaoGrid();
            PreencherGrid(ExibirMensagem, NomeGrid);
            HabilitarSelecaoGrid();
        }

        public void HabilitarSelecaoGrid()
        {
            DesabilitarSelecaoLinha = false;
        }

        protected virtual void Inicializar()
        {
            try
            {

                base.Inicializar();
                objNotificacao = new Controles.UcNotificacao();
                this.AcionarTeclaAtalho(this);
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }

        }
        #endregion

        #region "Eventos"


        private void Base_Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        private void Base_Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        private void BaseCE_InserirRegistro(string NomeGrid)
        {
            Inserir(NomeGrid);
        }

        private void Agente_DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            try
            {
                if (ServicosEmProcesamento != null && ServicosEmProcesamento.Count > 1 && !Habilitado) { return; }
                DesabilitarControles(NomeControles, Habilitado);
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void Agente_SetarCursorWait(object sender, EventArgs e)
        {
            try
            {
                SetarCursor(Cursors.WaitCursor);
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void Agente_StatusOperacao(Exception ex, object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                SetarCursor(Cursors.Default);

                if (objSaida != null)
                {


                    ContratoServico.RespostaGenerica objSaidaConvertido = (ContratoServico.RespostaGenerica)objSaida;

                    if (objSaidaConvertido.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO))
                    {
                        if (objSaidaConvertido.CodigoErro == Convert.ToInt32(Execao.Constantes.CodigoErro.ERRO_TRATADO_TELA))
                        {
                            RespostaAgente(objSaida, operacao, Parametros);
                        }
                        else
                        {
                            throw new Exception(objSaidaConvertido.DescricaoErro);
                        }
                    }
                    else
                    {
                        RespostaAgente(objSaida, operacao, Parametros);
                    }

                }
                else
                {
                    Server.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                }

            }
            catch (Execao.ExecaoNegocio ex1)
            {
                Util.ExibirMensagemErro(ex1.Descricao);
            }
            catch (Exception ex1)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex1.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void Agente_FimOperacao(SDK.Operacoes.operacao operacao, List<string> NomeControles, Boolean ExecutarFimProcessamento, Boolean NaoDesabilitarControles)
        {
            try
            {
                if (ServicosEmProcesamento != null)
                {
                    ServicosEmProcesamento.Remove(operacao);

                    if (ServicosEmProcesamento.Count == 0)
                    {
                        if (!NaoDesabilitarControles) DesabilitarControles(NomeControles, true);
                        if (ExecutarFimProcessamento) { FimProcesamento(); }
                    }
                }
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void Agente_InicioOperacao(SDK.Operacoes.operacao operacao)
        {
            try
            {
                if (ServicosEmProcesamento == null) { ServicosEmProcesamento = new List<SDK.Operacoes.operacao>(); }
                ServicosEmProcesamento.Add(operacao);
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion

        private void BaseCE_Load(object sender, EventArgs e)
        {
            try
            {
                Inicializar();
            }
            catch (Exception ex)
            {
                Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
