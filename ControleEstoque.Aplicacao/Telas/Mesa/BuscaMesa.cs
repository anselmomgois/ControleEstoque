using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Aplicacao.Classes;
using frmUtil = AmgSistemas.Framework.Utilitarios;

namespace Informatiz.ControleEstoque.Aplicacao.Telas
{
    public partial class BuscaMesa : TelaBase.BaseCE
    {
        public BuscaMesa()
        {
            InitializeComponent();

        }

        #region"Constantes"
        private const string btnBuscar = "btnBuscar";
        private const string btnInserir = "btnInserir";
        private const string btnLimpar = "btnLimpar";
        #endregion

        #region"Variaveis"

        private List<Comum.Clases.Mesa> objMesas = null;
        #endregion

        #region"Metodos"

        private void ConfigurarVisualizacao()
        {

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_MESA, Comum.Enumeradores.Enumeradores.TipoAcao.INSERIR))
            {
                this.OcultarItemMenu(string.Empty, string.Empty, btnInserir, true);
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_MESA, Comum.Enumeradores.Enumeradores.TipoAcao.EXCLUIR))
            {
                colExcluir.Visible = false;
            }

            if (!Aplicacao.Classes.Util.ValidarPermissao(ControleEstoque.Parametros.Parametros.InformacaoUsuario.Permissoes, Comum.Clases.Constantes.COD_PERMISSAO_MESA, Comum.Enumeradores.Enumeradores.TipoAcao.MODIFICAR))
            {
                colEditar.Visible = false;
            }

        }

        private void RecuperarMesas(Boolean ExibirMensagemNenhumRegistro, Boolean PreencherObjeto)
        {
            ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas Peticao = new ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas();

            Peticao.Codigo = txtNome.Text.Trim();
            Peticao.QuantidadeLugares = !string.IsNullOrEmpty(txtQuantidadeLugares.Text) ? Convert.ToInt32(txtQuantidadeLugares.Text.Trim()) : 0;
            Peticao.IdentificadorFilial = ControleEstoque.Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
            Peticao.Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login;

            Agente.Agente.InvocarServico<ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas, ContratoServico.Mesa.BuscarMesas.PeticaoBuscarMesas>(Peticao, SDK.Operacoes.operacao.BuscarMesas,
                new Comum.ParametrosTela.Generica
                {
                    ExibirMensagemNenhumRegistro = ExibirMensagemNenhumRegistro,
                    PreencherObjeto = PreencherObjeto
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

            if (operacao == SDK.Operacoes.operacao.BuscarMesas)
            {
                objMesas = ((ContratoServico.Mesa.BuscarMesas.RespostaBuscarMesas)objSaida).Mesas;
                if (Parametros != null && Parametros.PreencherObjeto)
                {
                    ExecutarPreencherGrid(Parametros.ExibirMensagemNenhumRegistro);
                }
            }
            else if (operacao == SDK.Operacoes.operacao.SetMesa)
            {
                base.objNotificacao.ExibirMensagem("Mesa desativada com sucesso.", Controles.UcNotificacao.TipoImagem.SUCESSO);
                RecuperarMesas(false, true);
            }

        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {
            dgvMarcas.Rows.Clear();

            if (objMesas != null && objMesas.Count > 0)
            {


                foreach (Comum.Clases.Mesa c in objMesas)
                {

                    dgvMarcas.Rows.Add();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colCodigoMesa.Index].Value = c.Codigo;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colQuantidadeLugares.Index].Value = c.QuantidadeLugar;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colEstado.Index].Value = c.Estado == Comum.Enumeradores.EstadoMesa.AguardandoLimpeza ? "Aguardando Limpeza" : c.Estado.ToString();
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                    dgvMarcas.Rows[dgvMarcas.Rows.Count - 1].Cells[colExcluir.Index].Value = c.Ativa ? Properties.Resources.x : Properties.Resources.x_gray;

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
            GuardarMesa frmCores = new GuardarMesa(Identificador.Value);

            if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
            {
                RecuperarMesas(false, true);
            }

            base.Modificar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        protected override void Deletar(KeyValuePair<string, string> Identificador, string NomeGrid, Int32 RowIndex, Int32 ColumnIndex)
        {

            ContratoServico.Mesa.SetMesa.PeticaoSetMesa Peticao = new ContratoServico.Mesa.SetMesa.PeticaoSetMesa();

            Comum.Clases.Mesa objMesa = objMesas.Find(m => m.Identificador == Identificador.Value);

            if (objMesa != null)
            {
                objMesa.Ativa = false;

                Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
                Peticao.Mesa = objMesa;
                Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

                Agente.Agente.InvocarServico<ContratoServico.Mesa.SetMesa.RespostaSetMesa, ContratoServico.Mesa.SetMesa.PeticaoSetMesa>(Peticao,
                    SDK.Operacoes.operacao.SetMesa, null, null, true);
            }

            base.Deletar(Identificador, NomeGrid, RowIndex, ColumnIndex);
        }

        #endregion

        #region"Eventos"

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtQuantidadeLugares_KeyPress(object sender, KeyPressEventArgs e)
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
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                RecuperarMesas(true, true);

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

                objMesas = null;
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

                GuardarMesa frmCor = new GuardarMesa(string.Empty);
                
                if (AbrirFormulario(frmCor) == System.Windows.Forms.DialogResult.OK)
                {
                    RecuperarMesas(false, true);
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

                                GuardarMesa frmCores = new GuardarMesa(dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (AbrirFormulario(frmCores) == System.Windows.Forms.DialogResult.OK)
                                {
                                    RecuperarMesas(false, true);
                                }
                            }
                            else if (e.ColumnIndex == colExcluir.Index)
                            {

                                ContratoServico.Mesa.SetMesa.PeticaoSetMesa Peticao = new ContratoServico.Mesa.SetMesa.PeticaoSetMesa();

                                Comum.Clases.Mesa objMesa = objMesas.Find(m => m.Identificador == dgvMarcas.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                                if (objMesa != null)
                                {
                                    objMesa.Ativa = false;

                                    Peticao.IdentificadorFilial = Parametros.Parametros.InformacaoUsuario.FilialSelecionada.Identificador;
                                    Peticao.Mesa = objMesa;
                                    Peticao.Usuario = Parametros.Parametros.InformacaoUsuario.Login;

                                    Agente.Agente.InvocarServico<ContratoServico.Mesa.SetMesa.RespostaSetMesa, ContratoServico.Mesa.SetMesa.PeticaoSetMesa>(Peticao,
                                        SDK.Operacoes.operacao.SetMesa, null, null, true);
                                }

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
