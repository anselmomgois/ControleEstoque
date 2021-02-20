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
    public partial class BuscaCores : TelaBase.BaseCE
    {
        public BuscaCores()
        {
            InitializeComponent();
        }

        #region"Variaveis'

        private List<Comum.Clases.Cor> Cores = null;


        #endregion

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
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

            if (operacao == SDK.Operacoes.operacao.RecuperarCores)
            {
                Cores = ((ContratoServico.Cor.RecuperarCores.RespostaRecuperarCores)objSaida).Cores;

                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.DeletarCor)
            {

                base.objNotificacao.ExibirMensagem("Cor deletada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarCores(false);
            }


        }

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CORES, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);

            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CORES, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_CORES, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarCores(Boolean ExibirMensagemNenhumRegistro)
        {
            ContratoServico.Cor.RecuperarCores.PeticaoRecuperarCores Peticao = new ContratoServico.Cor.RecuperarCores.PeticaoRecuperarCores()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                IdentificadorEmpesa = ControleEstoque.Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Identificador,
                Descricao = txtNome.Text.Trim()
            };

            Agente.Agente.InvocarServico<ContratoServico.Cor.RecuperarCores.RespostaRecuperarCores, ContratoServico.Cor.RecuperarCores.PeticaoRecuperarCores>(Peticao,
                  SDK.Operacoes.operacao.RecuperarCores, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro }, null, true);
                        
        }
        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            
            dgvCores.Rows.Clear();

            if (Cores != null && Cores.Count > 0)
            {

                string[] objStrCor = null;

                foreach (Comum.Clases.Cor c in Cores)
                {

                    dgvCores.Rows.Add();
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDescricao.Index].Value = c.Descricao;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;

                    objStrCor = c.CodigoRGB.Split(Convert.ToChar("|"));

                    Int32 A = Convert.ToInt32(objStrCor[0]);
                    Int32 R = Convert.ToInt32(objStrCor[1]);
                    Int32 G = Convert.ToInt32(objStrCor[2]);
                    Int32 B = Convert.ToInt32(objStrCor[3]);

                    dgvCores.Rows[dgvCores.Rows.Count - 1].DefaultCellStyle.BackColor = Color.FromArgb(A, R, G, B);
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
            Cor frmCores = new Cor(Identificador.Value);

            if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarCores(false);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {
            ContratoServico.Cor.DeletarCor.PeticaoDeletarCor Peticao = new ContratoServico.Cor.DeletarCor.PeticaoDeletarCor()
            {
                Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                Identificador = Identificador.Value
            };

            Agente.Agente.InvocarServico<ContratoServico.Cor.DeletarCor.RespostaDeletarCor, ContratoServico.Cor.DeletarCor.PeticaoDeletarCor>(Peticao,
                  SDK.Operacoes.operacao.DeletarCor, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            try
            {

                RecuperarCores(true);                

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

                Cores = null;
                dgvCores.Rows.Clear();
                txtNome.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {

            Cor frmCor = new Cor(string.Empty);

           if (frmCor.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarCores(false);
            }
        }

        private void dgvCores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvCores.RowCount > 0)
                {
                    if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                    {

                        if (e.ColumnIndex == colEditar.Index || e.ColumnIndex == colExcluir.Index)
                        {

                            if (e.ColumnIndex == colEditar.Index)
                            {

                                Cor frmCores = new Cor(dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (frmCores.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarCores(false);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                ContratoServico.Cor.DeletarCor.PeticaoDeletarCor Peticao = new ContratoServico.Cor.DeletarCor.PeticaoDeletarCor()
                                {
                                    Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login,
                                    Identificador = dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string
                                };

                                Agente.Agente.InvocarServico<ContratoServico.Cor.DeletarCor.RespostaDeletarCor, ContratoServico.Cor.DeletarCor.PeticaoDeletarCor>(Peticao,
                                      SDK.Operacoes.operacao.DeletarCor, new Comum.ParametrosTela.Generica() { PreencherObjeto = true, ExibirMensagemNenhumRegistro = false }, null, true);
                                
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

        private void dgvCores_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvCores.RowCount > 0)
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
              

        #endregion

    }
}
