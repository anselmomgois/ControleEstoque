using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using frmWeb = AmgSistemas.Framework.Web;

namespace Informatiz.ControleEstoque.Web
{
    public partial class CadastroClientes : System.Web.UI.Page
    {

        #region"[PROPRIEDADES]"

        public List<Comum.Clases.Estado> Estados
        {
            get
            {
                if (Session["Estados"] != null)
                {
                    return (List<Comum.Clases.Estado>)(Session["Estados"]);
                }
                else
                {
                    return null;
                }

            }
            set { Session["Estados"] = value; }
        }

        public List<Comum.Clases.Pessoa> Pessoas
        {
            get
            {
                if (Session["Pessoas"] != null)
                {
                    return (List<Comum.Clases.Pessoa>)(Session["Pessoas"]);
                }
                else
                {
                    return null;
                }

            }
            set { Session["Pessoas"] = value; }
        }

        public Comum.Clases.Estado Endereco
        {
            get
            {
                if (Session["Endereco"] != null)
                {
                    return (Comum.Clases.Estado)(Session["Endereco"]);
                }
                else
                {
                    return null;
                }

            }
            set { Session["Endereco"] = value; }
        }

        public Comum.Clases.Estado Estado
        {
            get
            {
                if (Session["Estado"] != null)
                {
                    return (Comum.Clases.Estado)(Session["Estado"]);
                }
                else
                {
                    return null;
                }

            }
            set { Session["Estado"] = value; }
        }

        public List<Comum.Clases.Publicidade> objPublicidades
        {
            get
            {
                if (Session["objPublicidades"] != null)
                {
                    return (List<Comum.Clases.Publicidade>)(Session["objPublicidades"]);
                }
                else
                {
                    return null;
                }

            }
            set { Session["objPublicidades"] = value; }
        }

        public List<Comum.Clases.Cidade> Cidades
        {
            get
            {
                if (Session["Cidades"] != null)
                {
                    return (List<Comum.Clases.Cidade>)(Session["Cidades"]);
                }
                else
                {
                    return null;
                }

            }
            set { Session["Cidades"] = value; }
        }
        #endregion

        #region "[EVENTOS]"

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                txtCep.Attributes.Add("onkeypress", "return ValorNumerico(event);");
                txtNumero.Attributes.Add("onkeypress", "return ValorNumerico(event);");
                txtTelefoneFixo.Attributes.Add("onkeyup", "mascara(this, mtel);");
                txtTelefoneCelular.Attributes.Add("onkeyup", "mascara(this, mtel);");
                CarregarTela();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {

                System.Text.StringBuilder objErros = new System.Text.StringBuilder();

                if (string.IsNullOrEmpty(txtEmpresa.Text.Trim()))
                {
                    objErros.AppendLine("Nome da Empresa é Obrigatório. </br>");
                }

                if (string.IsNullOrEmpty(txtNome.Text.Trim()))
                {
                    objErros.AppendLine("O nome é Obrigatório. </br>");
                }

                if (string.IsNullOrEmpty(txtUsuario.Text.Trim()))
                {
                    objErros.AppendLine("O Usuário é Obrigatório. </br>");
                }

                if (string.IsNullOrEmpty(txtSenha.Text.Trim()))
                {
                    objErros.AppendLine("A Senha é Obrigatória. </br>");
                }

                if (string.IsNullOrEmpty(txtConfirmarSenha.Text.Trim()))
                {
                    objErros.AppendLine("A Confirmação da Senha é Obrigatória. </br>");
                }

                if (!txtConfirmarSenha.Text.Equals(txtSenha.Text))
                {
                    objErros.AppendLine("Os Campos Senha e Confirmação da Senha não são iguais. </br>");
                }

                if (objErros.Length > 0)
                {
                    throw new Execao.ExecaoNegocio(Execao.Constantes.CodigoErro.ERRO_NEGOCIO, objErros.ToString());
                }

                ContratoServico.InserirEmpresa.Peticao objPeticao = new ContratoServico.InserirEmpresa.Peticao();
                ContratoServico.InserirEmpresa.Respuesta objRespuesta = null;
                LogicaNegocio.Servico.Empresa objAcao = new LogicaNegocio.Servico.Empresa();

                objPeticao.DescricaoEmpresa = txtEmpresa.Text.Trim();
                objPeticao.NomeUsuario = txtNome.Text.Trim();
                objPeticao.Usuario = txtUsuario.Text.Trim();
                objPeticao.Senha = txtSenha.Text.Trim();
                objPeticao.TelefoneCelular = txtTelefoneCelular.Text.Trim();
                objPeticao.TelefoneFixo = txtTelefoneFixo.Text.Trim();
                objPeticao.Email = txtEmail.Text.Trim();

                if (ddlPublicidade.SelectedIndex > 0)
                {
                    Comum.Clases.Publicidade objPublictidade = (Comum.Clases.Publicidade)(frmWeb.Util.RecuperarItemSelecionado(ddlPublicidade, objPublicidades, "Identificador"));

                    if (objPublictidade != null)
                    {
                        objPeticao.IdentificadorPublicidade = objPublictidade.Identificador;

                        if (objPublictidade.Identificador == "1")
                        {
                            objPeticao.DescricaoIndicacao = txtAmigo.Text;
                        }
                        else if (objPublictidade.Identificador == "2")
                        {
                            if (ddlConsultor.SelectedIndex > 0)
                            {
                                Comum.Clases.Pessoa objPesssoa = (Comum.Clases.Pessoa)(frmWeb.Util.RecuperarItemSelecionado(ddlConsultor, Pessoas, "Identificador"));

                                if (objPesssoa != null)
                                {
                                    objPeticao.IdentificadorConsultor = objPesssoa.Identificador;

                                }
                            }
                        }
                    }
                }


                if (ddlEstado.SelectedIndex > 0)
                {
                    objPeticao.objEstado = (Comum.Clases.Estado)(frmWeb.Util.RecuperarItemSelecionado(ddlEstado, Estados, "Identificador"));

                    if (ddlciade.SelectedIndex > 0)
                    {
                        objPeticao.objCidade = (Comum.Clases.Cidade)(frmWeb.Util.RecuperarItemSelecionado(ddlciade, Cidades, "Identificador"));
                        objPeticao.DescricaoBairro = txtBairro.Text;
                        objPeticao.Logradouro = txtRua.Text;
                        objPeticao.objEndereco = Endereco;

                        if (!string.IsNullOrEmpty(txtNumero.Text.Trim()))
                        {
                            objPeticao.Numero = Convert.ToInt32(txtNumero.Text);

                            if (objPeticao.objEndereco != null)
                            {
                                objPeticao.objEndereco.Cidades.First().Bairros.First().Enderecos.First().Numero = objPeticao.Numero;
                            }
                        }
                                              

                        if (!string.IsNullOrEmpty(txtCep.Text))
                        {
                            objPeticao.CEP = Convert.ToInt32(txtCep.Text);
                        }

                    }
                }

                objRespuesta = objAcao.InserirEmpresa(objPeticao);

                if (objRespuesta != null && objRespuesta.CodigoErro != Convert.ToInt32(Execao.Constantes.CodigoErro.SEM_ERRO))
                {
                    throw new Execao.ExecaoNegocio((Execao.Constantes.CodigoErro)(objRespuesta.CodigoErro), objRespuesta.DescricaoErro);
                }


                ScriptManager.RegisterClientScriptBlock(this.Page, this.Page.GetType(), "script_informacao_grabado_suceso", "alert('Cadastro Gravado Com Sucesso');", true);

                txtEmpresa.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtUsuario.Text = string.Empty;

                Session["Identificador"] = "OK";

                Response.Redirect("~/Download.aspx");

            }
            catch (Execao.ExecaoNegocio ex)
            {
                lblError.Text = ex.Descricao;
                DivError.Visible = true;
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
                DivError.Visible = true;
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlEstado.SelectedIndex > 0)
                {
                    ddlciade.Enabled = true;
                    object objSelecionado = frmWeb.Util.RecuperarItemSelecionado(ddlEstado, Estados, "Identificador");
                    Comum.Clases.Estado objEstado = null;

                    if (objSelecionado != null)
                    {
                        objEstado = (Comum.Clases.Estado)(objSelecionado);

                        PreencherCidades(objEstado.Identificador);
                    }

                }
                else
                {
                    ddlciade.Enabled = false;
                    ddlciade.Items.Clear();
                    txtCep.Text = string.Empty;
                    txtBairro.Text = string.Empty;
                    txtRua.Text = string.Empty;
                    txtNumero.Text = string.Empty;
                    txtRua.Enabled = false;
                    txtBairro.Enabled = false;
                    txtNumero.Enabled = false;

                }

                //Limpar(TipoLimpar.ESTADO, false);

            }
            catch (Exception ex)
            {
                //Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = _Usuario });
            }
        }

        protected void ddlPublicidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (ddlPublicidade.SelectedIndex > 0)
                {
                    object objSelecionado = frmWeb.Util.RecuperarItemSelecionado(ddlPublicidade, objPublicidades, "Identificador");
                    Comum.Clases.Publicidade objPublicidade = null;

                    if (objSelecionado != null)
                    {
                        objPublicidade = (Comum.Clases.Publicidade)(objSelecionado);

                        if (objPublicidade.Codigo == Comum.Clases.Constantes.COD_PUBLICIDADE_AMIGO && objPublicidades != null)
                        {
                            DivAmigo.Visible = true;
                            DivConsultores.Visible = false;
                        }
                        else if (objPublicidade.Codigo == Comum.Clases.Constantes.COD_PUBLICIDADE_CONSULTOR && Pessoas != null)
                        {
                            DivAmigo.Visible = false;
                            DivConsultores.Visible = true;
                        }
                        else
                        {
                            DivAmigo.Visible = false;
                            DivConsultores.Visible = false;
                        }
                    }

                }
                else
                {
                    DivAmigo.Visible = false;
                }

                //Limpar(TipoLimpar.ESTADO, false);

            }
            catch (Exception ex)
            {
                //Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = _Usuario });
            }
        }

        protected void txtCep_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string cep = txtCep.Text.Replace(",", "");
                cep = cep.Replace("-", "");

                if (!string.IsNullOrEmpty(cep.Trim()))
                {

                    Estado = LogicaNegocio.Endereco.RegistrarEndereco(cep, string.Empty, string.Empty, string.Empty, string.Empty, "SITE", string.Empty, string.Empty);

                    if (Estado != null)
                    {
                        frmWeb.Util.SelecionarItemControle(ddlEstado, Estado.Identificador, "Value");

                        ddlciade.Enabled = true;
                        object objSelecionado = frmWeb.Util.RecuperarItemSelecionado(ddlEstado, Estados, "Identificador");
                        Comum.Clases.Estado objEstado = null;

                        if (objSelecionado != null)
                        {
                            objEstado = (Comum.Clases.Estado)(objSelecionado);

                            PreencherCidades(objEstado.Identificador);
                            frmWeb.Util.SelecionarItemControle(ddlciade, Estado.Cidades.First().Identificador, "Value");
                        }

                        txtBairro.Text = Estado.Cidades.First().Bairros.First().Nome;
                        txtRua.Text = Estado.Cidades.First().Bairros.First().Enderecos.First().DescricaoRua;
                        Endereco = Estado;
                        ddlEstado.Enabled = false;
                        ddlciade.Enabled = false;
                        txtRua.Enabled = false;
                        txtNumero.Enabled = true;
                        txtBairro.Enabled = false;
                    }
                    else
                    {
                        ddlEstado.Enabled = true;
                        ddlciade.Items.Clear();
                        Endereco = null;
                        txtRua.Enabled = true;
                        txtBairro.Enabled = true;
                        txtRua.Text = string.Empty;
                        txtBairro.Text = string.Empty;
                        ddlEstado.SelectedIndex = 0;
                    }

                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void ddlciade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlciade.SelectedIndex > 0)
                {
                    txtRua.Enabled = true;
                    txtBairro.Enabled = true;
                    txtNumero.Enabled = true;
                }
                else
                {
                    txtRua.Enabled = false;
                    txtBairro.Enabled = false;
                    txtNumero.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                //Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = _Usuario });
            }
        }

        #endregion

        #region"[METODOS]"

        private void CarregarTela()
        {

            if (!IsPostBack)
            {
                RecuperarPubliciades();
                CarregarConsultores();
                PreencherListBoxPublicidade();
                PreencherEstados();
                txtEmpresa.Focus();
            }
        }

        private void CarregarConsultores()
        {

            Comum.Clases.Empresa objEmpresa = LogicaNegocio.Empresa.RecuperarEmpresa(string.Empty, true, "SITE");

            if (objEmpresa != null)
            {

                ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao = new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
                {
                    TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO,
                    Usuario = "SITE",
                    IdentificadorEmpresa = objEmpresa.Identificador
                };
                ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas Resposta = LogicaNegocio.Pessoa.RecuperarPessoas(Peticao);
                Pessoas = Resposta.Pessoas;

                List<ListItem> Items = frmWeb.Util.ConverterItems(Pessoas, "Identificador", "DesNome");
                ddlConsultor = frmWeb.Util.PreencherDropDown(ddlConsultor, Items, true);
            }
        }

        private void PreencherEstados()
        {

            Estados = LogicaNegocio.Estado.RecuperarEstado("SITE", string.Empty);

            if (Estados != null && Estados.Count > 0)
            {

                List<ListItem> Items = frmWeb.Util.ConverterItems(Estados, "Identificador", "Nome");
                ddlEstado = frmWeb.Util.PreencherDropDown(ddlEstado, Items, true);
            }

            ddlciade.Items.Clear();
            ddlciade.Enabled = false;
            txtRua.Enabled = false;
            txtBairro.Enabled = false;
            txtNumero.Enabled = false;
        }

        private void PreencherCidades(string IdentificadorEstado)
        {

            Cidades = LogicaNegocio.Cidade.RecuperarCidades(null, string.Empty, "SITE", IdentificadorEstado, string.Empty);

            if (Cidades != null && Cidades.Count > 0)
            {

                List<ListItem> Items = frmWeb.Util.ConverterItems(Cidades, "Identificador", "Nome");
                ddlciade = frmWeb.Util.PreencherDropDown(ddlciade, Items, true);
            }

        }

        private void RecuperarPubliciades()
        {

            objPublicidades = LogicaNegocio.Publicidade.RecuperarPublicidades(string.Empty,"SITE");

        }

        private void PreencherListBoxPublicidade()
        {
            List<ListItem> Items = frmWeb.Util.ConverterItems(objPublicidades, "Identificador", "Descricao");
            ddlPublicidade = frmWeb.Util.PreencherDropDown(ddlPublicidade, Items, true);
        }

        #endregion



    }
}