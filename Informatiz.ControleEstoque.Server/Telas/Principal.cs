using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.Server.Telas
{
    public partial class Principal : TelaBase.BaseCE
    {

        private List<Comum.Clases.ItemProcesso> _ProcessosBkp;

        public Principal()
        {
            InitializeComponent();
        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            ExecutarPreencherGrid(false);
            this.pnlBase.Controls.Add(gpbClientes);
            tmpAtualizacao.Start();
            base.Inicializar();
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {

            dgvCores.Rows.Clear();
            if (Classes.Processos.ListaProcessos != null && Classes.Processos.ListaProcessos.Count > 0)
            {

                //_ProcessosBkp = new List<Comum.Clases.ItemProcesso>();

                //foreach (Comum.Clases.Processo c in Classes.Processos.ListaProcessos)
                //{
                //    _ProcessosBkp.Add(c.Clone<Comum.Clases.Processo>());

                //    dgvCores.Rows.Add();

                //    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colProcesso.Index].Value = c.Descricao;
                //    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colIdCor.Index].Value = c.Identificador;
                //    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDataInicializacao.Index].Value = c.DataStatup;
                //    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDataUltimaExecucao.Index].Value = c.UltimaExecucao;
                //    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colDataProximaExecucao.Index].Value = c.ProximaExecucao;

                //    if (c.EmExecucao)
                //    {
                //        dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colExecucao.Index].Value = Properties.Resources.circle_green;
                //    }
                //    else
                //    {
                //        dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colExecucao.Index].Value = Properties.Resources.circle_red;
                //    }
                //}

                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }

        private void tmpAtualizacao_Tick(object sender, EventArgs e)
        {
            try
            {
                if (_ProcessosBkp != null && _ProcessosBkp.Count > 0)
                {
                    //foreach (Comum.Clases.ItemProcesso p in _ProcessosBkp)
                    //{
                    //    Boolean AtualizarGrid = Server.Classes.Processos.ListaProcessos.Exists(lp => lp.EmExecucao != p.EmExecucao || lp.ProximaExecucao != p.ProximaExecucao);

                    //    if (AtualizarGrid)
                    //    {
                    //        ExecutarPreencherGrid(false);
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = (Parametros.Parametros.InformacaoUsuario != null && !string.IsNullOrEmpty(Parametros.Parametros.InformacaoUsuario.Login) ? Parametros.Parametros.InformacaoUsuario.Login : "SERVER") });
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

                        if (e.ColumnIndex == colErros.Index)
                        {

                            //Comum.Clases.ItemProcesso processo = Server.Classes.Processos.ListaProcessos.Find(p => p.Identificador == dgvCores.Rows[e.RowIndex].Cells[colIdCor.Index].Value as string);

                            //if (processo != null && processo.LogProcesso != null && processo.LogProcesso.Count > 0)
                            //{
                            //    LogExecucao frmLog = new LogExecucao(processo);
                            //    frmLog.ShowDialog();
                            //}
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
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

                        if (e.ColumnIndex == colErros.Index)
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
                Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }
        }
    }
}
