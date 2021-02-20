using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas.Venda
{
    public partial class InformarMesaAtendenteTouch : TelaBase.BaseCE
    {
        public InformarMesaAtendenteTouch(string IdentificadorVenda, Comum.Clases.Pessoa FuncionarioSelecionado, List<Comum.Clases.Mesa> MesasSelecionadas, Boolean RegistrarBase)
        {
            InitializeComponent();
            _IdentificadorVenda = IdentificadorVenda;
            _FuncionarioSelecionado = FuncionarioSelecionado;
            _MesasSelecionadas = MesasSelecionadas;
            _RegistrarBase = RegistrarBase;
            this.pnlBase.Controls.Add(tlpPrincipal);
        }

        #region "Variaveis"
        private Controles.ucHelper _ucHelperFuncionarios;
        private string _IdentificadorVenda;
        private List<Comum.Clases.Mesa> _Mesas;
        private Comum.Clases.Pessoa _FuncionarioSelecionado;
        private List<Comum.Clases.Mesa> _MesasSelecionadas;
        private Boolean _RegistrarBase;
        #endregion

        #region "Propriedades"
        public List<Comum.Clases.Mesa> Mesas { get; set; }
        public Comum.Clases.Pessoa Funcionario { get; set; }
        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

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
            CarregarControleFuncionarios();
            RecuperarDados();
        }

        private void CarregarControleFuncionarios()
        {

            _ucHelperFuncionarios = new Controles.ucHelper(Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO, false, true);
            _ucHelperFuncionarios.Dock = DockStyle.Fill;

            _ucHelperFuncionarios.DescricaoGrupo = "Dados do Funcionário";
            _ucHelperFuncionarios.CarregarControle();

            pnlClientes.Controls.Add(_ucHelperFuncionarios);

            if (_FuncionarioSelecionado != null && _FuncionarioSelecionado != null)
            {
                _ucHelperFuncionarios.PreencherDados(_FuncionarioSelecionado);
            }

        }

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.BuscarMesas)
            {

                _Mesas = ((ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas)(objSaida)).Mesas;
                if (_Mesas != null)
                {
                    _Mesas = (from m in _Mesas
                              where (_MesasSelecionadas != null && _MesasSelecionadas.Count > 0 && _MesasSelecionadas.Exists(ms => ms.Identificador == m.Identificador) ||
                                     (m.Ativa && m.Estado == Comum.Enumeradores.EstadoMesa.Livre))
                              select m).ToList();
                }
                PreencherFormasPagamento();
                if (_MesasSelecionadas != null && _MesasSelecionadas.Count > 0) frmWindows.Util.SelecionarItemControle(chlMesas, string.Empty, "Identificador", _MesasSelecionadas);
            }
            else if (operacao == SDK.Operacoes.operacao.InformarDadosVenda)
            {
                if (_ucHelperFuncionarios.DadoSelecinado != null)
                {
                    Funcionario = (Comum.Clases.Pessoa)_ucHelperFuncionarios.DadoSelecinado;
                }

                Mesas = frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Mesa>(chlMesas, _Mesas, "Identificador");

                base.objNotificacao.ExibirMensagem("Dados gravados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void PreencherFormasPagamento()
        {

            if (_Mesas != null && _Mesas.Count > 0)
            {

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_Mesas, "Identificador", "Codigo");

                chlMesas = frmWindows.Util.PreencherCheckedListBox(chlMesas, Items);

            }
        }

        private void RecuperarDados()
        {
            ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas Peticao = new ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas();

            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;


            Agente.Agente.InvocarServico<ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas, ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas>(Peticao, SDK.Operacoes.operacao.BuscarMesas,
                new Comum.ParametrosTela.Generica
                {
                    PreencherObjeto = true
                }, null, true);
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado, operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        #endregion

        #region "Eventos"

        private void btnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                Comum.Clases.Pessoa objFuncionario = null;

                if (_ucHelperFuncionarios.DadoSelecinado != null)
                {
                    objFuncionario = (Comum.Clases.Pessoa)_ucHelperFuncionarios.DadoSelecinado;
                }

                List<Comum.Clases.Mesa> items = frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Mesa>(chlMesas, _Mesas, "Identificador");
                List<string> IdentificadoresMesas = null;
                if (items != null && items.Count > 0)
                {
                    IdentificadoresMesas = items.Select(i => i.Identificador).ToList();
                }

                if (_RegistrarBase)
                {
                    ContratoServico.Venda.InformarDadosVenda.PeticaoInformarDadosVenda Peticao = new ContratoServico.Venda.InformarDadosVenda.PeticaoInformarDadosVenda();

                    Peticao.IdentificadorVenda = _IdentificadorVenda;
                    Peticao.IdentificadorFuncionario = objFuncionario != null ? objFuncionario.Identificador : string.Empty;
                    Peticao.IdentificadoresMesa = IdentificadoresMesas;
                    Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;


                    Agente.Agente.InvocarServico<ContratoServico.Venda.InformarDadosVenda.RespostaInformarDadosVenda, ContratoServico.Venda.InformarDadosVenda.PeticaoInformarDadosVenda>(Peticao,
                        SDK.Operacoes.operacao.InformarDadosVenda,
                        new Comum.ParametrosTela.Generica
                        {
                            PreencherObjeto = true
                        }, null, true);
                }
                else
                {
                    Funcionario = objFuncionario;
                    Mesas = items;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Descricao, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

    }
}
