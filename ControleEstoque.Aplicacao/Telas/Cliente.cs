using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class Cliente : TelaBase.BaseCE
    {

        #region"Variaveis"

        private Comum.Enumeradores.Enumeradores.TipoPessoaEnum _tipoPessoa;
        private List<Comum.Clases.Pessoa> objPessoas;
        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        public Cliente(Comum.Enumeradores.Enumeradores.TipoPessoaEnum TipoPessoa)
        {
            InitializeComponent();

            _tipoPessoa = TipoPessoa;

            switch (_tipoPessoa)
            {

                case Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO:

                    this.Text = "Funcionários";
                    break;
                case Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR:

                    this.Text = "Fornecedor";
                    break;
                case Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE:

                    this.Text = "Cliente";
                    break;

                case Comum.Enumeradores.Enumeradores.TipoPessoaEnum.PERMISSAO:

                    this.Text = "Permissões do Usuário";
                    break;
            }

        }

        #region "Eventos"

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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {

                if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO)
                {
                    GuardarFuncionario frmGuardarFuncionario = new GuardarFuncionario(string.Empty, false);
                   
                    frmGuardarFuncionario.ShowDialog();
                }
                else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE)
                {
                    GuardarCliente frmGuardarCliente = new GuardarCliente(string.Empty, false);
                                        
                    frmGuardarCliente.ShowDialog();
                }
                else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR)
                {

                    GuardarFornecedor frmGuardarFornecedor = new GuardarFornecedor(string.Empty, false);
                                        
                    frmGuardarFornecedor.ShowDialog();

                }

                RecuperarUsuarios(true,false);
               

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarUsuarios(true,true);
               

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                txtCnpj.Text = string.Empty;
                txtCodigo.Text = string.Empty;
                txtCpf.Text = string.Empty;
                txtDescricao.Text = string.Empty;
                txtUsuario.Text = string.Empty;
                dgvClientes.Rows.Clear();
                objPessoas = null;
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvClientes_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvClientes.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colTrocarSenha.Index || e.ColumnIndex == colPermissoes.Index ||
                            e.ColumnIndex == colVisualizar.Index)
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

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvClientes.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colTrocarSenha.Index ||
                            e.ColumnIndex == colPermissoes.Index || e.ColumnIndex == colVisualizar.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colVisualizar.Index)
                            {

                                if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO)
                                {
                                    GuardarFuncionario frmGuardarFuncionario = new GuardarFuncionario(dgvClientes.Rows[e.RowIndex].Cells[colIdFuncionario.Index].Value as string,
                                                                                                      (e.ColumnIndex == colVisualizar.Index));
                                                                        
                                    frmGuardarFuncionario.ShowDialog();
                                }
                                else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE)
                                {
                                    GuardarCliente frmGuardarCliente = new GuardarCliente(dgvClientes.Rows[e.RowIndex].Cells[colIdFuncionario.Index].Value as string,
                                                                                            (e.ColumnIndex == colVisualizar.Index));
                                                                        
                                    frmGuardarCliente.ShowDialog();
                                }
                                else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR)
                                {
                                    GuardarFornecedor frmGuardarFornecedor = new GuardarFornecedor(dgvClientes.Rows[e.RowIndex].Cells[colIdFuncionario.Index].Value as string,
                                                                                                    (e.ColumnIndex == colVisualizar.Index));
                                                                        
                                    frmGuardarFornecedor.ShowDialog();
                                }

                                RecuperarUsuarios(true,false);

                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {
                                Comum.Clases.Pessoa objPessoa = (from Comum.Clases.Pessoa objP in objPessoas where objP.Identificador == dgvClientes.Rows[e.RowIndex].Cells[colIdFuncionario.Index].Value as string select objP).FirstOrDefault();

                                if (objPessoas != null)
                                {
                                    if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO && !objPessoa.FuncionarioAtivo)
                                    {
                                        Aplicacao.Classes.Util.ExibirMensagemErro("Funcionario já está desativado.");
                                        return;
                                    }
                                    else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR && !objPessoa.FornecedorAtivo)
                                    {
                                        Aplicacao.Classes.Util.ExibirMensagemErro("Fornecedor já está desativado.");
                                        return;
                                    }

                                    ContratoServico.Pessoa.DesativarPessoa.PeticaoDesativarPessoa Peticao = new ContratoServico.Pessoa.DesativarPessoa.PeticaoDesativarPessoa()
                                    {
                                        Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                                        Identificador = dgvClientes.Rows[e.RowIndex].Cells[colIdFuncionario.Index].Value as string,
                                        TipoPessoa = _tipoPessoa
                                    };

                                    Agente.Agente.InvocarServico<ContratoServico.Pessoa.DesativarPessoa.RespostaDesativarPessoa, ContratoServico.Pessoa.DesativarPessoa.PeticaoDesativarPessoa>(Peticao,
                                          SDK.Operacoes.operacao.DesativarPessoa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);
                                                                       
                                    
                                }

                            }
                            else if (e.ColumnIndex == colTrocarSenha.Index)
                            {

                                AlterarSenha frmAlterarSenha = new AlterarSenha(dgvClientes.Rows[e.RowIndex].Cells[colIdFuncionario.Index].Value as string, true);

                                frmAlterarSenha.ShowDialog();

                            }
                            else if (e.ColumnIndex == colPermissoes.Index)
                            {

                                Permissoes frmPermissoes = new Permissoes(false, string.Empty, dgvClientes.Rows[e.RowIndex].Cells[colIdFuncionario.Index].Value as string);
                                frmPermissoes.ShowDialog();

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


        #endregion

        #region"Metodos"

        private void ConfigurarVisualizacao()
        {

            if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO)
            {
                txtCnpj.Visible = false;
                txtCpf.Visible = false;
                lblCnpj.Visible = false;
                lblCpf.Visible = false;
                colCnpj.Visible = false;
                colCpf.Visible = false;
                colSituacao.Visible = false;
                colPermissoes.Visible = false;

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
                {
                    colVisualizar.Visible = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
                {
                    colExcluir.Visible = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FUNCIONARIO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
                {
                    colEditar.Visible = false;
                    colTrocarSenha.Visible = false;
                }
            }
            else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE)
            {
                lblUsuario.Visible = false;
                txtUsuario.Visible = false;
                colUsuario.Visible = false;
                colExcluir.Visible = false;
                colTrocarSenha.Visible = false;
                colPermissoes.Visible = false;

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
                {
                    colVisualizar.Visible = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
                {
                    colExcluir.Visible = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CLIENTE, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
                {
                    colEditar.Visible = false;
                }
            }
            else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR)
            {
                lblUsuario.Visible = false;
                txtUsuario.Visible = false;
                colSituacao.Visible = false;
                colUsuario.Visible = false;
                colTrocarSenha.Visible = false;
                colPermissoes.Visible = false;

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                {
                    this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
                {
                    colVisualizar.Visible = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
                {
                    colExcluir.Visible = false;
                }

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_FORNECEDOR, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
                {
                    colEditar.Visible = false;
                }

            }
            else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.PERMISSAO)
            {
                colSituacao.Visible = false;
                colTrocarSenha.Visible = false;
                colEditar.Visible = false;
                colExcluir.Visible = false;
                colVisualizar.Visible = false;
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
                txtCnpj.Visible = false;
                txtCpf.Visible = false;
                lblCnpj.Visible = false;
                lblCpf.Visible = false;
                colCnpj.Visible = false;
                colCpf.Visible = false;

                if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PERMISSAOUSUARIO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR) &&
                    !Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PERMISSAOUSUARIO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
                {
                    colPermissoes.Visible = false;
                }
            }

        }

        private void RecuperarUsuarios(Boolean PreencherObjeto, Boolean ExibirMensagem)
        {

            int CodPessoa = 0;
            string DesPessoa = txtDescricao.Text;
            string Usuario = txtUsuario.Text;
            string cpf = txtCpf.Text.Replace(",", "");
            cpf = cpf.Replace("-", "");
            string cnpj = txtCnpj.Text.Replace(",", "");
            cnpj = cnpj.Replace("/", "");
            cnpj = cnpj.Replace("-", "");
            cnpj = cnpj.Trim();
            cpf = cpf.Trim();


            if (!string.IsNullOrEmpty(cpf))
            {
                cpf = txtCpf.Text;
            }

            if (!string.IsNullOrEmpty(cnpj))
            {
                cnpj = txtCnpj.Text;
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                CodPessoa = Convert.ToInt32(txtCodigo.Text);
            }



            ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao = new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
            {
                Codigo = CodPessoa,
                Descricao = DesPessoa,
                Cpf = cpf,
                Cnpj = cnpj,
                Login = Usuario,
                TipoPessoa = (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.PERMISSAO ? Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO : _tipoPessoa),
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas, ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas>(Peticao,
                  SDK.Operacoes.operacao.RecuperarPessoas, new Comum.ParametrosTela.Generica() { PreencherObjeto = PreencherObjeto,
                                                                                                 ExibirMensagemNenhumRegistro = ExibirMensagem}, null, true);

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

            if (operacao == SDK.Operacoes.operacao.RecuperarPessoas)
            {
                objPessoas = ((ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas)objSaida).Pessoas;
                if (Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if(operacao == SDK.Operacoes.operacao.DesativarPessoa)
            {
                base.objNotificacao.ExibirMensagem("Registro desativado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarUsuarios(true, false);
            }
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvClientes.Rows.Clear();

            if (objPessoas != null && objPessoas.Count > 0)
            {


                foreach (Comum.Clases.Pessoa p in objPessoas)
                {

                    dgvClientes.Rows.Add();
                    dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colCodigo.Index].Value = p.Codigo;
                    dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colDescricao.Index].Value = p.DesNome;
                    dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colCpf.Index].Value = p.cpf;
                    dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colIdFuncionario.Index].Value = p.Identificador;
                    dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colCnpj.Index].Value = p.cnpj;
                    dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colUsuario.Index].Value = p.Usuario;

                    if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO)
                    {
                        dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colExcluir.Index].Value = (p.FuncionarioAtivo ? Properties.Resources.x : Properties.Resources.x_gray);
                    }
                    else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR)
                    {
                        dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colExcluir.Index].Value = (p.FornecedorAtivo ? Properties.Resources.x : Properties.Resources.x_gray);
                    }

                    dgvClientes.Rows[dgvClientes.Rows.Count - 1].Cells[colSituacao.Index].Value = (p.SituacaoPessoa != null ? p.SituacaoPessoa.Descricao : string.Empty);

                }

                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);
            }
        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F4)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F4, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            ConfigurarVisualizacao();
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpClientes);
            tlpClientes.Dock = DockStyle.Fill;
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO)
            {
                GuardarFuncionario frmGuardarFuncionario = new GuardarFuncionario(Identificador.Value,
                                                                                  false);

                frmGuardarFuncionario.ShowDialog();
            }
            else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE)
            {
                GuardarCliente frmGuardarCliente = new GuardarCliente(Identificador.Value,
                                                                        false);

                frmGuardarCliente.ShowDialog();
            }
            else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR)
            {
                GuardarFornecedor frmGuardarFornecedor = new GuardarFornecedor(Identificador.Value,
                                                                               false);

                frmGuardarFornecedor.ShowDialog();
            }

            RecuperarUsuarios(true, false);

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            Comum.Clases.Pessoa objPessoa = (from Comum.Clases.Pessoa objP in objPessoas where objP.Identificador == Identificador.Value select objP).FirstOrDefault();

            if (objPessoas != null)
            {
                if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO && !objPessoa.FuncionarioAtivo)
                {
                    Aplicacao.Classes.Util.ExibirMensagemErro("Funcionario já está desativado.");
                    return;
                }
                else if (_tipoPessoa == Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR && !objPessoa.FornecedorAtivo)
                {
                    Aplicacao.Classes.Util.ExibirMensagemErro("Fornecedor já está desativado.");
                    return;
                }

                ContratoServico.Pessoa.DesativarPessoa.PeticaoDesativarPessoa Peticao = new ContratoServico.Pessoa.DesativarPessoa.PeticaoDesativarPessoa()
                {
                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                    Identificador = Identificador.Value,
                    TipoPessoa = _tipoPessoa
                };

                Agente.Agente.InvocarServico<ContratoServico.Pessoa.DesativarPessoa.RespostaDesativarPessoa, ContratoServico.Pessoa.DesativarPessoa.PeticaoDesativarPessoa>(Peticao,
                      SDK.Operacoes.operacao.DesativarPessoa, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);


            }

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion
    }
}
