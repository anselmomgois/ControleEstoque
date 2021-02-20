using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmgSistemas.Framework.Componentes;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    public partial class ucEndereco : UserControl
    {

        #region"Variaveis"

        private Comum.Clases.Endereco _Endereco;
        private Comum.Clases.Estado _Estado;
        private List<Comum.Clases.Permissao> _Permissoes;

        #endregion

        public Classes.AgenteServico Agente { get; set; }
        public List<SDK.Operacoes.operacao> ServicosEmProcesamento { get; set; }

        public ucEndereco()
        {
            InitializeComponent();
            Aplicacao.Classes.Util.ConfigurarFocoComponentes(this);
            Aplicacao.Classes.Util.ConfigurarEstilo(this);

            Agente = new Classes.AgenteServico();          

        }

        private void Agente_FimOperacao(SDK.Operacoes.operacao operacao, List<string> NomeControles, bool ExecutarFimProcesamento, Boolean NaoDesabilitarControles)
        {
           
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
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void Agente_DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            
        }

        private void Agente_SetarCursorWait(object sender, EventArgs e)
        {
           
        }

        private void Agente_StatusOperacao(Exception ex, object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            try
            {
                if (objSaida != null)
                {


                    ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco objSaidaConvertido = (ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco)objSaida;

                    if (objSaidaConvertido.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO))
                    {
                        throw new Exception(objSaidaConvertido.DescricaoErro);
                    }

                    _Estado = objSaidaConvertido.Estado;

                    if (_Estado != null)
                    {

                        txtEstado.Text = _Estado.Codigo + " - " + _Estado.Nome;
                        txtCidade.Text = _Estado.Cidades.First().Nome;
                        txtBairro.Text = _Estado.Cidades.First().Bairros.First().Nome;
                        txtEndereco.Text = _Estado.Cidades.First().Bairros.First().Enderecos.First().DescricaoRua;
                    }
                    else
                    {
                        AbrirTelaConsultaEndereco();
                    }

                }
                else
                {
                    Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
                }

            }
            catch (Exception ex1)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex1.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        public void InformarParametrosObrigatorios(List<Comum.Clases.Permissao> Permissoes)
        {
            _Permissoes = Permissoes;
        }

        public void CarregarControle(Comum.Clases.Estado Estado)
        {
            _Estado = Estado;
          
            if (_Estado != null)
            {
                txtEstado.Text = _Estado.Codigo + " - " + _Estado.Nome;
                txtCidade.Text = _Estado.Cidades.First().Nome;
                txtBairro.Text = _Estado.Cidades.First().Bairros.First().Nome;
                txtEndereco.Text = _Estado.Cidades.First().Bairros.First().Enderecos.First().DescricaoRua;
                txtCep.Text = _Estado.Cidades.First().Bairros.First().Enderecos.First().DescricaoCep;

                if (_Estado.Cidades.First().Bairros.First().Enderecos.First().Numero != null)
                {
                    txtNumero.Text = Convert.ToString(_Estado.Cidades.First().Bairros.First().Enderecos.First().Numero);
                }

                txtReferencia.Text = _Estado.Cidades.First().Bairros.First().Enderecos.First().DesReferencia;
                txtComplemento.Text = _Estado.Cidades.First().Bairros.First().Enderecos.First().Complemento;

            }
        }

        public Comum.Clases.Estado RecuperarEndereco()
        {

            if (_Estado != null)
            {
                if (!string.IsNullOrEmpty(txtNumero.Text))
                {
                    _Estado.Cidades.First().Bairros.First().Enderecos.First().Numero = Convert.ToInt32(txtNumero.Text);
                }

                _Estado.Cidades.First().Bairros.First().Enderecos.First().DesReferencia = txtReferencia.Text;
                _Estado.Cidades.First().Bairros.First().Enderecos.First().Complemento = txtComplemento.Text;
            }

            return _Estado;
        }

        private void ConsultarEndereco()
        {

            string cep = txtCep.Text.Replace(",", "");
            cep = cep.Replace("-", "");

            if (!string.IsNullOrEmpty(cep.Trim()))
            {
                ContratoServico.Endereco.RegistrarEndereco.PeticaoRegistrarEndereco Peticao = new ContratoServico.Endereco.RegistrarEndereco.PeticaoRegistrarEndereco()
                {
                    Cep = cep,
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login
                };
                Agente.Agente.InvocarServico<ContratoServico.Endereco.RegistrarEndereco.RespostaRegistrarEndereco, ContratoServico.Endereco.RegistrarEndereco.PeticaoRegistrarEndereco>(Peticao,
                        SDK.Operacoes.operacao.RegistrarEndereco, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

            }
            else
            {

                AbrirTelaConsultaEndereco();
            }

        }

        private void AbrirTelaConsultaEndereco()
        {

            Aplicacao.Telas.BuscarEndereco objFrmBuscaEndereco = new Aplicacao.Telas.BuscarEndereco(_Permissoes);

            objFrmBuscaEndereco.ShowDialog();

            if (objFrmBuscaEndereco.DialogResult == DialogResult.OK && objFrmBuscaEndereco.EnderecoCompleto != null)
            {

                txtEstado.Text = objFrmBuscaEndereco.EnderecoCompleto.Codigo + " - " + objFrmBuscaEndereco.EnderecoCompleto.Nome;
                txtCidade.Text = objFrmBuscaEndereco.EnderecoCompleto.Cidades.First().Nome;
                txtBairro.Text = objFrmBuscaEndereco.EnderecoCompleto.Cidades.First().Bairros.First().Nome;
                txtEndereco.Text = objFrmBuscaEndereco.EnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().DescricaoRua;
                txtCep.Text = objFrmBuscaEndereco.EnderecoCompleto.Cidades.First().Bairros.First().Enderecos.First().DescricaoCep;

                _Estado = objFrmBuscaEndereco.EnderecoCompleto;

            }
        }

        public void BloquearControle()
        {
            btnConsultar.Enabled = false;
            txtCep.Enabled = false;
            txtComplemento.Enabled = false;
            txtNumero.Enabled = false;
            txtReferencia.Enabled = false;
        }

        #region "Eventos"

        private void btnConsultar_Click(object sender, EventArgs e)
        {

            try
            {

                ConsultarEndereco();

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
        #endregion

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {

                frmUtil.Util.SomenteNumero(sender, e);

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void ucEndereco_Load(object sender, EventArgs e)
        {
            try
            {

                Agente.Agente.StatusOperacao += Agente_StatusOperacao;
                Agente.Agente.SetarCursorWait += Agente_SetarCursorWait;
                Agente.Agente.DesabilitarControles += Agente_DesabilitarControles;
                Agente.Agente.InicioOperacao += Agente_InicioOperacao;
                Agente.Agente.FimOperacao += Agente_FimOperacao;

            }
            catch (Execao.ExecaoNegocio ex)
            {
                Aplicacao.Classes.Util.ExibirMensagemErro(ex.Descricao);
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
