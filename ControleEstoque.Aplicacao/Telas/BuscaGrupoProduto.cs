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
    public partial class BuscaGrupoProduto : TelaBase.BaseCE
    {
        public BuscaGrupoProduto()
        {
            InitializeComponent();
        }

        #region"Variaveis"
        private List<Comum.Clases.GrupoProduto> GruposProdutos = null;
        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
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

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_PRODUTO, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_PRODUTO, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_GRUPO_PRODUTO, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

       private void RecuperarGrupos(Boolean PreencherObjeto, Boolean ExibirMensagem)
        {
            ContratoServico.GrupoProduto.RecuperarGruposProduto.PeticaoRecuperarGruposProduto Peticao = new ContratoServico.GrupoProduto.RecuperarGruposProduto.PeticaoRecuperarGruposProduto();

            Peticao.IdentificadorEmpresa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.Descricao = txtNome.Text;


            Agente.Agente.InvocarServico<ContratoServico.GrupoProduto.RecuperarGruposProduto.RespostaRecuperarGruposCompromisso, ContratoServico.GrupoProduto.RecuperarGruposProduto.PeticaoRecuperarGruposProduto>(Peticao,
                    SDK.Operacoes.operacao.RecuperarGruposProduto, 
                    new Comum.ParametrosTela.Generica() { PreencherObjeto = PreencherObjeto, ExibirMensagemNenhumRegistro = ExibirMensagem }, null, true);

        }

        protected override void RespostaAgente(object objSaida, SDK.Operacoes.operacao operacao, Comum.ParametrosTela.Generica Parametros)
        {
            base.RespostaAgente(objSaida, operacao, Parametros);

            if (operacao == SDK.Operacoes.operacao.RecuperarGruposProduto)
            {
                GruposProdutos = ((ContratoServico.GrupoProduto.RecuperarGruposProduto.RespostaRecuperarGruposCompromisso)objSaida).GruposProdutos;
                
                if(Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if(operacao == SDK.Operacoes.operacao.DeletarGrupoProduto)
            {
                base.objNotificacao.ExibirMensagem("Grupo deletado com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarGrupos(true, false);
            }

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvGrupoProduto.Rows.Clear();

            if (GruposProdutos != null && GruposProdutos.Count > 0)
            {


                foreach (Comum.Clases.GrupoProduto c in GruposProdutos)
                {

                    dgvGrupoProduto.Rows.Add();
                    dgvGrupoProduto.Rows[dgvGrupoProduto.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvGrupoProduto.Rows[dgvGrupoProduto.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;

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
            GuardarGrupoProdutos frmCores = new GuardarGrupoProdutos(Identificador.Value, true, null);

            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarGrupos(true, false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ContratoServico.GrupoProduto.DeletarGrupoProduto.PeticaoDeletarGrupoProduto Peticao = new ContratoServico.GrupoProduto.DeletarGrupoProduto.PeticaoDeletarGrupoProduto();

            Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
            Peticao.IdentificadorGrupoProduto = Identificador.Value;


            Agente.Agente.InvocarServico<ContratoServico.GrupoProduto.DeletarGrupoProduto.RespostaDeletarGrupoProduto, ContratoServico.GrupoProduto.DeletarGrupoProduto.PeticaoDeletarGrupoProduto>(Peticao,
                    SDK.Operacoes.operacao.DeletarGrupoProduto, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }
        #endregion

        #region "Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {

                RecuperarGrupos(true,true);
                
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

                GruposProdutos = null;
                dgvGrupoProduto.Rows.Clear();
                txtNome.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            GuardarGrupoProdutos frmCor = new GuardarGrupoProdutos(string.Empty, true, null);

            if (frmCor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarGrupos(true,false);
            }
        }

        #endregion

        private void dgvGrupoProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvGrupoProduto.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                GuardarGrupoProdutos frmCores = new GuardarGrupoProdutos(dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string, true, null);

                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarGrupos(true,false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {


                                ContratoServico.GrupoProduto.DeletarGrupoProduto.PeticaoDeletarGrupoProduto Peticao = new ContratoServico.GrupoProduto.DeletarGrupoProduto.PeticaoDeletarGrupoProduto();

                                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;
                                Peticao.IdentificadorGrupoProduto = dgvGrupoProduto.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string;


                                Agente.Agente.InvocarServico<ContratoServico.GrupoProduto.DeletarGrupoProduto.RespostaDeletarGrupoProduto, ContratoServico.GrupoProduto.DeletarGrupoProduto.PeticaoDeletarGrupoProduto>(Peticao,
                                        SDK.Operacoes.operacao.DeletarGrupoProduto, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
                                                                
                               
                            }

                        }
                    }
                }
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

        private void dgvGrupoProduto_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvGrupoProduto.RowCount > 0)
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


    }
}
