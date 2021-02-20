using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using frmWindows = AmgSistemas.Framework.WindowsForms;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscaCompras : TelaBase.BaseCE
    {
        public BuscaCompras()
        {
            InitializeComponent();
        }

        #region"Variaveis"

        private List<Comum.Clases.Filiais> _Filiais;
        private object objPessoa;
        private List<Classes.ValorDescricao> _Estados;
        private List<Comum.Clases.Compra> _Compras;

        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Metodos"

        protected override void MontarMenu(Boolean GerarGrupo)
        {
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Buscar (F2)", btnBuscar, Properties.Resources.search, new EventHandler(btnBuscar_Click), Keys.F2, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Inserir (F3)", btnInserir, Properties.Resources._new, new EventHandler(btnInserir_Click), Keys.F3, false, false, false);
            this.AdicionarItemMenu(string.Empty, string.Empty, string.Empty, string.Empty, "Limpar (F4)", btnLimpar, Properties.Resources.gnome_edit_clear, new EventHandler(btnLimpar_Click), Keys.F4, false, false, false);
            base.MontarMenu(GerarGrupo);
        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPRAS, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPRAS, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_COMPRAS, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

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

            if (operacao == SDK.Operacoes.operacao.RecuperarFiliais)
            {

                _Filiais = ((ContratoServico.Filial.RecuperarFiliais.RespostaRecuperarFiliais)objSaida).Filiais;

                if (_Filiais != null)
                {
                    List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_Filiais, "Identificador", "Nome");
                    lstFiliais = frmWindows.Util.PreencherListBox(lstFiliais, Items);
                    lstFiliais.SelectedItem = (from frmWindows.Item i in lstFiliais.Items
                                               where i.Identificador == Informatiz.ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Identificador
                                               select i).FirstOrDefault();
                    dtpInicio.Value = DateTime.Now.AddDays(-3);
                    dtpFim.Value = DateTime.Now.AddDays(3);

                    if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_REALIZAR_COMPRA_OUTRA_FILIAL, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
                    {
                        lstFiliais.Enabled = false;

                    }
                }
            }
            else if (operacao == SDK.Operacoes.operacao.RecuperarCompras)
            {
                _Compras = ((ContratoServico.Compra.RecuperarCompras.RespostaRecuperarCompras)objSaida).Compras;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }


        }

        private void CarregarEstados()
        {
            _Estados = new List<Classes.ValorDescricao>();
            _Estados.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.EstadoCompra.CompraGerada.RecuperarValor(),
                Descricao = "Compra Gerada"
            });

            _Estados.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.EstadoCompra.OrdemEmitida.RecuperarValor(),
                Descricao = "Ordem Emitida"
            });

            _Estados.Add(new Classes.ValorDescricao()
            {
                Identificador = Comum.Enumeradores.EstadoCompra.CompraFinalizada.RecuperarValor(),
                Descricao = "Compra Finalizada"
            });

            List<frmWindows.Item> Items = frmWindows.Util.ConverterItems(_Estados, "Identificador", "Descricao");
            cmbEstado = frmWindows.Util.PreencherCombobox(cmbEstado, Items);

        }
        private void CarredarDados()
        {
            CarregarEstados();

            ContratoServico.Filial.RecuperarFiliais.PeticaoRecuperarFiliais Peticao = new ContratoServico.Filial.RecuperarFiliais.PeticaoRecuperarFiliais()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.Filial.RecuperarFiliais.RespostaRecuperarFiliais, ContratoServico.Filial.RecuperarFiliais.PeticaoRecuperarFiliais>(Peticao,
                  SDK.Operacoes.operacao.RecuperarFiliais, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        private void RecuperarCompras(Boolean PreencherObjeto, Boolean ExibirMensagem)
        {

            List<Comum.Clases.Filiais> objFiliais = (List<Comum.Clases.Filiais>)(frmWindows.Util.RecuperarItemsSelecionados<Comum.Clases.Filiais>(lstFiliais, _Filiais, "Identificador"));
            List<string> IdentificadoresFiliais = null;
            Nullable<Comum.Enumeradores.EstadoCompra> Estado = null;

            if (objFiliais != null && objFiliais.Count > 0)
            {
                IdentificadoresFiliais = new List<string>();

                foreach (Comum.Clases.Filiais objFilial in objFiliais)
                {
                    IdentificadoresFiliais.Add(objFilial.Identificador);
                }
            }

            if (cmbEstado.SelectedItem != null)
            {
                Estado = (Comum.Enumeradores.EstadoCompra)(frmWindows.Util.RecuperarItemSelecionado(cmbEstado, _Estados, "Identificador"));
            }

            ContratoServico.Compra.RecuperarCompras.PeticaoRecuperarCompras Peticao = new ContratoServico.Compra.RecuperarCompras.PeticaoRecuperarCompras()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorFiliais = IdentificadoresFiliais,
                Codigo = txtCodigo.Text,
                DataInicio = (dtpInicio.Checked ? (Nullable<DateTime>)dtpInicio.Value : null),
                DataFim = (dtpFim.Checked ? (Nullable<DateTime>)dtpFim.Value : null),
                EstadoCompra = Estado
            };

            Agente.Agente.InvocarServico<ContratoServico.Compra.RecuperarCompras.RespostaRecuperarCompras, ContratoServico.Compra.RecuperarCompras.PeticaoRecuperarCompras>(Peticao,
                  SDK.Operacoes.operacao.RecuperarCompras, new Comum.ParametrosTela.Generica() { PreencherObjeto = true }, null, true);

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvMarcas.Rows.Clear();
            Comum.Clases.Compra objCompra = null;

            if (_Compras != null && _Compras.Count > 0)
            {


                foreach (Comum.Clases.Compra c in _Compras)
                {

                    StringBuilder objFuncResponsavel = new StringBuilder();
                    StringBuilder objData = new StringBuilder();
                    List<string> objListFuncResp = new List<string>();
                    List<string> objListaData = new List<string>();

                    string objDescricaoFuncionario = string.Empty;

                    dgvMarcas.Rows.Add();

                    if (c.Fornecedor != null)
                    {
                        dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colFornecedor.Index].Value = c.Fornecedor.DesNome;
                    }
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdentificador.Index].Value = c.Identificador;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCodigoCompra.Index].Value = c.CodigoCompra;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDataCompra.Index].Value = c.DataCompra;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDataRecebimento.Index].Value = c.DataRecebimento;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colRastreio.Index].ToolTipText = c.CodigoRastreio;

                }

                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            CarredarDados();
            ConfigurarVisualizacao();
            base.Inicializar();
            this.pnlBase.Controls.Add(tlpPrincipal);
            tlpPrincipal.Dock = DockStyle.Fill;
        }

        protected override void Modificar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            GuardarCompra frmCompra = new GuardarCompra(false, Identificador.Value);

            if (frmCompra.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarCompras(true, false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region "Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarCompras(true, true);

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

                GuardarCompra frmGuardarCompra = new GuardarCompra(false, string.Empty);


                if (frmGuardarCompra.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarCompras(true, false);

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

                                GuardarCompra frmCompra = new GuardarCompra((e.ColumnIndex == colEditar.Index ? false : true), dgvMarcas.Rows[e.RowIndex].Cells[colIdentificador.Index].Value as string);

                                if (frmCompra.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarCompras(true, false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                //ContratoServico.Cor.DeletarCor.PeticaoDeletarCor Peticao = new ContratoServico.Cor.DeletarCor.PeticaoDeletarCor()
                                //{
                                //    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                                //    Identificador = dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string
                                //};

                                //Agente.Agente.InvocarServico<ContratoServico.Cor.DeletarCor.RespostaDeletarCor, ContratoServico.Cor.DeletarCor.PeticaoDeletarCor>(Peticao,
                                //      SDK.Operacoes.operacao.DeletarCor, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);

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

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index || e.ColumnIndex == colRastreio.Index || e.ColumnIndex == colConsultar.Index)
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                _Compras = null;
                dgvMarcas.Rows.Clear();
                txtCodigo.Text = string.Empty;
                cmbEstado.SelectedItem = null;
                dtpInicio.Value = DateTime.Now.AddDays(-3);
                dtpFim.Value = DateTime.Now.AddDays(3);

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        #endregion


    }
}
