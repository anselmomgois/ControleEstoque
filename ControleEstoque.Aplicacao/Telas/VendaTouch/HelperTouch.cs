using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class HelperTouch : TelaBase.BaseCE
    {
        #region"Variaveis"

        private Comum.Enumeradores.Enumeradores.TipoHelper _TipoHelper;
        private string _IdentificadorPai;
        private object Dados;
        private object _DadoSelecionado;
        #endregion

        #region"Propriedade"

        public object DadoSelecinado
        {
            get
            {
                return _DadoSelecionado;
            }
        }

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        public HelperTouch(Comum.Enumeradores.Enumeradores.TipoHelper TipoHelper, string IdentificadorPai)
        {
            InitializeComponent();

            _TipoHelper = TipoHelper;
            _IdentificadorPai = IdentificadorPai;
            this.pnlBase.Controls.Add(tlpPrincipal);
            BuscarFuncionarios();
        }

        #region"Eventos"


        private void BuscarFuncionarios()
        {

            try
            {

                switch (_TipoHelper)
                {                     
                    case Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO:

                        BuscarFuncionario();
                        break;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            try
            {
                RetornarDados();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                frmUtil.Util.SomenteNumero(sender, e);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F3)", btnAceitar, Properties.Resources._new, new EventHandler(btnAceitar_Click), Keys.F3, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(tlpPrincipal);           
            base.Inicializar();

        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {

            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        private void BuscarFuncionario()
        {
            lstHelper.Items.Clear();

            ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao = new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
            {
                TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO,
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas, ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas>(Peticao,
                  SDK.Operacoes.operacao.RecuperarPessoas, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

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

                if (operacao == SDK.Operacoes.operacao.RecuperarPessoas)
                {

                    List<Comum.Clases.Pessoa> Pessoas = ((ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas)objSaida).Pessoas;
                    Dados = Pessoas;

                    if (Pessoas != null && Pessoas.Count > 0)
                    {                      

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Pessoas, "Identificador", "NomeCodigo");
                        lstHelper = frmWindows.Util.PreencherListBox(lstHelper, Items);
                    }
                    else
                    {
                        Aplicacao.Classes.Util.ExibirMensagemSucesso("Nenhum resultado encontrado");
                    }
                }
                else if (operacao == SDK.Operacoes.operacao.RecuperarBairro)
                {

                    List<Comum.Clases.Bairro> Bairros = ((ContratoServico.Endereco.RecuperarBairro.RespostaRecuperarBairro)objSaida).Bairros;

                    Dados = Bairros;

                    if (Bairros != null && Bairros.Count > 0)
                    {

                        foreach (Comum.Clases.Bairro b in Bairros)
                        {

                            b.NomeCodigo = b.Codigo + " - " + b.Nome;

                        }

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Bairros, "Identificador", "NomeCodigo");
                        lstHelper = frmWindows.Util.PreencherListBox(lstHelper, Items);
                    }
                    else
                    {
                        Aplicacao.Classes.Util.ExibirMensagemSucesso("Nenhum resultado encontrado");
                    }
                }
                else if(operacao == SDK.Operacoes.operacao.RecuperarCidades)
                {
                    List<Comum.Clases.Cidade> Cidades = ((ContratoServico.Endereco.RecuperarCidades.RespostaRecuperarCidades)objSaida).Cidades;

                    Dados = Cidades;

                    if (Cidades != null && Cidades.Count > 0)
                    {

                        foreach (Comum.Clases.Cidade cid in Cidades)
                        {
                            cid.NomeCodigo = cid.Codigo + " - " + cid.Nome;

                        }

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Cidades, "Identificador", "NomeCodigo");
                        lstHelper = frmWindows.Util.PreencherListBox(lstHelper, Items);
                    }
                    else
                    {
                        Aplicacao.Classes.Util.ExibirMensagemSucesso("Nenhum resultado encontrado");
                    }
                }
                else if(operacao == SDK.Operacoes.operacao.PesquisarEndereco)
                {
                    List<Comum.Clases.Endereco> Enderecos = ((ContratoServico.Endereco.PesquisarEndereco.RespostaPesquisarEndereco)objSaida).Enderecos;

                    Dados = Enderecos;

                    if (Enderecos != null && Enderecos.Count > 0)
                    {

                        foreach (Comum.Clases.Endereco b in Enderecos)
                        {
                            b.NomeCodigo = b.Codigo + " - " + b.DescricaoRua;

                        }

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Enderecos, "Identificador", "NomeCodigo");
                        lstHelper = frmWindows.Util.PreencherListBox(lstHelper, Items);
                    }
                    else
                    {
                        Aplicacao.Classes.Util.ExibirMensagemSucesso("Nenhum resultado encontrado");
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                return;
            }
        }


        private void RetornarDados()
        {

            if (lstHelper.SelectedIndex >= 0)
            {
                if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.CIDADE)
                {

                    List<Comum.Clases.Cidade> Cidades = (List<Comum.Clases.Cidade>)(Dados);
                    Comum.Clases.Cidade objCidade = (Comum.Clases.Cidade)(frmWindows.Util.RecuperarItemSelecionado(lstHelper, Cidades, "Identificador"));

                    Comum.Clases.Cidade Cidade = (from c in Cidades where c.Identificador == objCidade.Identificador select c).FirstOrDefault();

                    if (Cidade != null)
                    {

                        _DadoSelecionado = Cidade;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }


                }
                else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.BAIRRO)
                {

                    List<Comum.Clases.Bairro> Bairros = (List<Comum.Clases.Bairro>)(Dados);
                    Comum.Clases.Bairro objBairro = (Comum.Clases.Bairro)(frmWindows.Util.RecuperarItemSelecionado(lstHelper, Bairros, "Identificador"));

                    Comum.Clases.Bairro Bairro = (from b in Bairros where b.Identificador == objBairro.Identificador select b).FirstOrDefault();

                    if (Bairro != null)
                    {

                        _DadoSelecionado = Bairro;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }

                }
                else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.ENDERECO)
                {

                    List<Comum.Clases.Endereco> Enderecos = (List<Comum.Clases.Endereco>)(Dados);
                    Comum.Clases.Endereco objEndereco = (Comum.Clases.Endereco)(frmWindows.Util.RecuperarItemSelecionado(lstHelper, Enderecos, "Identificador"));

                    Comum.Clases.Endereco Endereco = (from b in Enderecos where b.Identificador == objEndereco.Identificador select b).FirstOrDefault();

                    if (Endereco != null)
                    {

                        _DadoSelecionado = Endereco;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }

                }
                else if (_TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE || _TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR ||
                    _TipoHelper == Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO)
                {

                    List<Comum.Clases.Pessoa> Clientes = (List<Comum.Clases.Pessoa>)(Dados);
                    Comum.Clases.Pessoa objCliente = (Comum.Clases.Pessoa)(frmWindows.Util.RecuperarItemSelecionado(lstHelper, Clientes, "Identificador"));

                    Comum.Clases.Pessoa Cliente = (from b in Clientes where b.Identificador == objCliente.Identificador select b).FirstOrDefault();

                    if (Cliente != null)
                    {

                        _DadoSelecionado = Cliente;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Close();
                    }

                }
            }
            else
            {
                Aplicacao.Classes.Util.ExibirMensagemErro("É obrigatório selecionar um item.");

            }

        }

        #endregion



    }
}
