using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscaSegmentoComercial : TelaBase.BaseCE
    {
        public BuscaSegmentoComercial()
        {
            InitializeComponent();
        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.SegmentoComercial> SegmentosComerciais = null;

        #endregion

        #region"Metodos"

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

            if (operacao == SDK.Operacoes.operacao.PesquisarSegmentoComercial)
            {
                SegmentosComerciais = ((ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.RespostaPesquisarSegmentoComercial)objSaida).SegmentoComercias;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.DeletarSegmentoComercial)
            {

                base.objNotificacao.ExibirMensagem("Segmento Comercial deletado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperaSegmentosComerciais(false);
            }


        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SEGMENTO_COMERCIAL, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SEGMENTO_COMERCIAL, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_SEGMENTO_COMERCIAL, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperaSegmentosComerciais(Boolean ExibirMensagemNenhumRegistro)
        {
            ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.PeticaoPesquisarSegmentoComercial Peticao = new ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.PeticaoPesquisarSegmentoComercial()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpresa = Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                Descricao = txtNome.Text.Trim()
            };

            Agente.Agente.InvocarServico<ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.RespostaPesquisarSegmentoComercial, ContratoServico.SegmentoComercial.PesquisarSegmentoComercial.PeticaoPesquisarSegmentoComercial>(Peticao,
                  SDK.Operacoes.operacao.PesquisarSegmentoComercial, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);
                        
        }

        private void DeletarSegmentosComerciais(string Identificador)
        {
            ContratoServico.SegmentoComercial.DeletarSegmentoComercial.PeticaoDeletarSegmentoComercial Peticao = new ContratoServico.SegmentoComercial.DeletarSegmentoComercial.PeticaoDeletarSegmentoComercial()
            {
                Usuario = Parametros.Parametros.InformacaoUsuario.Login,
                Identificador = Identificador
            };

            Agente.Agente.InvocarServico<ContratoServico.SegmentoComercial.DeletarSegmentoComercial.RespostaDeletarSegmentoComercial, ContratoServico.SegmentoComercial.DeletarSegmentoComercial.PeticaoDeletarSegmentoComercial>(Peticao,
                  SDK.Operacoes.operacao.DeletarSegmentoComercial, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvMarcas.Rows.Clear();

            if (SegmentosComerciais != null && SegmentosComerciais.Count > 0)
            {


                foreach (Comum.Clases.SegmentoComercial c in SegmentosComerciais)
                {

                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;

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
            GuardarSegmentoComercial frmCores = new GuardarSegmentoComercial(Identificador.Value);

            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperaSegmentosComerciais(false);
                
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            DeletarSegmentosComerciais(Identificador.Value);           

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperaSegmentosComerciais(true);

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

                SegmentosComerciais = null;
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
                GuardarSegmentoComercial frmCor = new GuardarSegmentoComercial(string.Empty);

                if (frmCor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperaSegmentosComerciais(false);
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

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
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

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvMarcas.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarSegmentoComercial frmCores = new GuardarSegmentoComercial(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperaSegmentosComerciais(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                DeletarSegmentosComerciais(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);
                                                                
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
    }
}
