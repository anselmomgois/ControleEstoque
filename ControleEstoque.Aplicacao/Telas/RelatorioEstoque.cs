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
    public partial class RelatorioEstoque : TelaBase.BaseCE
    {
        public RelatorioEstoque()
        {
            InitializeComponent();
        }

        #region"Variaveis"

        private List<Comum.Clases.Filiais> objFiliais;
        private List<Comum.Clases.ProdutoServico> objProdutos;

        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnAceitar";
        private const string btnLimpar = "btnAceitar";
        #endregion
        #region "Metodos"

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
            PreencherComboFiliais();
            PreencherComboProdutos();
            base.Inicializar();
        }

        private void PreencherComboFiliais()
        {

            objFiliais = LogicaNegocio.Filial.RecuperarFiliaisSimples(ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                                                 ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(objFiliais, "Identificador", "Nome");
            cmbFilial = frmWindows.Util.PreencherCombobox(cmbFilial, Items);
        }

        private void PreencherComboProdutos()
        {

            objProdutos = LogicaNegocio.ProdutoServico.RecuperarProdutosServicos(string.Empty, null, string.Empty,
                                                                                 ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                                 ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                                                                                  Comum.Clases.Constantes.COD_TIPO_PRODUTO_SERVICO_PROD, string.Empty,false,false);

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(objProdutos, "Identificador", "Descricao");
            cmbProduto = frmWindows.Util.PreencherCombobox(cmbProduto, Items);
        }

        #endregion

        #region"Eventos"
             

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {

                cmbFilial.SelectedItem = null;
                cmbProduto.SelectedItem = null;
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

                string IdentificadorFilial = string.Empty;
                string IdentificadorProduto = string.Empty;

                if (cmbFilial.SelectedItem != null)
                {
                    Comum.Clases.Filiais objFilial = null;

                    objFilial = (Comum.Clases.Filiais)(frmWindows.Util.RecuperarItemSelecionado(cmbFilial, objFiliais, "Identificador"));

                    if (objFilial != null)
                    {
                        IdentificadorFilial = objFilial.Identificador;
                    }
                }

                if (cmbProduto.SelectedItem != null)
                {
                    Comum.Clases.ProdutoServico Produto = null;

                    Produto = (Comum.Clases.ProdutoServico)(frmWindows.Util.RecuperarItemSelecionado(cmbProduto, objProdutos, "Identificador"));

                    if (Produto != null)
                    {
                        IdentificadorProduto = Produto.Identificador;
                    }
                }

                List<Comum.Clases.Relatorios.RelatorioEstoque> objProdutosRelatorio = LogicaNegocio.Relatorios.RecuperarItensRelatorioEstoque(IdentificadorFilial, IdentificadorProduto, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                                                                                      ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login);

                if (objProdutosRelatorio != null && objProdutosRelatorio.Count > 0)
                {

                    RelatorioVisualizar frmRelatorio = new RelatorioVisualizar();

                    if (chkDetalharFilial.Checked)
                    {

                        DataSet.dtRelatorioSaldo objDataSet = new DataSet.dtRelatorioSaldo();
                        objDataSet.PopularDataSet(objProdutosRelatorio, ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada);
                                                
                        frmRelatorio.FonteDados = objDataSet;

                        if (rbtProduto.Checked)
                        {
                            frmRelatorio.Relatorio = "RelatorioEstoque.rpt";
                        }
                        else if (rbtFilial.Checked)
                        {
                            frmRelatorio.Relatorio = "RelatorioEstoquePorFilial.rpt";
                        }

                    }
                    else
                    {

                        DataSet.dtRelatorioSaldo objDataSet = new DataSet.dtRelatorioSaldo();
                        objDataSet.PopularDataSet(AgruparProdutos(objProdutosRelatorio), ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada);

                        frmRelatorio.FonteDados = objDataSet;
                        frmRelatorio.Relatorio = "RelatorioEstoqueEmpresa.rpt";
                    }

                    frmRelatorio.ShowDialog();
                }
                else
                {
                    Aplicacao.Classes.Util.ExibirMensagemErro("Não existem dados para ser exibidos.");
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private List<Comum.Clases.Relatorios.RelatorioEstoque> AgruparProdutos(List<Comum.Clases.Relatorios.RelatorioEstoque> objProdutos)
        {

            List<Comum.Clases.Relatorios.RelatorioEstoque> objProdutosRetorno = null;

            if (objProdutos != null && objProdutos.Count > 0)
            { 
            
                objProdutosRetorno = new List<Comum.Clases.Relatorios.RelatorioEstoque>();

                Comum.Clases.Relatorios.RelatorioEstoque objProdutoCorrente = null;

                foreach (Comum.Clases.Relatorios.RelatorioEstoque ps in objProdutos)
                {

                    objProdutoCorrente = (from Comum.Clases.Relatorios.RelatorioEstoque psr in objProdutosRetorno where psr.Codigo == ps.Codigo select psr).FirstOrDefault();

                    if (objProdutoCorrente != null)
                    {
                        objProdutoCorrente.Estoque += ps.Estoque;
                    }
                    else
                    {
                        objProdutosRetorno.Add(ps);
                    }
                }
            }

            return objProdutosRetorno;
        }
        private void chkDetalharFilial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                if (chkDetalharFilial.Checked)
                {
                    rbtFilial.Enabled = true;
                    rbtProduto.Enabled = true;
                    rbtFilial.Checked = true;
                }
                else
                {
                    rbtFilial.Enabled = false;
                    rbtFilial.Checked = false;
                    rbtProduto.Enabled = false;
                    rbtProduto.Checked = false;
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
