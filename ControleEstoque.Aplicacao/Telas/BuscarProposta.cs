using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscarProposta : TelaBase.BaseCE
    {
        public BuscarProposta()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.Proposta> Propostas = null;
        private List<Comum.Clases.Pessoa> Funcionarios = null;
        private List<Comum.Clases.Pessoa> Clientes = null;
        #endregion

        #region"Metodos"

        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        private void CarregarTela()
        {

            RecuperarClientes();
            RecuperarFuncionarios();
            ConfigurarVisualizacao();
        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarPessoas)
            {
                if (Parametros != null && Parametros.DiferenciadorChamada == "CLIENTE")
                {
                    Clientes = ((ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas)objSaida).Pessoas;

                    if (Clientes == null || Clientes.Count == 0)
                    {
                        cmbCliente.Enabled = false;
                    }
                    else
                    {
                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Clientes, "Identificador", "DesNome");
                        cmbCliente = frmWindows.Util.PreencherCombobox(cmbCliente, Items);
                    }

                }
                else
                {
                    Funcionarios = ((ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas)objSaida).Pessoas;

                    if (Funcionarios == null || Funcionarios.Count == 0)
                    {
                        cmbConsultor.Enabled = false;
                    }
                    else
                    {

                        List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(Funcionarios, "Identificador", "DesNome");
                        cmbConsultor = frmWindows.Util.PreencherCombobox(cmbConsultor, Items);
                    }
                }


            }
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }
               

        private void RecuperarFuncionarios()
        {
            ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao = new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
            {
                TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO,
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas, ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas>(Peticao,
                  SDK.Operacoes.operacao.RecuperarPessoas, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, DiferenciadorChamada = "FUNCIONARIO" }, null, true);            

        }

        private void RecuperarClientes()
        {

            ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas Peticao = new ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas()
            {
                TipoPessoa = Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE,
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Pessoa.RecuperarPessoas.RespostaRecuperarPessoas, ContratoServico.Pessoa.RecuperarPessoas.PeticaoRecuperarPessoas>(Peticao,
                  SDK.Operacoes.operacao.RecuperarPessoas, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, DiferenciadorChamada = "CLIENTE" }, null, true);
          
        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROPOSTA, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROPOSTA, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROPOSTA, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_PROPOSTA, Comum.Enumeradores.Enumeradores.TipoAcao.CONSULTAR))
            {
                colConsultar.Visible = false;
            }

        }

        private void RecuperarPropostas()
        {
            Comum.Clases.Pessoa objCliente = (Comum.Clases.Pessoa)(frmWindows.Util.RecuperarItemSelecionado(cmbCliente, Clientes, "Identificador"));
            Comum.Clases.Pessoa objFuncionario = (Comum.Clases.Pessoa)(frmWindows.Util.RecuperarItemSelecionado(cmbConsultor, Funcionarios, "Identificador"));
            string IdentificadorCliente = string.Empty;
            string IdentificadorFuncionario = string.Empty;
            Nullable<Int32> Codigo = null;

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                Codigo = Convert.ToInt32(txtCodigo.Text);
            }

            if (objCliente != null)
            {
                IdentificadorCliente = objCliente.Identificador;
            }

            if (objFuncionario != null)
            {
                IdentificadorFuncionario = objFuncionario.Identificador;
            }

            Propostas = LogicaNegocio.Proposta.RecuperarPropostas(txtNome.Text, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                  IdentificadorCliente, IdentificadorFuncionario, true, Codigo, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvMarcas.Rows.Clear();

            if (Propostas != null && Propostas.Count > 0)
            {


                foreach (Comum.Clases.Proposta c in Propostas)
                {

                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCodigo.Index].Value = c.Codigo;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDataInstalacao.Index].Value = c.DataHoraInstalacao;

                    if (c.Cliente != null)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCliente.Index].Value = c.Cliente.DesNome;
                    }

                    if (c.AtendeNecessidade)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAtendeNecessidade.Index].Value = Properties.Resources.positive;
                    }
                    else
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colAtendeNecessidade.Index].Value = Properties.Resources.negative;
                    }

                    if (c.Ativa)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x;
                    }
                    else
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = Properties.Resources.x_gray;
                    }

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
            GuardarPropostas frmCores = new GuardarPropostas(false,Identificador.Value, null, false, null);

            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarPropostas();
                ExecutarPreencherGrid(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            LogicaNegocio.Proposta.DesativarProposta(Identificador.Value, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
            base.objNotificacao.ExibirMensagem("Proposta desativada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
            RecuperarPropostas();
            ExecutarPreencherGrid(false);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarPropostas();
                ExecutarPreencherGrid(true);

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

                Propostas = null;
                cmbCliente.SelectedIndex = 0;
                cmbConsultor.SelectedIndex = 0;
                dgvMarcas.Rows.Clear();
                txtNome.Text = string.Empty;

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
                GuardarPropostas frmProposta = new GuardarPropostas(false, string.Empty, null, false, null);

                if (frmProposta.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarPropostas();
                    ExecutarPreencherGrid(false);
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colConsultar.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colConsultar.Index)
                            {

                                GuardarPropostas frmCores = new GuardarPropostas((e.ColumnIndex == colConsultar.Index),
                                    dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, null, false, null);

                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarPropostas();
                                    ExecutarPreencherGrid(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {


                                LogicaNegocio.Proposta.DesativarProposta(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);
                                base.objNotificacao.ExibirMensagem("Proposta desativada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                                RecuperarPropostas();
                                ExecutarPreencherGrid(false);
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

        private void dgvMarcas_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {

            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colConsultar.Index)
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

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
