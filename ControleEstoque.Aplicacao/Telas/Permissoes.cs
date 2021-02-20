using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Informatiz.ControleEstoque;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using Informatiz.ControleEstoque.Aplicacao.Classes;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class Permissoes : TelaBase.BaseCE
    {

        private Boolean _EGrupo;
        private List<Comum.Clases.Permissao> _Permissoes = null;
        private List<Comum.Clases.Acao> _Acoes = null;
        private string _IdentificadorGrupo = string.Empty;
        private Comum.Clases.GrupoPermissao _objGrupoPermissao = null;
        private List<Comum.Clases.GrupoPermissao> _objGruposPermissoes = null;
        private Comum.Clases.GrupoPermissao objGrupocorrente = null;
        private List<Comum.Clases.Permissao> _objPermissoesPessoa = null;
        private string _IdentificadorPessoa;

        public Permissoes(Boolean EGrupo, string IdentificadorGrupo, string IdentificadorPessoa)
        {
            InitializeComponent();

            _EGrupo = EGrupo;
            _IdentificadorGrupo = IdentificadorGrupo;
            _IdentificadorPessoa = IdentificadorPessoa;

        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Eventos"


        private void dgvPermissoes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && _Permissoes != null && _Permissoes.Count > 0)
                {

                    Comum.Clases.Permissao objPermissao = (from Comum.Clases.Permissao objP in _Permissoes where objP.Identificador == dgvPermissoes.Rows[e.RowIndex].Cells[colIdentificador.Index].Value select objP).FirstOrDefault();

                    if (objPermissao != null)
                    {
                        if (objPermissao.Obrigatoria && e.ColumnIndex == colConsultar.Index)
                        {
                            DesenharCelula(sender, e, ButtonState.All);
                        }

                        if (objPermissao.Acoes != null && objPermissao.Acoes.Count > 0)
                        {

                            if (!objPermissao.Obrigatoria && e.ColumnIndex == colConsultar.Index)
                            {
                                DesabilitarCelulaAcao(Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR, objPermissao, sender, e);
                            }

                            if (e.ColumnIndex == colDeletar.Index)
                            {
                                DesabilitarCelulaAcao(Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR, objPermissao, sender, e);
                            }
                            if (e.ColumnIndex == colInserir.Index)
                            {
                                DesabilitarCelulaAcao(Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR, objPermissao, sender, e);
                            }
                            if (e.ColumnIndex == colModificar.Index)
                            {
                                DesabilitarCelulaAcao(Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR, objPermissao, sender, e);
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

        private void dgvPermissoes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex != colPermissoes.Index)
                {
                    Comum.Clases.Permissao objPermissao = (from Comum.Clases.Permissao objP in _Permissoes where objP.Identificador == dgvPermissoes.Rows[e.RowIndex].Cells[colIdentificador.Index].Value select objP).FirstOrDefault();

                    Boolean Marcar = false;

                    if (e.ColumnIndex == colConsultar.Index && !objPermissao.Obrigatoria)
                    {
                        Marcar = MarcharCheckBox(objPermissao, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR);
                    }
                    else if (e.ColumnIndex == colDeletar.Index)
                    {

                        Marcar = MarcharCheckBox(objPermissao, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR);
                    }
                    else if (e.ColumnIndex == colInserir.Index)
                    {
                        Marcar = MarcharCheckBox(objPermissao, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR);
                    }
                    else if (e.ColumnIndex == colModificar.Index)
                    {
                        Marcar = MarcharCheckBox(objPermissao, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR);
                    }


                    if (Marcar)
                    {
                        if (dgvPermissoes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                        {
                            dgvPermissoes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        }
                        else
                        {
                            dgvPermissoes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(Boolean)(dgvPermissoes.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {

                ExecutarGravar();

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
                return;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }


        private void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                objGrupocorrente = (Comum.Clases.GrupoPermissao)(frmWindows.Util.RecuperarItemSelecionado(ddlGrupo, _objGruposPermissoes, "Identificador"));

                if (objGrupocorrente != null)
                {
                    CarregarGrid(objGrupocorrente.Permissoes);
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
                return;
            }
        }

        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbPermissoes);
            if (_EGrupo)
            {
                tlpControles.RowStyles[1].Height = 0;
                this.Text = "Grupo de Permissões";
            }
            else
            {
                tlpControles.RowStyles[0].Height = 0;
                this.Text = "Permissões do Usuário";
            }

            CarregarTela();
            base.Inicializar();
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarPermissao)
            {
                ContratoServico.Telas.Permissoes.Carregar.RespostaPermissoesCarregar RespostaConvertido = (ContratoServico.Telas.Permissoes.Carregar.RespostaPermissoesCarregar)objSaida;

                _objGruposPermissoes = RespostaConvertido.GruposPermissoes;
                PreencherComboBoxGrupo();
                _Permissoes = RespostaConvertido.Permissoes;
                _objGrupoPermissao = RespostaConvertido.GrupoPermissao;
                _Acoes = RespostaConvertido.Acoes;
                _objPermissoesPessoa = RespostaConvertido.PermissoesFuncionario;


                if (_objGrupoPermissao != null)
                {
                    txtGrupo.Text = _objGrupoPermissao.Nome;
                    CarregarGrid(_objGrupoPermissao.Permissoes);
                }
                else
                {

                    if (_EGrupo)
                    {
                        CarregarGrid(null);
                    }
                    else
                    {

                        if (_objPermissoesPessoa != null && _objPermissoesPessoa.Count > 0)
                        {
                            ddlGrupo = (ComboBox)(frmWindows.Util.SelecionarItemControle(ddlGrupo, _objPermissoesPessoa.First().IdentificadorGrupoPermissao, "Identificador"));
                            CarregarGrid(_objPermissoesPessoa);
                        }
                        else
                        {
                            CarregarGrid(null);
                        }
                    }
                }
            }
            else if(operacao == SDK.Operacoes.operacao.GravarPermissoesUsuario)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Permissões cadastradas com sucesso.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if(operacao == SDK.Operacoes.operacao.GravarGrupoPermissao)
            {
                Aplicacao.Classes.Util.ExibirMensagemSucesso("Grupo de permissões cadastrado com sucesso.");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }
          

        private void RecuperarValorAcao(ref List<Comum.Clases.Acao> Acoes, Comum.Enumeradores.Enumeradores.TipoAcao TipoAcao,
                                        int rowIndex, DataGridViewCheckBoxColumn Col)
        {

            Boolean Marcado = false;

            if (dgvPermissoes.Rows[rowIndex].Cells[Col.Index].Value != null)
            {
                Marcado = (Boolean)(dgvPermissoes.Rows[rowIndex].Cells[Col.Index].Value);
            }
            else
            {
                Marcado = false;
            }

            Comum.Clases.Acao objAcao = null;


            objAcao = (from Comum.Clases.Acao objA in _Acoes where objA.TipoAcao == TipoAcao select objA).FirstOrDefault();

            if (objAcao != null && Marcado)
            {
                Acoes.Add(objAcao);
            }

        }

        private void ExecutarGravar()
        {


            if (_EGrupo)
            {
                Comum.Clases.GrupoPermissao objGrupoPermissao = new Comum.Clases.GrupoPermissao();

                objGrupoPermissao.Nome = txtGrupo.Text.Trim();
                objGrupoPermissao.Identificador = _IdentificadorGrupo;
                objGrupoPermissao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;

                if (dgvPermissoes.Rows.Count > 0)
                {

                    Comum.Clases.Permissao objPermissao = null;

                    foreach (DataGridViewRow dr in dgvPermissoes.Rows)
                    {

                        objPermissao = (from Comum.Clases.Permissao objP in _Permissoes where objP.Identificador == dr.Cells[colIdentificador.Index].Value select objP).FirstOrDefault();

                        if (objPermissao != null)
                        {

                            objPermissao.Acoes = new List<Comum.Clases.Acao>();

                            if (objGrupoPermissao.Permissoes == null) objGrupoPermissao.Permissoes = new List<Comum.Clases.Permissao>();

                            List<Comum.Clases.Acao> objAcoes = new List<Comum.Clases.Acao>();

                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR, dr.Index, colConsultar);
                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR, dr.Index, colInserir);
                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR, dr.Index, colModificar);
                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR, dr.Index, colDeletar);

                            objPermissao.Acoes = objAcoes;

                            objGrupoPermissao.Permissoes.Add(objPermissao);

                        }

                    }


                    ContratoServico.Permissao.GravarGrupoPermissao.PeticaoGravarGrupoPermissao Peticao = new ContratoServico.Permissao.GravarGrupoPermissao.PeticaoGravarGrupoPermissao();

                    Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
                    Peticao.IdentificadorGrupo = _IdentificadorGrupo;
                    Peticao.GrupoPermissao = objGrupoPermissao;


                    Agente.Agente.InvocarServico<ContratoServico.Permissao.GravarGrupoPermissao.RespostaGravarGrupoPermissao,
                        ContratoServico.Permissao.GravarGrupoPermissao.PeticaoGravarGrupoPermissao>(Peticao, SDK.Operacoes.operacao.GravarGrupoPermissao, null, null, true);

                }


            }
            else
            {
                List<Comum.Clases.Permissao> objPermissoesUsuario = new List<Comum.Clases.Permissao>();

                if (dgvPermissoes.Rows.Count > 0)
                {

                    Comum.Clases.Permissao objPermissao = null;

                    foreach (DataGridViewRow dr in dgvPermissoes.Rows)
                    {

                        objPermissao = (from Comum.Clases.Permissao objP in _Permissoes where objP.Identificador == dr.Cells[colIdentificador.Index].Value select objP).FirstOrDefault();

                        if (objPermissao != null)
                        {

                            if (objGrupocorrente != null)
                            {
                                objPermissao.IdentificadorGrupoPermissao = objGrupocorrente.Identificador;
                            }

                            objPermissao.Acoes = new List<Comum.Clases.Acao>();

                            List<Comum.Clases.Acao> objAcoes = new List<Comum.Clases.Acao>();

                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR, dr.Index, colConsultar);
                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR, dr.Index, colInserir);
                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR, dr.Index, colModificar);
                            RecuperarValorAcao(ref objAcoes, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR, dr.Index, colDeletar);

                            objPermissao.Acoes = objAcoes;

                            objPermissoesUsuario.Add(objPermissao);

                        }

                    }


                    ContratoServico.Permissao.GravarPermissoesUsuario.PeticaoGravarPermissoesUsuario Peticao = new ContratoServico.Permissao.GravarPermissoesUsuario.PeticaoGravarPermissoesUsuario();

                    Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
                    Peticao.IdentificadorFuncionario = _IdentificadorPessoa;
                    Peticao.Permissoes = objPermissoesUsuario;

      
                    Agente.Agente.InvocarServico<ContratoServico.Permissao.GravarPermissoesUsuario.RespostaGravarPermissoesUsuario, 
                        ContratoServico.Permissao.GravarPermissoesUsuario.PeticaoGravarPermissoesUsuario>(Peticao, SDK.Operacoes.operacao.GravarPermissoesUsuario, null, null, true);
                                                           
                }
            }

        }

        private void CarregarTela()
        {

            ContratoServico.Telas.Permissoes.Carregar.PeticaoPermissoesCarregar Peticao = new ContratoServico.Telas.Permissoes.Carregar.PeticaoPermissoesCarregar();

            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;

            if (!string.IsNullOrEmpty(_IdentificadorGrupo) && _EGrupo)
            {
                Peticao.IdentificadorGrupo = _IdentificadorGrupo;
            }
            Peticao.IdentificadorFuncionario = _IdentificadorPessoa;

            Agente.Agente.InvocarServico<ContratoServico.Telas.Permissoes.Carregar.RespostaPermissoesCarregar, ContratoServico.Telas.Permissoes.Carregar.PeticaoPermissoesCarregar>(Peticao, SDK.Operacoes.operacao.CarregarPermissao, null, null, true);
                     
        }

        private void PreencherComboBoxGrupo()
        {
            if (!_EGrupo)
            {
                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_objGruposPermissoes, "Identificador", "Nome");
                ddlGrupo = frmWindows.Util.PreencherCombobox(ddlGrupo, Items);
            }
        }
           

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }
              
        private void CarregarGrid(List<Comum.Clases.Permissao> objPermissoesCorrente)
        {

            dgvPermissoes.Rows.Clear();

            if (_Permissoes != null && _Permissoes.Count > 0)
            {

                Comum.Clases.Permissao objPermissaoCorrente = null;

                foreach (Comum.Clases.Permissao objPermissao in _Permissoes)
                {

                    dgvPermissoes.Rows.Add();
                    dgvPermissoes.Rows[dgvPermissoes.Rows.Count - 1].Cells[colIdentificador.Index].Value = objPermissao.Identificador;
                    dgvPermissoes.Rows[dgvPermissoes.Rows.Count - 1].Cells[colPermissoes.Index].Value = objPermissao.Descricao;
                    dgvPermissoes.Rows[dgvPermissoes.Rows.Count - 1].Cells[colConsultar.Index].Value = objPermissao.Obrigatoria;

                    if (objPermissoesCorrente != null)
                    {

                        objPermissaoCorrente = (from Comum.Clases.Permissao objPer in objPermissoesCorrente where objPer.Identificador == objPermissao.Identificador select objPer).FirstOrDefault();

                        if (objPermissaoCorrente != null && objPermissaoCorrente.Acoes != null && objPermissaoCorrente.Acoes.Count > 0)
                        {

                            foreach (Comum.Clases.Acao objAcao in objPermissaoCorrente.Acoes)
                            {

                                switch (objAcao.TipoAcao)
                                {

                                    case Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR:

                                        dgvPermissoes.Rows[dgvPermissoes.Rows.Count - 1].Cells[colConsultar.Index].Value = true;
                                        break;
                                    case Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR:

                                        dgvPermissoes.Rows[dgvPermissoes.Rows.Count - 1].Cells[colDeletar.Index].Value = true;
                                        break;
                                    case Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR:

                                        dgvPermissoes.Rows[dgvPermissoes.Rows.Count - 1].Cells[colInserir.Index].Value = true;
                                        break;
                                    case Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR:

                                        dgvPermissoes.Rows[dgvPermissoes.Rows.Count - 1].Cells[colModificar.Index].Value = true;
                                        break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DesenharCelula(object sender, DataGridViewCellPaintingEventArgs e, ButtonState Estado)
        {
            e.PaintBackground(e.CellBounds, true);

            Rectangle r = e.CellBounds;

            r.Width = 13;

            r.Height = 13;

            r.X += e.CellBounds.Width / 2 - 7;

            r.Y += e.CellBounds.Height / 2 - 7;

            ControlPaint.DrawCheckBox(e.Graphics, r, Estado);

            e.Handled = true;
        }

        private void DesabilitarCelulaAcao(Comum.Enumeradores.Enumeradores.TipoAcao TipoAcao, Comum.Clases.Permissao objPermissao,
                                           object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (objPermissao != null && objPermissao.Acoes != null && objPermissao.Acoes.Count > 0)
            {

                if (objPermissao.Acoes.FindAll(f => f.TipoAcao == TipoAcao).Count == 0)
                {
                    DesenharCelula(sender, e, ButtonState.Inactive);
                }
            }
        }

        private Boolean MarcharCheckBox(Comum.Clases.Permissao objPermissao, Comum.Enumeradores.Enumeradores.TipoAcao TipoAcao)
        {

            return objPermissao.Acoes.FindAll(f => f.TipoAcao == TipoAcao).Count > 0;
        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        #endregion
    }
}
