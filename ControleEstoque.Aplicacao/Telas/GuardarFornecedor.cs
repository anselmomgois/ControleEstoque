using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmgSistemas.Framework.Componentes;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarFornecedor : TelaBase.BaseCE
    {
        public GuardarFornecedor(string IdentificadorPessoa, Boolean Visualizar)
        {
            InitializeComponent();

            _IdentificadorPessoa = IdentificadorPessoa;
            _Visualizar = Visualizar;

        }

        #region"Variaveis"

        private string _IdentificadorPessoa;
        private List<Comum.Clases.Pessoa> Pessoas;
        private List<Comum.Clases.SegmentoComercial> SegmentosComerciais;
        private CurrencyTextBox CurrencyTextBox;
        private Comum.Clases.Pessoa objPessoa = null;
        private Boolean _Visualizar;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
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
            this.pnlBase.Controls.Add(gpbFornecedor);
            CarregarTela();
            base.Inicializar();
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
            try
            {
                base.RespostaAgente(objSaida, operacao, Parametros);

                if (operacao == SDK.Operacoes.operacao.CarregarGuardarFornecedor)
                {

                    ContratoServico.Telas.GuardarFornecedor.Carregar.RespostaGuardarFornecedorCarregar objRespostaConvertido = (ContratoServico.Telas.GuardarFornecedor.Carregar.RespostaGuardarFornecedorCarregar)objSaida;

                    SegmentosComerciais = objRespostaConvertido.SegmentosComerciais;
                    objPessoa = objRespostaConvertido.Fornecedor;

                    PreencherComboSegmentoComercial();

                    CarregarCliente();

                    if (string.IsNullOrEmpty(_IdentificadorPessoa))
                    {

                        chkAtivo.Enabled = false;
                        chkAtivo.Checked = true;

                    }

                    if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SEGMENTO_COMERCIAL, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                    {
                        btnInserirSegmento.Visible = true;
                    }

                    BloquearTela();

                }
                else if (operacao == SDK.Operacoes.operacao.AtualizarPessoa)
                {
                    ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa objRespostaConvertido = (ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa)objSaida;

                    DadoRetornar = objRespostaConvertido.Pessoa;

                    base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else if (operacao == SDK.Operacoes.operacao.InserirPessoa)
                {
                    ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa objRespostaConvertido = (ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa)objSaida;

                    DadoRetornar = objRespostaConvertido.Pessoa;

                    base.objNotificacao.ExibirMensagem("Dados inseridos com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else if(operacao == SDK.Operacoes.operacao.PesquisarSegmentoComercial)
                {
                    SegmentosComerciais = ((ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.RespostaPesquisarSegmentoComercial)objSaida).SegmentoComercias;

                    PreencherComboSegmentoComercial();
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }

        private void BloquearTela()
        {

            if (_Visualizar)
            {

                txtNome.Enabled = false;
                ucEndereco.BloquearControle();
                chkAtivo.Enabled = false;
                txtCPF.Enabled = false;
                txtRG.Enabled = false;
                txtCnpj.Enabled = false;
                txtInscricao.Enabled = false;
                txtTelefoneCelular.Enabled = false;
                txtTelefoneFixo.Enabled = false;
                txtFax.Enabled = false;
                txtContato.Enabled = false;
                txtEmail.Enabled = false;
                cmbSegmento.Enabled = false;
                txtObservacao.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
            }
        }

        private void RecuperarSegmentos()
        {
            ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.PeticaoPesquisarSegmentoComercial Peticao = new ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.PeticaoPesquisarSegmentoComercial();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.RespostaPesquisarSegmentoComercial, ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.PeticaoPesquisarSegmentoComercial>(Peticao, 
                SDK.Operacoes.operacao.PesquisarSegmentoComercial,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = false,
                    PreencherObjeto = false
                }, null, true);           
              
        }

        private void CarregarCliente()
        {

            if (!string.IsNullOrEmpty(_IdentificadorPessoa))
            {                

                if (objPessoa != null)
                {

                    txtCodigo.Text = Convert.ToString(objPessoa.Codigo);
                    txtNome.Text = objPessoa.DesNome;
                    ucEndereco.CarregarControle(objPessoa.EnderecoCompleto);
                    txtCPF.Text = objPessoa.cpf;
                    txtRG.Text = objPessoa.RG;
                    txtCnpj.Text = objPessoa.cnpj;
                    txtInscricao.Text = objPessoa.InscricaoEstadual;
                    txtContato.Text = objPessoa.DesContato;
                    txtEmail.Text = objPessoa.DesEmail;
                    txtTelefoneFixo.Text = objPessoa.DesTelefoneFixo;
                    txtTelefoneCelular.Text = objPessoa.DesTelefoneCelular;
                    txtFax.Text = objPessoa.DesTelefoneFax;
                    chkAtivo.Checked = objPessoa.FornecedorAtivo;

                    if (objPessoa.SegmentoComercial != null)
                    {
                        cmbSegmento = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbSegmento, objPessoa.SegmentoComercial.Identificador, "Identificador"));
                    }

                }
            }
        }
        private void PreencherComboSegmentoComercial()
        {
            cmbSegmento.Items.Clear();

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(SegmentosComerciais, "Identificador", "Descricao");
            cmbSegmento = frmWindows.Util.PreencherCombobox(cmbSegmento, Items);

        }
        
        private void CarregarTela()
        {

            ucEndereco.InformarParametrosObrigatorios(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes);

            ContratoServico.Telas.GuardarFornecedor.Carregar.PeticaoGuardarFornecedorCarregar Peticao = new ContratoServico.Telas.GuardarFornecedor.Carregar.PeticaoGuardarFornecedorCarregar();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorFornecedor = _IdentificadorPessoa;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarFornecedor.Carregar.RespostaGuardarFornecedorCarregar, ContratoServico.Telas.GuardarFornecedor.Carregar.PeticaoGuardarFornecedorCarregar>(Peticao, SDK.Operacoes.operacao.CarregarGuardarFornecedor,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = false,
                    PreencherObjeto = true
                }, null, true);            

        }

        private void ExecutarInserirSegmento()
        {

            GuardarSegmentoComercial frmSergmento = new GuardarSegmentoComercial(string.Empty);

            if (frmSergmento.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarSegmentos();
            }
        }

        private void ExecutarGravar()
        {
            if (objPessoa == null)
            {
                objPessoa = new Comum.Clases.Pessoa();
            }
            objPessoa.TiposPessoa = new List<Comum.Clases.TipoPessoa>();
            objPessoa.TiposPessoa.Add(new Comum.Clases.TipoPessoa { Codigo = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR, Identificador = "3" });

            objPessoa.DesNome = txtNome.Text.Trim();
            objPessoa.Identificador = _IdentificadorPessoa;
            objPessoa.EnderecoCompleto = ucEndereco.RecuperarEndereco();

            if (objPessoa.EnderecoCompleto != null)
            {
                objPessoa.Endereco = objPessoa.EnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First();
            }
            else
            {
                objPessoa.Endereco = null;
            }

            string cpf = txtCPF.Text.Replace(",", "");
            cpf = cpf.Replace("-", "");

            if (!string.IsNullOrEmpty(cpf.Trim()))
            {
                objPessoa.cpf = txtCPF.Text.Trim();
            }
            else
            {
                objPessoa.cpf = string.Empty;
            }

            objPessoa.RG = txtRG.Text.Trim();

            if (!string.IsNullOrEmpty(txtCnpj.Text.Replace(",", "").Replace("/", "").Replace("-", "").Trim()))
            {
                objPessoa.cnpj = txtCnpj.Text;
            }
            else
            {
                objPessoa.cnpj = string.Empty;
            }

            objPessoa.InscricaoEstadual = txtInscricao.Text;

            objPessoa.FornecedorAtivo = chkAtivo.Checked;

            string telefone = txtTelefoneFixo.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                objPessoa.DesTelefoneFixo = txtTelefoneFixo.Text;
            }
            else
            {
                objPessoa.DesTelefoneFixo = string.Empty;
            }


            telefone = txtTelefoneCelular.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");


            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                objPessoa.DesTelefoneCelular = txtTelefoneCelular.Text;
            }
            else
            {
                objPessoa.DesTelefoneCelular = string.Empty;
            }


            telefone = txtFax.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                objPessoa.DesTelefoneFax = txtFax.Text;
            }
            else
            {
                objPessoa.DesTelefoneFax = string.Empty;
            }

            objPessoa.DesContato = txtContato.Text;
            objPessoa.DesEmail = txtEmail.Text;
            objPessoa.Empresa = new Comum.Clases.Empresa { Identificador = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador };

            if (cmbSegmento.SelectedItem != null)
            {
                objPessoa.SegmentoComercial = (Comum.Clases.SegmentoComercial)(frmWindows.Util.RecuperarItemSelecionado(cmbSegmento, SegmentosComerciais, "Identificador"));
            }
            else
            {
                objPessoa.SegmentoComercial = null;
            }

            if (!string.IsNullOrEmpty(_IdentificadorPessoa))
            {
                ContratoServico.Pessoa.AtualizarPessoa.PeticaoAtualizarPessoa Peticao = new ContratoServico.Pessoa.AtualizarPessoa.PeticaoAtualizarPessoa();

                Peticao.Pessoa = objPessoa;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Pessoa.AtualizarPessoa.RespostaAtualizarPessoa, ContratoServico.Pessoa.AtualizarPessoa.PeticaoAtualizarPessoa>(Peticao, SDK.Operacoes.operacao.AtualizarPessoa,
                    new Comum.ParametrosTela.Generica
                    {
                        ExibirMensagemNenhumRegistro = false,
                        PreencherObjeto = true
                    }, null, true);
            }
            else
            {
                ContratoServico.Pessoa.InserirPessoa.PeticaoInserirPessoa Peticao = new ContratoServico.Pessoa.InserirPessoa.PeticaoInserirPessoa();

                Peticao.Pessoa = objPessoa;
                Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa, ContratoServico.Pessoa.InserirPessoa.PeticaoInserirPessoa>(Peticao, SDK.Operacoes.operacao.InserirPessoa,
                    new Comum.ParametrosTela.Generica
                    {
                        ExibirMensagemNenhumRegistro = false,
                        PreencherObjeto = true
                    }, null, true);
            }
                       
        }

        #endregion

        #region"Eventos"

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

        private void btnInserirSegmento_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarInserirSegmento();
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
    }
}
