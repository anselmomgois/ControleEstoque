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
    public partial class FechamentoVendaRelatorio : TelaBase.BaseCE
    {
        #region"Variaveis"

        private Comum.Clases.Caixa _Caixa;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvRelatorio;
        private Comum.Clases.Relatorios.FechamentoCaixa.FechamentoCaixa _objFechamento;
        private Boolean _Fechamento;
        private List<Comum.Clases.Sangria> _Sangrias;
        private List<Comum.Clases.Suprimento> _Suprimentos;
        private decimal _SaldoInicial;
        private List<Comum.Clases.FechamentoCaixa> _Fechamentos;
        private string _NomeSupervisor;
        #endregion

        #region "Constantes"
        private const string btnFecharCaixa = "btnFecharCaixa";
        #endregion

        #region "Construtor"

        public FechamentoVendaRelatorio(Comum.Clases.Caixa Caixa,
                                        Boolean Fechamento,
                                        List<Comum.Clases.Sangria> Sangrias,
                                        List<Comum.Clases.Suprimento> Suprimentos,
                                        decimal SaldoInicial,
                                        List<Comum.Clases.FechamentoCaixa> Fechamentos,
                                        string NomeSupervisor)
        {
            InitializeComponent();

            _Caixa = Caixa;
            _Fechamento = Fechamento;
            _Suprimentos = Suprimentos;
            _Sangrias = Sangrias;
            _SaldoInicial = SaldoInicial;
            _Fechamentos = Fechamentos;
            _NomeSupervisor = NomeSupervisor;
        }

        #endregion

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
           if(!_Fechamento)  this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Fechar Caixa (F2)", btnFecharCaixa, Properties.Resources.cash_stack_add, new EventHandler(btnFecharCaixa_Click), Keys.F2, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(groupBox1);
            crvRelatorio = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            crvRelatorio.Dock = DockStyle.Fill;
            pnlReport.Controls.Add(crvRelatorio);
            crvRelatorio.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            crvRelatorio.BorderStyle = BorderStyle.FixedSingle;
            crvRelatorio.DisplayStatusBar = false;
            crvRelatorio.ShowGroupTreeButton = false;
            crvRelatorio.ShowParameterPanelButton = false;
            CarregarTela();
            base.Inicializar();
        }

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

            if (operacao == SDK.Operacoes.operacao.RecuperarPagamentosCaixa)
            {
                ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa objRespostaConvertido = (ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa)objSaida;

               
                _objFechamento = new Comum.Clases.Relatorios.FechamentoCaixa.FechamentoCaixa();

                _objFechamento.NomeFuncionario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Nome;
                _objFechamento.Empresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome;
                _objFechamento.NumeroCaixa = _Caixa.Codigo;
                _objFechamento.Vendas = objRespostaConvertido.Vendas;
                _objFechamento.Sangrias = objRespostaConvertido.Sangrias;
                _objFechamento.Suprimentos = objRespostaConvertido.Suprimentos;
                _objFechamento.SaldoInicialCaixa = objRespostaConvertido.SaldoInicial;                

                _objFechamento.Endereco = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EnderecoEmpresa;
      
                crvRelatorio.ReportSource = Informatiz.ControleEstoque.Relatorios.Classes.Relatorio.Gerar(_objFechamento,Comum.Enumeradores.TipoRelatorio.VendasCaixa);

            }


        }

        private void CarregarTela()
        {
            if (_Fechamento)
            {

                _objFechamento = new Comum.Clases.Relatorios.FechamentoCaixa.FechamentoCaixa();

                _objFechamento.NomeFuncionario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Nome;
                _objFechamento.Empresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome;
                _objFechamento.NumeroCaixa = _Caixa.Codigo;
                _objFechamento.Sangrias = _Sangrias;
                _objFechamento.Suprimentos = _Suprimentos;
                _objFechamento.SaldoInicialCaixa = _SaldoInicial;
                _objFechamento.Fechamentos = _Fechamentos;
                _objFechamento.NomeSupervisor = _NomeSupervisor;
                              

                _objFechamento.Endereco = Parametros.Parametros.InformacaoUsuario.EnderecoEmpresa;

                crvRelatorio.ReportSource = Informatiz.ControleEstoque.Relatorios.Classes.Relatorio.Gerar(_objFechamento, Comum.Enumeradores.TipoRelatorio.FechamentoCaixa);
         

            }
            else
            {

                ContratoServico.Venda.RecuperarPagamentosCaixa.PeticaoRecuperarPagamentosCaixa Peticao = new ContratoServico.Venda.RecuperarPagamentosCaixa.PeticaoRecuperarPagamentosCaixa()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                    IdentificadorResponsavelCaixa = _Caixa.OperacaoCaixa.Identificador
                };

                Agente.Agente.InvocarServico<ContratoServico.Venda.RecuperarPagamentosCaixa.RespostaRecuperarPagamentosCaixa, ContratoServico.Venda.RecuperarPagamentosCaixa.PeticaoRecuperarPagamentosCaixa>(Peticao,
                      SDK.Operacoes.operacao.RecuperarPagamentosCaixa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
            }

        }

        #endregion
        #region "Eventos"
        private void btnFecharCaixa_Click(object sender, EventArgs e)
        {
            try
            {

                GuardarFecharVenda frmFecharVenda = new GuardarFecharVenda(null, false, false, _Caixa, _objFechamento.Vendas, _objFechamento.Sangrias, 
                    _objFechamento.Suprimentos, _objFechamento.SaldoInicialCaixa, (_Caixa != null && _Caixa.OperacaoCaixa != null ? _Caixa.OperacaoCaixa.Identificador : string.Empty));

                if (AbrirFormulario(frmFecharVenda) == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
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
