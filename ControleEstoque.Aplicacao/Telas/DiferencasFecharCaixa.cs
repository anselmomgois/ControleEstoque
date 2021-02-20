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
    public partial class DiferencasFecharCaixa : TelaBase.BaseCE
    {
        #region "Construtor"


        public DiferencasFecharCaixa(List<Comum.Clases.FechamentoCaixa> Diferencas,
                                     Comum.Clases.Caixa Caixa,
                                     List<Comum.Clases.Sangria> Sangrias,
                                     List<Comum.Clases.Suprimento> Suprimentos,
                                     decimal SaldoInicial,
                                     string NomeSupervisor,
                                     string IdentificadorSupervisor)
        {
            InitializeComponent();

            _Diferencas = Diferencas;
            _Caixa = Caixa;
            _Sangrias = Sangrias;
            _Suprimentos = Suprimentos;
            _SaldoInicial = SaldoInicial;
            _NomeSupervisor = NomeSupervisor;
            _IdentificadorSupervisor = IdentificadorSupervisor;

        }

        #endregion

        #region "Variaveis"
        private List<Comum.Clases.FechamentoCaixa> _Diferencas;
        private Comum.Clases.Caixa _Caixa;
        private List<Comum.Clases.Sangria> _Sangrias;
        private List<Comum.Clases.Suprimento> _Suprimentos;
        private decimal _SaldoInicial;
        private string _NomeSupervisor;
        private string _IdentificadorSupervisor;
        #endregion

        #region "Constantes"
        private const string btnAceitarDiferenca = "btnAceitarDiferenca";
        #endregion

        #region "Metodos"
        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar Diferenças (F2)", btnAceitarDiferenca, Properties.Resources.cash_stack_add, new EventHandler(btnAceitarDiferencas_Click), Keys.F2, false, false, false);
            base.MontarMenu(GerarGrupo);
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

             if (operacao == SDK.Operacoes.operacao.FecharCaixa)
            {

                base.objNotificacao.ExibirMensagem("Caixa fechado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);

               
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }

        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(groupBox1);
            base.Inicializar();
            ExecutarPreencherGrid(false);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvMarcas.Rows.Clear();

            if (_Diferencas != null && _Diferencas.Count > 0)
            {

                foreach (Comum.Clases.FechamentoCaixa p in _Diferencas.OrderBy(p => p.DescricaoFormaPagamento))
                {
                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFormaPagamento.Name].Value = p.DescricaoFormaPagamento;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValorRecebido.Name].Value = p.ValorRecebido.ToString("N2");
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colValorPago.Name].Value = p.ValorFechamento.ToString("N2");
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDiferenca.Name].Value = p.ValorDiferenca.ToString("N2");

                }

                base.PreencherGrid(ExibirMensagem);

            }
        }

        #endregion



        #region "Eventos"

        private void btnAceitarDiferencas_Click(object sender, EventArgs e)
        {
            try
            {

                ContratoServico.Caixa.FecharCaixa.PeticaoFecharCaixa Peticao = new ContratoServico.Caixa.FecharCaixa.PeticaoFecharCaixa();

                Peticao.IdentificadorResponsavelCaixa = _Caixa.OperacaoCaixa.Identificador;
                Peticao.IdentificadorCaixa = _Caixa.Identificador;
                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
                Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
                Peticao.IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
                Peticao.PagamentosEfetuados = _Diferencas;
                Peticao.IdentificadorSupervisor = _IdentificadorSupervisor;

                Agente.Agente.InvocarServico<ContratoServico.Caixa.FecharCaixa.RespostaFecharCaixa, ContratoServico.Caixa.FecharCaixa.PeticaoFecharCaixa>(Peticao, SDK.Operacoes.operacao.FecharCaixa,
                    new Comum.ParametrosTela.Generica
                    {
                        PreencherObjeto = true
                    }, null, true);               

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
