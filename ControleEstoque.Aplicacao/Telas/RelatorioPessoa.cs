using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class RelatorioPessoa : TelaBase.BaseCE
    {
        public RelatorioPessoa()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnBuscar = "btnAceitar";
        private const string btnLimpar = "btnAceitar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.Filiais> objFiliais;
        private List<Comum.Clases.TipoPessoa> objTiposPessoa;

        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F3)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            this.pnlBase.Controls.Add(gpbFiltro);
            CarregarTela();
            base.Inicializar();
        }

        private void PreencherComboFiliais()
        {

            objFiliais = LogicaNegocio.Filial.RecuperarFiliaisSimples(ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                                                 ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(objFiliais, "Identificador", "Nome");
            cmbFilial = frmWindows.Util.PreencherCombobox(cmbFilial, Items);
        }

        private void CarregarTela()
        {

            PreencherComboFiliais();
        }

        private void ExecutarRelatorio()
        {
            List<Comum.Clases.Relatorios.Ticket> tickets = new List<Comum.Clases.Relatorios.Ticket>();

          /*  for (int i = 0; i < 5; i++)
            {
                int cont = i + 1;
                Comum.Clases.Relatorios.Ticket ticket = new Comum.Clases.Relatorios.Ticket();
                ticket.CodigoProduto = cont;
                ticket.DescricaoProduto = "DES_" + cont.ToString();
                ticket.Quantidade = cont;
                ticket.ValorUnitario = cont + 5;
                ticket.SubTotal = ticket.Quantidade * ticket.ValorUnitario;

                tickets.Add(ticket);
            }

            Aplicacao.Classes.Imprimir.ImprimirTicket(tickets,
                                                      "0001",
                                                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Cnpj,
                                                      DateTime.Now,
                                                      "Debito",
                                                      "Marcel",
                                                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome,
                                                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().TelefoneFixo,
                                                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Endereco.Nome);

           */
            string IdentificadorFilial = string.Empty;

            if (cmbFilial.SelectedItem != null)
            {
                Comum.Clases.Filiais objFilial = null;

                objFilial = (Comum.Clases.Filiais)(frmWindows.Util.RecuperarItemSelecionado(cmbFilial, objFiliais, "Identificador"));

                if (objFilial != null)
                {
                    IdentificadorFilial = objFilial.Identificador;
                }
            }

            string cpf = string.Empty;
            string cnpj = string.Empty;
            string IdentificadorTipoPessoa = string.Empty;

            if (!string.IsNullOrEmpty(txtCPF.Text.Replace(",", "").Replace("-", "").Trim()))
            {
                cpf = txtCPF.Text;
            }

            if (!string.IsNullOrEmpty(txtCnpj.Text.Replace(",", "").Replace("/", "").Replace("-", "").Trim()))
            {
                cnpj = txtCnpj.Text;
            }

            if (rbtCliente.Checked)
            {
                IdentificadorTipoPessoa = Convert.ToString(Comum.Enumeradores.Enumeradores.TipoPessoaEnum.CLIENTE.GetHashCode());
            }
            else if (rbtFornecedor.Checked)
            {
                IdentificadorTipoPessoa = Convert.ToString(Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FORNECEDOR.GetHashCode());
            }
            else
            {
                IdentificadorTipoPessoa = Convert.ToString(Comum.Enumeradores.Enumeradores.TipoPessoaEnum.FUNCIONARIO.GetHashCode());
            }

            List<Comum.Clases.Relatorios.RelatorioPessoas> objRelatorioPessoas = LogicaNegocio.Relatorios.RecuperarPessoas(IdentificadorFilial, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                                                                           txtNome.Text.Trim(), cpf, cnpj, IdentificadorTipoPessoa, ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);


            if (objRelatorioPessoas != null && objRelatorioPessoas.Count > 0)
            {

                RelatorioVisualizar frmRelatorio = new RelatorioVisualizar();

                DataSet.dtRelatorioPessoas objDataSet = new DataSet.dtRelatorioPessoas();
                objDataSet.PopularDataSet(objRelatorioPessoas, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada);

                frmRelatorio.FonteDados = objDataSet;
                if (rbtCliente.Checked)
                {
                    frmRelatorio.Relatorio = "RelatorioCliente.rpt";
                }
                else if (rbtFornecedor.Checked)
                {
                    frmRelatorio.Relatorio = "RelatorioFornecedor.rpt";
                }
                else
                {
                    frmRelatorio.Relatorio = "RelatorioFuncionario.rpt";
                }

                frmRelatorio.ShowDialog();
            }
            else
            {
                Aplicacao.Classes.Util.ExibirMensagemErro("Não existem dados para ser exibidos.");
            }


        }

        #endregion


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                ExecutarRelatorio();
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

                cmbFilial.SelectedItem = null;
                txtCnpj.Text = string.Empty;
                txtCPF.Text = string.Empty;
                txtNome.Text = string.Empty;
                rbtFuncionario.Checked = true;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void rbtFuncionario_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (rbtFuncionario.Checked)
                {
                    cmbFilial.Enabled = true;
                }
                else
                {
                    cmbFilial.SelectedItem = null;
                    cmbFilial.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void rbtFornecedor_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (rbtFuncionario.Checked)
                {
                    cmbFilial.Enabled = true;
                }
                else
                {
                    cmbFilial.SelectedItem = null;
                    cmbFilial.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void rbtCliente_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (rbtFuncionario.Checked)
                {
                    cmbFilial.Enabled = true;
                }
                else
                {
                    cmbFilial.SelectedItem = null;
                    cmbFilial.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

    }
}
