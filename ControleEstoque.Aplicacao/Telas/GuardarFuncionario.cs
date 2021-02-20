using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmgSistemas.Framework.Componentes;
using Microsoft.VisualBasic;
using frmUtil = AmgSistemas.Framework.Utilitarios;
using frmCripto = AmgSistemas.Framework.Criptografia;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarFuncionario : TelaBase.BaseCE
    {

        #region"Variaveis"

        private string _IdentificadorPessoa;
        private CurrencyTextBox CurrencyTextBox;
        private List<Comum.Clases.HorarioTrabalho> objDiasSemana;
        private List<Comum.Clases.Filiais> Filiais;
        private Boolean _Visualizar;
        private List<Comum.Clases.TipoEmpregado> objTipoEmpregado;

        #endregion

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        public GuardarFuncionario(string IdentificadorPessoa, Boolean Visualizar)
        {
            InitializeComponent();
            base.Inicializar();

            this.Height = 782;

            _IdentificadorPessoa = IdentificadorPessoa;
            _Visualizar = Visualizar;

        }

        #region "Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F2)", btnAceitar, Properties.Resources.save, new EventHandler(btnGravar_Click), Keys.F2, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbFuncionario);
            CarregarTela();
            base.Inicializar();
        }

        private void RecuperarDatos()
        {
            ContratoServico.Telas.GuardarFuncionario.Carregar.PeticaoGuardarFuncionarioCarregar Peticao = new ContratoServico.Telas.GuardarFuncionario.Carregar.PeticaoGuardarFuncionarioCarregar();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.IdentificadorFuncionario = _IdentificadorPessoa;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Telas.GuardarFuncionario.Carregar.RespostaGuardarFuncionarioCarregar, ContratoServico.Telas.GuardarFuncionario.Carregar.PeticaoGuardarFuncionarioCarregar>(Peticao, SDK.Operacoes.operacao.CarregarGuardarFuncionario,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = false,
                    PreencherObjeto = true
                }, null, true);
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
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.CarregarGuardarFuncionario)
            {
                ContratoServico.Telas.GuardarFuncionario.Carregar.RespostaGuardarFuncionarioCarregar objSaidaConvertido = (ContratoServico.Telas.GuardarFuncionario.Carregar.RespostaGuardarFuncionarioCarregar)objSaida;
                objTipoEmpregado = objSaidaConvertido.TiposEmpregado;
                Filiais = objSaidaConvertido.Filiais;

                cmbTipoEmpregado.Items.Clear();

                List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(objTipoEmpregado, "Identificador", "Descricao");
                cmbTipoEmpregado = frmWindows.Util.PreencherCombobox(cmbTipoEmpregado, Items);

                PreencherFiliais();
                CarregarFuncionario(objSaidaConvertido.Funcionario);

                ucEndereco.InformarParametrosObrigatorios(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes);

                if (ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.EmpresaMestre && !ControleEstoque.Parametros.Parametros.InformacaoUsuario.Consultor)
                {
                    chkGerente.Visible = true;
                }

                if (string.IsNullOrEmpty(_IdentificadorPessoa))
                {

                    chkAtivo.Enabled = false;
                    chkAtivo.Checked = true;

                }
                else
                {
                    txtUsuario.Enabled = false;
                    txtSenha.Visible = false;
                    txtConfirmarSenha.Visible = false;
                    lblSenha.Visible = false;
                    lblConfirmarSenha.Visible = false;
                }

                BloquearTela();

            }
            else if (operacao == SDK.Operacoes.operacao.AtualizarPessoa)
            {
                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);


                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else if (operacao == SDK.Operacoes.operacao.InserirPessoa)
            {

                ContratoServico .Pessoa.InserirPessoa.RespostaInserirPessoa objSaidaConvertido = (ContratoServico.Pessoa.InserirPessoa.RespostaInserirPessoa)objSaida;
                                
                base.objNotificacao.ExibirMensagem("Dados atualizados com sucesso", Controles.UcNotificacao.TipoImagem.SUCESSO);

                if (Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PERMISSAOUSUARIO, null))
                {

                    if (MessageBox.Show("Deseja cadastrar as permissões do usuário?", "IGERENCE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {

                        Permissoes frmPermissoes = new Permissoes(false, string.Empty, objSaidaConvertido.Pessoa.Identificador);
                        frmPermissoes.ShowDialog();
                    }
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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
                txtTelefoneCelular.Enabled = false;
                txtTelefoneFixo.Enabled = false;
                txtObservacao.Enabled = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnAceitar, true);
                dtpNascimento.Enabled = false;
                dtpAdmissao.Enabled = false;
                txtHabilitacao.Enabled = false;
                txtSalario.Enabled = false;
                txtComissao.Enabled = false;
                txtEmpresaAnterior.Enabled = false;
                txtTelEmpresaAnterior.Enabled = false;
                lstFiliais.Enabled = false;
                txtObservacao.Enabled = false;
                txtUsuario.Enabled = false;
                txtHoraAlmFim.Enabled = false;
                txtHoraAlmInicio.Enabled = false;
                colEditar.Visible = false;
                cmbTipoEmpregado.Enabled = false;
            }
        }

        private void PreencherFiliais()
        {

            lstFiliais.Items.Clear();

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Filiais, "Identificador", "Nome");
            lstFiliais = frmWindows.Util.PreencherListBox(lstFiliais, Items);

        }

        private void CarregarDiasSemana()
        {

            objDiasSemana = new List<Comum.Clases.HorarioTrabalho>();

            objDiasSemana.Add(new Comum.Clases.HorarioTrabalho
            {
                CodDiaSemana = Comum.Enumeradores.Enumeradores.CodigoDiaSemana.DOMINGO,
                NomeDiaSemana = "Domingo"
            });

            objDiasSemana.Add(new Comum.Clases.HorarioTrabalho
            {
                CodDiaSemana = Comum.Enumeradores.Enumeradores.CodigoDiaSemana.SEGUNDA,
                NomeDiaSemana = "Segunda - Feira"
            });

            objDiasSemana.Add(new Comum.Clases.HorarioTrabalho
            {
                CodDiaSemana = Comum.Enumeradores.Enumeradores.CodigoDiaSemana.TERCA,
                NomeDiaSemana = "Terça - Feira"
            });

            objDiasSemana.Add(new Comum.Clases.HorarioTrabalho
            {
                CodDiaSemana = Comum.Enumeradores.Enumeradores.CodigoDiaSemana.QUARTA,
                NomeDiaSemana = "Quarta - Feira"
            });

            objDiasSemana.Add(new Comum.Clases.HorarioTrabalho
            {
                CodDiaSemana = Comum.Enumeradores.Enumeradores.CodigoDiaSemana.QUINTA,
                NomeDiaSemana = "Quinta - Feira"
            });

            objDiasSemana.Add(new Comum.Clases.HorarioTrabalho
            {
                CodDiaSemana = Comum.Enumeradores.Enumeradores.CodigoDiaSemana.SEXTA,
                NomeDiaSemana = "Sexta - Feira"
            });

            objDiasSemana.Add(new Comum.Clases.HorarioTrabalho
            {
                CodDiaSemana = Comum.Enumeradores.Enumeradores.CodigoDiaSemana.SABADO,
                NomeDiaSemana = "Sabado"
            });

            foreach (Comum.Clases.HorarioTrabalho objDia in objDiasSemana)
            {

                dgvHoraTrabalho.Rows.Add();
                dgvHoraTrabalho.Rows[dgvHoraTrabalho.Rows.Count - 1].Cells[colDia.Index].Value = objDia.NomeDiaSemana;
                dgvHoraTrabalho.Rows[dgvHoraTrabalho.Rows.Count - 1].Cells[colCodDia.Index].Value = objDia.CodDiaSemana;

            }
        }

        private void ExecutarGravar()
        {
            Comum.Clases.Pessoa objPessoa = new Comum.Clases.Pessoa();
            objPessoa.TiposPessoa = new List<Comum.Clases.TipoPessoa>();
            objPessoa.TiposPessoa.Add(new Comum.Clases.TipoPessoa { Codigo = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO, Identificador = "1" });

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

            if (dtpNascimento.Checked)
            {
                objPessoa.DataNascimento = dtpNascimento.Value;
            }
            else
            {
                objPessoa.DataNascimento = null;
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

            objPessoa.Consultor = !chkGerente.Checked;
            objPessoa.RG = txtRG.Text.Trim();
            objPessoa.DesCarteiraHabilitacao = txtHabilitacao.Text.Trim();

            if (!string.IsNullOrEmpty(txtSalario.Text.Trim()))
            {
                objPessoa.NumSalario = Convert.ToDecimal(txtSalario.Text.Trim());
            }
            else
            {
                objPessoa.NumSalario = null;
            }

            if (!string.IsNullOrEmpty(txtComissao.Text.Trim()))
            {
                objPessoa.NumComissao = Convert.ToDecimal(txtComissao.Text.Trim());
            }
            else
            {
                objPessoa.NumComissao = null;
            }

            objPessoa.FuncionarioAtivo = (string.IsNullOrEmpty(_IdentificadorPessoa) ? true : chkAtivo.Checked);
            objPessoa.FornecedorAtivo = false;

            if (dtpAdmissao.Checked)
            {
                objPessoa.DataAdmissao = dtpAdmissao.Value;
            }

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

            telefone = txtTelEmpresaAnterior.Text.Replace("(", "");
            telefone = telefone.Replace(")", "");
            telefone = telefone.Replace("-", "");

            if (!string.IsNullOrEmpty(telefone.Trim()))
            {
                objPessoa.DesTelefoneEmpresaAnterior = txtTelEmpresaAnterior.Text;
            }
            else
            {
                objPessoa.DesTelefoneEmpresaAnterior = string.Empty;
            }

            objPessoa.DesEmpresaAnterior = txtEmpresaAnterior.Text.Trim();
            objPessoa.Observacao = txtObservacao.Text.Trim();
            objPessoa.DesSenha = txtSenha.Text;
            objPessoa.DesConfirmarSenha = txtConfirmarSenha.Text;
            objPessoa.Usuario = txtUsuario.Text.Trim();
            objPessoa.DesSenhaTouch = txtSenhaTouch.Text;

            string Horario = txtHoraAlmInicio.Text.Replace(":", "");

            if (!string.IsNullOrEmpty(Horario.Trim()))
            {
                objPessoa.DesHoraAlmocoInicio = txtHoraAlmInicio.Text;
            }
            else
            {
                objPessoa.DesHoraAlmocoInicio = string.Empty;
            }

            Horario = txtHoraAlmFim.Text.Replace(":", "");

            if (!string.IsNullOrEmpty(Horario.Trim()))
            {
                objPessoa.DesHoraAlmocoFim = txtHoraAlmFim.Text;
            }
            else
            {
                objPessoa.DesHoraAlmocoFim = string.Empty;
            }

            if (cmbTipoEmpregado.SelectedItem != null)
            {
                objPessoa.TipoEmpregado = (Comum.Clases.TipoEmpregado)(frmWindows.Util.RecuperarItemSelecionado(cmbTipoEmpregado, objTipoEmpregado, "Identificador"));
            }
            else
            {
                objPessoa.TipoEmpregado = null;
            }

            Comum.Clases.HorarioTrabalho HorarioTrabalho = null;

            foreach (DataGridViewRow dr in dgvHoraTrabalho.Rows)
            {

                HorarioTrabalho = (from Comum.Clases.HorarioTrabalho ht in objDiasSemana where ht.CodDiaSemana == (Comum.Enumeradores.Enumeradores.CodigoDiaSemana)(dr.Cells[colCodDia.Index].Value) select ht).FirstOrDefault();

                if (HorarioTrabalho != null)
                {

                    HorarioTrabalho.DesHoraInicio = dr.Cells[colHoraInicio.Index].Value as string;
                    HorarioTrabalho.DesHoraFim = dr.Cells[colHoraSaida.Index].Value as string;
                }

            }

            objPessoa.HorarioTrabalho = objDiasSemana;
            objPessoa.Empresa = new Comum.Clases.Empresa() { Identificador = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador };

            if (lstFiliais.SelectedItems != null && lstFiliais.SelectedItems.Count > 0)
            {

                Comum.Clases.Filiais objFilial = null;
                objPessoa.Filiais = new List<Comum.Clases.Filiais>();

                foreach (frmWindows.Item item in lstFiliais.SelectedItems)
                {

                    objFilial = (from Comum.Clases.Filiais objf in Filiais where objf.Identificador == item.Identificador select objf).First();

                    if (objFilial != null)
                    {
                        objPessoa.Filiais.Add(objFilial);
                    }
                }
            }
            else
            {
                objPessoa.Filiais = null;
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

        private void CarregarFuncionario(Comum.Clases.Pessoa objPessoa)
        {

            if (objPessoa != null)
            {


                txtCodigo.Text = Convert.ToString(objPessoa.Codigo);
                txtNome.Text = objPessoa.DesNome;
                ucEndereco.CarregarControle(objPessoa.EnderecoCompleto);
                dtpNascimento.Text = (objPessoa.DataNascimento != null ? Convert.ToString(objPessoa.DataNascimento) : string.Empty);
                txtCPF.Text = objPessoa.cpf;
                txtRG.Text = objPessoa.RG;
                chkGerente.Checked = !objPessoa.Consultor;
                txtHabilitacao.Text = objPessoa.DesCarteiraHabilitacao;
                txtSalario.Text = (objPessoa.NumSalario != null ? Convert.ToString(objPessoa.NumSalario) : null);
                txtComissao.Text = (objPessoa.NumComissao != null ? Convert.ToString(objPessoa.NumComissao) : null);
                chkAtivo.Checked = objPessoa.FuncionarioAtivo;
                dtpAdmissao.Text = (objPessoa.DataAdmissao != null ? Convert.ToString(objPessoa.DataAdmissao) : string.Empty);
                txtTelefoneFixo.Text = objPessoa.DesTelefoneFixo;
                txtTelefoneCelular.Text = objPessoa.DesTelefoneCelular;
                txtEmpresaAnterior.Text = objPessoa.DesEmpresaAnterior;
                txtTelEmpresaAnterior.Text = objPessoa.DesEmpresaAnterior;
                txtObservacao.Text = objPessoa.Observacao;
                txtUsuario.Text = objPessoa.Usuario;
                txtHoraAlmInicio.Text = objPessoa.DesHoraAlmocoInicio;
                txtHoraAlmFim.Text = objPessoa.DesHoraAlmocoFim;
                txtSenha.Text = objPessoa.DesSenha;

                if (objPessoa.TipoEmpregado != null)
                {
                    cmbTipoEmpregado = (ComboBox)(frmWindows.Util.SelecionarItemControle(cmbTipoEmpregado, objPessoa.TipoEmpregado.Identificador, "Identificador"));
                }

                if (objPessoa.Filiais != null && objPessoa.Filiais.Count > 0)
                {

                    Comum.Clases.Filiais objItem = new Comum.Clases.Filiais();
                    List<int> Indices = new List<int>();
                    int indice = 0;

                    foreach (frmWindows.Item objI in lstFiliais.Items)
                    {

                        objItem = (from Comum.Clases.Filiais objF in objPessoa.Filiais where objF.Identificador == objI.Identificador select objF).FirstOrDefault();

                        if (objItem != null)
                        {
                            Indices.Add(indice);
                        }

                        indice += 1;
                    }

                    foreach (int indece in Indices)
                    {
                        lstFiliais.SelectedIndices.Add(indece);
                    }
                }

                if (objPessoa.HorarioTrabalho != null && objPessoa.HorarioTrabalho.Count > 0)
                {

                    Comum.Clases.HorarioTrabalho objHorarioTrabalho = null;

                    foreach (DataGridViewRow dr in dgvHoraTrabalho.Rows)
                    {

                        objHorarioTrabalho = (from Comum.Clases.HorarioTrabalho ht in objPessoa.HorarioTrabalho where ht.CodDiaSemana == (Comum.Enumeradores.Enumeradores.CodigoDiaSemana)(dr.Cells[colCodDia.Index].Value) select ht).FirstOrDefault();

                        if (objHorarioTrabalho != null)
                        {
                            dr.Cells[colHoraInicio.Index].Value = objHorarioTrabalho.DesHoraInicio;
                            dr.Cells[colHoraSaida.Index].Value = objHorarioTrabalho.DesHoraFim;

                        }
                    }
                }

            }
        }

        private void CarregarTela()
        {

            RecuperarDatos();
            CarregarDiasSemana();


        }

        #endregion

        #region"Eventos"             

        private void txtSalario_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtSalario);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtComissao_Enter(object sender, EventArgs e)
        {
            try
            {
                if (CurrencyTextBox == null) CurrencyTextBox = new CurrencyTextBox();
                CurrencyTextBox.Inicializar(ref txtComissao);

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
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void txtCPF_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefoneFixo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelefoneCelular_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTelEmpresaAnterior_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHoraAlmInicio_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtHoraAlmFim_KeyPress(object sender, KeyPressEventArgs e)
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


        private void dgvHoraTrabalho_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvHoraTrabalho.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index)
                        {

                            HorarioTrabalho frmHorario = new HorarioTrabalho((Comum.Enumeradores.Enumeradores.CodigoDiaSemana)(dgvHoraTrabalho.Rows[e.RowIndex].Cells[colCodDia.Index].Value),
                                                                              dgvHoraTrabalho.Rows[e.RowIndex].Cells[colDia.Index].Value as String, dgvHoraTrabalho.Rows[e.RowIndex].Cells[colHoraInicio.Index].Value as String,
                                                                              dgvHoraTrabalho.Rows[e.RowIndex].Cells[colHoraSaida.Index].Value as String);

                            if (frmHorario.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            {

                                dgvHoraTrabalho.Rows[e.RowIndex].Cells[colHoraInicio.Index].Value = frmHorario.HoraInicio;
                                dgvHoraTrabalho.Rows[e.RowIndex].Cells[colHoraSaida.Index].Value = frmHorario.HoraFim;

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

        private void dgvHoraTrabalho_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvHoraTrabalho.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index)
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
