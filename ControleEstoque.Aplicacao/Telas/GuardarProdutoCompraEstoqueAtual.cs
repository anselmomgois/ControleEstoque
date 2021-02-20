using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class GuardarProdutoCompraEstoqueAtual : TelaBase.BaseCE
    {
        public GuardarProdutoCompraEstoqueAtual(string IdentificadorProdutoServico)
        {
            InitializeComponent();

            _IdentificadorProdutoServico = IdentificadorProdutoServico;
        }

        #region"Constantes"
        private const string btnAceitar = "btnAceitar";
        #endregion

        #region"Variaveis'

        private List<Comum.Clases.ProdutoCompra> _Produtos = null;
        private string _IdentificadorProdutoServico = string.Empty;

        #endregion

        #region "Metodos"
        protected override void SetarCursor(Cursor objCursor)
        {
            base.SetarCursor(objCursor);
            Cursor = objCursor;
        }

        protected override void DesabilitarControles(List<string> NomeControles, bool Habilitado, SDK.Operacoes.operacao operacao)
        {
            base.DesabilitarControles(NomeControles, Habilitado,operacao);

            Classes.Util.DesabilitarControlesTela(this, Habilitado, NomeControles, ref ControlesDesabilitados);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarProdutoCompras)
            {
                _Produtos = ((ContratoServico.Compra.RecuperarProdutoCompras.RespostaRecuperarProdutoCompras)objSaida).Produtos;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.SetEstoqueAtual)
            {

                base.objNotificacao.ExibirMensagem("Dados gravados com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
            }


        }

        protected override void MontarMenu(Boolean GerarGrupo)
        {

            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Aceitar (F3)", btnAceitar, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);

            base.MontarMenu(GerarGrupo);
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            ConfigurarVisualizacao();
            base.Inicializar();
            this.pnlBase.Controls.Add(gpbClientes);
            RecuperarProdutosCompras(false);
        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GUARDARESTOQUEATUAL, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEstoqueAtual.Visible = false;
            }

        }

        private void RecuperarProdutosCompras(Boolean ExibirMensagemNenhumRegistro)
        {
            ContratoServico.Compra.RecuperarProdutoCompras.PeticaoRecuperarProdutoCompras Peticao = new ContratoServico.Compra.RecuperarProdutoCompras.PeticaoRecuperarProdutoCompras()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador,
                IdentificadorProdutoServico = _IdentificadorProdutoServico
            };

            Agente.Agente.InvocarServico<ContratoServico.Compra.RecuperarProdutoCompras.RespostaRecuperarProdutoCompras, ContratoServico.Compra.RecuperarProdutoCompras.PeticaoRecuperarProdutoCompras>(Peticao,
                  SDK.Operacoes.operacao.RecuperarProdutoCompras, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);

        }
        protected override void PreencherGrid(Boolean ExibirMensagem)
        {

            dgvCores.Rows.Clear();

            if (_Produtos != null && _Produtos.Count > 0)
            {

                string[] objStrCor = null;

                foreach (Comum.Clases.ProdutoCompra c in _Produtos.OrderBy(p => p.DataValidade))
                {

                    dgvCores.Rows.Add();
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colEstoqueAtual.Index].Value = c.EstoqueAtual;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colEstoque.Index].Value = c.Estoque;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDataCompra.Index].Value = c.DataCompra;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDataVencimento.Index].Value = c.DataValidade;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colLote.Index].Value = c.CodigoLote;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colCodigoCompra.Index].Value = c.CodigoCompra;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colProdutoFilial.Index].Value = c.IdentificadorProdutoFilial;
                }
                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }
        #endregion

        #region "Eventos"

        private void btnInserir_Click(object sender, EventArgs e)
        {

            Comum.Clases.ProdutoCompra produtoCompra = _Produtos.FirstOrDefault(p => p.EstoqueAtual == true);

            if (produtoCompra != null)
            {
                ContratoServico.Compra.SetEstoqueAtual.PeticaoSetEstoqueAtual Peticao = new ContratoServico.Compra.SetEstoqueAtual.PeticaoSetEstoqueAtual()
                {
                    Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                    IdentificadorProdutoFilial = produtoCompra.IdentificadorProdutoFilial,
                    IdentificadorItemCompra  = produtoCompra.Identificador
                };

                Agente.Agente.InvocarServico<ContratoServico.Compra.SetEstoqueAtual.RespostaSetEstoqueAtual, ContratoServico.Compra.SetEstoqueAtual.PeticaoSetEstoqueAtual>(Peticao,
                      SDK.Operacoes.operacao.SetEstoqueAtual, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
            }
            else
            {
                Classes.Util.ExibirMensagemInformacao("Nenhum registro selecionado");
            }
        }

        #endregion

        private void dgvCores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCores.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEstoqueAtual.Index)
                        {                            
                           foreach(DataGridViewRow g in dgvCores.Rows)
                            {
                                g.Cells[colEstoqueAtual.Index].Value = false;
                            }

                            dgvCores.Rows[e.RowIndex].Cells[colEstoqueAtual.Index].Value = true;

                            _Produtos.ForEach(p => p.EstoqueAtual = false);

                            var produto = (from Comum.Clases.ProdutoCompra pc in _Produtos where pc.Identificador == dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string select pc).FirstOrDefault();
                            produto.EstoqueAtual = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
               
        private void dgvCores_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvCores.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEstoqueAtual.Index)
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
    }
}
