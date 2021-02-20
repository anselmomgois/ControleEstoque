using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Controles
{
    public partial class ucHelper : UserControl
    {
        bool _touch;
        public ucHelper(Comum.Enumeradores.Enumeradores.TipoHelper TipoBusca, bool Visualizar, bool touch)
        {
            InitializeComponent();
            _touch = touch;
            Aplicacao.Classes.Util.ConfigurarEstilo(this);
            Aplicacao.Classes.Util.ConfigurarFocoComponentes(this);

            _TipoBusca = TipoBusca;
            _Visualizar = Visualizar;

            if (Visualizar)
            {
                btnInserir.Visible = false;
                btnLimpar.Visible = false;
                btnPesquisar.Visible = false;
            }

            if (_touch)
            {
                btnInserir.Visible = false;
                btnModificar.Visible = false;
                btnLimpar.Location = new Point(357, 41);
            }

            ConfigurarControles();
        }

        #region"Variaveis"

        private Telas.TelaBase.BaseCE _frm;
        private Comum.Enumeradores.Enumeradores.TipoHelper _TipoBusca;
        private object _DadoSelecionado;
        private Boolean _Visualizar;
        #endregion

        #region "Propriedades"

        public string DescricaoGrupo { get; set; }

        public object DadoSelecinado
        {
            get
            {
                return _DadoSelecionado;
            }
        }


        #endregion

        #region"Metodos"

        public void SomenteLeitura(Boolean Visualizar)
        {
            btnInserir.Visible = !Visualizar;
            btnLimpar.Visible = !Visualizar;
            btnPesquisar.Visible = !Visualizar;
        }
        public void ConfigurarControles()
        {

            if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE)
            {
                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                {
                    btnInserir.Enabled = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
                {
                    btnModificar.Enabled = false;
                }

            }
            else if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR)
            {
                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                {
                    btnInserir.Enabled = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
                {
                    btnModificar.Enabled = false;
                }
            }
            else if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO)
            {
                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                {
                    btnInserir.Enabled = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
                {
                    btnModificar.Enabled = false;
                }
            }

        }

        public void PreencherDados(object objDados)
        {

            if (objDados != null)
            {
                _DadoSelecionado = objDados;

                if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE || _TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR ||
                     _TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO)
                {
                    Comum.Clases.Pessoa objPessoa = (Comum.Clases.Pessoa)(objDados);
                    txtCodigo.Text = objPessoa.Codigo.ToString();
                    txtDescricao.Text = objPessoa.DesNome;
                }
            }
        }
        public void CarregarControle()
        {

            gpbDados.Text = DescricaoGrupo;

        }
        #endregion

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (_touch)
                {
                    this.ChamarHelperTouch();
                }
                else
                {
                    this.ChamarHelper();
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void ChamarHelper()
        {
            Telas.Helper frmHelper = new Telas.Helper(_TipoBusca, string.Empty);
            frmHelper.ShowDialog();

            if (frmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (frmHelper.DadoSelecinado != null)
                {

                    Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmHelper.DadoSelecinado);
                    _DadoSelecionado = frmHelper.DadoSelecinado;
                    txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                    txtDescricao.Text = ClienteSelecionado.DesNome;

                }
                else
                {
                    _DadoSelecionado = null;
                    txtCodigo.Text = string.Empty;
                    txtDescricao.Text = string.Empty;
                }

            }
        }

        private void ChamarHelperTouch()
        {
            Telas.HelperTouch frmHelper = new Telas.HelperTouch(_TipoBusca, string.Empty);
            frmHelper.ShowDialog();

            if (frmHelper.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                if (frmHelper.DadoSelecinado != null)
                {

                    Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmHelper.DadoSelecinado);
                    _DadoSelecionado = frmHelper.DadoSelecinado;
                    txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                    txtDescricao.Text = ClienteSelecionado.DesNome;

                }
                else
                {
                    _DadoSelecionado = null;
                    txtCodigo.Text = string.Empty;
                    txtDescricao.Text = string.Empty;
                }

            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                _DadoSelecionado = null;
                txtCodigo.Text = string.Empty;
                txtDescricao.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {

                if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE)
                {
                    Telas.GuardarCliente frmCliente = new Telas.GuardarCliente(string.Empty, false);

                    if (frmCliente.ShowDialog() == DialogResult.OK)
                    {

                        if (frmCliente.DadoRetornar != null)
                        {
                            if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE)
                            {
                                Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmCliente.DadoRetornar);
                                _DadoSelecionado = frmCliente.DadoRetornar;
                                txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                                txtDescricao.Text = ClienteSelecionado.DesNome;
                            }
                        }
                    }

                }
                else if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR)
                {
                    Telas.GuardarFornecedor frmFornecedor = new Telas.GuardarFornecedor(string.Empty, false);

                    if (frmFornecedor.ShowDialog() == DialogResult.OK)
                    {

                        if (frmFornecedor.DadoRetornar != null)
                        {
                            if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR)
                            {
                                Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmFornecedor.DadoRetornar);
                                _DadoSelecionado = frmFornecedor.DadoRetornar;
                                txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                                txtDescricao.Text = ClienteSelecionado.DesNome;
                            }
                        }
                    }

                }
                else if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO)
                {
                    Telas.GuardarFuncionario frmFuncionario = new Telas.GuardarFuncionario(string.Empty, false);

                    if (frmFuncionario.ShowDialog() == DialogResult.OK)
                    {

                        if (frmFuncionario.DadoRetornar != null)
                        {
                            if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO)
                            {
                                Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmFuncionario.DadoRetornar);
                                _DadoSelecionado = frmFuncionario.DadoRetornar;
                                txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                                txtDescricao.Text = ClienteSelecionado.DesNome;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {

                if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE)
                {
                    if (_DadoSelecionado != null)
                    {
                        string Identificador = ((Comum.Clases.Pessoa)_DadoSelecionado).Identificador;

                        Telas.GuardarCliente frmCliente = new Telas.GuardarCliente(Identificador, false);

                        if (frmCliente.ShowDialog() == DialogResult.OK)
                        {

                            if (frmCliente.DadoRetornar != null)
                            {
                                if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.CLIENTE)
                                {
                                    Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmCliente.DadoRetornar);
                                    _DadoSelecionado = frmCliente.DadoRetornar;
                                    txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                                    txtDescricao.Text = ClienteSelecionado.DesNome;
                                }
                            }
                        }
                    }
                }
                else if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR)
                {
                    if (_DadoSelecionado != null)
                    {
                        string Identificador = ((Comum.Clases.Pessoa)_DadoSelecionado).Identificador;

                        Telas.GuardarFornecedor frmFornecedor = new Telas.GuardarFornecedor(Identificador, false);

                        if (frmFornecedor.ShowDialog() == DialogResult.OK)
                        {

                            if (frmFornecedor.DadoRetornar != null)
                            {
                                if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FORNECEDOR)
                                {
                                    Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmFornecedor.DadoRetornar);
                                    _DadoSelecionado = frmFornecedor.DadoRetornar;
                                    txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                                    txtDescricao.Text = ClienteSelecionado.DesNome;
                                }
                            }
                        }
                    }
                }
                else if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO)
                {
                    if (_DadoSelecionado != null)
                    {
                        string Identificador = ((Comum.Clases.Pessoa)_DadoSelecionado).Identificador;

                        Telas.GuardarFuncionario frmFuncionario = new Telas.GuardarFuncionario(Identificador, false);

                        if (frmFuncionario.ShowDialog() == DialogResult.OK)
                        {

                            if (frmFuncionario.DadoRetornar != null)
                            {
                                if (_TipoBusca == Comum.Enumeradores.Enumeradores.TipoHelper.FUNCIONARIO)
                                {
                                    Comum.Clases.Pessoa ClienteSelecionado = (Comum.Clases.Pessoa)(frmFuncionario.DadoRetornar);
                                    _DadoSelecionado = frmFuncionario.DadoRetornar;
                                    txtCodigo.Text = Convert.ToString(ClienteSelecionado.Codigo);
                                    txtDescricao.Text = ClienteSelecionado.DesNome;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
