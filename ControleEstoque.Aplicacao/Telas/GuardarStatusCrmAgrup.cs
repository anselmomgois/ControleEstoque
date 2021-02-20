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
    public partial class GuardarStatusCrmAgrup : TelaBase.BaseCE
    {
        public GuardarStatusCrmAgrup(string IdentificadorStatusCrmAgrupador)
        {
            InitializeComponent();

            _IdentificadorStatusCrmAgrupador = IdentificadorStatusCrmAgrupador;
        }

        #region"Variaveis"

        private string _IdentificadorStatusCrmAgrupador;
        private Comum.Clases.StatusCrmAgrupador objStatusCrmAgrupador;
        private List<Comum.Clases.StatusCrm> _objStatusCrm;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        private const string btnInserir = "btnInserir";
        #endregion
        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir Status (F3)", btnInserir, Properties.Resources.add, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpPrincipal);
            CarregarTela();
            base.Inicializar();
        }

        private void CarregarTela()
        {
            RecuperarCrmAgrupador();
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscarStatusCrmDetalhe)
            {
                objStatusCrmAgrupador = ((ContratoServico.CRM.BuscarStatusCrmDetalhe.RespostaStatusCrmDetalhe)objSaida).StatusAgrupador;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    PreencherControles();
                }

            }
            else if (operacao == SDK.Operacoes.operacao.SetStatusCrm)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Dados atualizados com sucesso");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            DesabilitarControles(this, Habilitado, NomeControles);

        }

        private void DesabilitarControles(Control objcontrole, Boolean Habilitado, List<string> NomeControles)
        {
            if (NomeControles != null && NomeControles.Count > 0)
            {
                if (NomeControles.Exists(c => c == objcontrole.Name))
                {
                    objcontrole.Enabled = Habilitado;
                }
            }
            else
            {
                objcontrole.Enabled = Habilitado;
            }

            if (objcontrole.Controls != null && objcontrole.Controls.Count > 0)
            {
                foreach (Control c in objcontrole.Controls)
                {
                    DesabilitarControles(c, Habilitado, NomeControles);
                }
            }
        }

        private void RecuperarCrmAgrupador()
        {

            if (!string.IsNullOrEmpty(_IdentificadorStatusCrmAgrupador))
            {
                ContratoServico.CRM.BuscarStatusCrmDetalhe.PeticaoStatusCrmDetalhe Peticao = new ContratoServico.CRM.BuscarStatusCrmDetalhe.PeticaoStatusCrmDetalhe();
                Peticao.IdentificadorStatusCrmAgrupador = _IdentificadorStatusCrmAgrupador;
                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.CRM.BuscarStatusCrmDetalhe.RespostaStatusCrmDetalhe, ContratoServico.CRM.BuscarStatusCrmDetalhe.PeticaoStatusCrmDetalhe>(Peticao,
                    SDK.Operacoes.operacao.BuscarStatusCrmDetalhe, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }

        }

        private void PreencherControles()
        {

            if (objStatusCrmAgrupador != null)
            {

                txtDescricao.Text = objStatusCrmAgrupador.Descricao;
                _objStatusCrm = objStatusCrmAgrupador.StatusCrms;

                ExecutarPreencherGrid(false);
            }
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvMarcas.Rows.Clear();

            if (_objStatusCrm != null && _objStatusCrm.Count > 0)
            {


                foreach (Comum.Clases.StatusCrm c in _objStatusCrm.OrderBy(c=> c.Descricao))
                {

                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCorStatus.Index].Style.BackColor = Classes.Util.ConverterStringEmCor(c.CorRGB);

                }

                
                base.PreencherGrid(ExibirMensagem);
            }

        }

        private void ExecutarGravar()
        {

            ContratoServico.CRM.StatusCrm.PeticaoStatusCrm Peticao = new ContratoServico.CRM.StatusCrm.PeticaoStatusCrm();

            Peticao.Status = new Comum.Clases.StatusCrmAgrupador();

            Peticao.Status.Descricao = txtDescricao.Text.Trim();
            Peticao.Status.Identificador = _IdentificadorStatusCrmAgrupador;
            Peticao.Status.StatusCrms = _objStatusCrm;
            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;

            Agente.Agente.InvocarServico<ContratoServico.CRM.StatusCrm.RespostaStatusCrm, ContratoServico.CRM.StatusCrm.PeticaoStatusCrm>(Peticao, SDK.Operacoes.operacao.SetStatusCrm, null, null, true);

        }

        private void ExecutarModificar(string Identificador)
        {
            Comum.Clases.StatusCrm objStatusModificar = null;

            if(_objStatusCrm != null && _objStatusCrm.Count > 0 && !string.IsNullOrEmpty(Identificador))
            {
                objStatusModificar = _objStatusCrm.Find(s => s.Identificador == Identificador);
            }

            GuardarStatusCrm frmCores = new GuardarStatusCrm(objStatusModificar);

            if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
            {
                if (frmCores.StatusRetorno != null)
                {
                    if (objStatusModificar != null)
                    {
                        objStatusModificar.Descricao = frmCores.StatusRetorno.Descricao;
                        objStatusModificar.CorRGB = frmCores.StatusRetorno.CorRGB;
                        objStatusModificar.Codigo = frmCores.StatusRetorno.Codigo;                        
                    }
                    else
                    {
                        if (_objStatusCrm == null) { _objStatusCrm = new List<Comum.Clases.StatusCrm>(); }
                        _objStatusCrm.Add(new Comum.Clases.StatusCrm()
                        {
                            Codigo = frmCores.StatusRetorno.Codigo,
                            CorRGB = frmCores.StatusRetorno.CorRGB,
                            Descricao = frmCores.StatusRetorno.Descricao,
                            Identificador = frmCores.StatusRetorno.Identificador
                        });
                    }

                    ExecutarPreencherGrid(false);
                }
            }
        }

        private void ExecutarDeletar(string Identificador)
        {
            if(_objStatusCrm != null && _objStatusCrm.Count > 0)
            {
                _objStatusCrm.RemoveAll(stc => stc.Identificador == Identificador);
                ExecutarPreencherGrid(false);
            }
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ExecutarModificar(Identificador.Value);

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ExecutarDeletar(Identificador.Value);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        #region "Eventos"

        private void btnGravar_Click(object sender, EventArgs e)
        {

            try
            {
                ExecutarGravar();

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
                ExecutarModificar(string.Empty);
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

                                ExecutarModificar(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {
                                ExecutarDeletar(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);
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
