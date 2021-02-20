using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Informatiz.ControleEstoque.Server.Telas
{
    public partial class LogExecucao : TelaBase.BaseCE
    {
        private Comum.Clases.ItemProcesso _Processo;

        public LogExecucao(Comum.Clases.ItemProcesso Processo)
        {
            InitializeComponent();

            _Processo = Processo;

        }

        protected override void Inicializar()
        {
            MontarMenu(false);
            ExecutarPreencherGrid(false);
            this.pnlBase.Controls.Add(gpbLog);
            base.Inicializar();
        }

        protected override void PreencherGrid(Boolean ExibirMensagem)
        {

            dgvCores.Rows.Clear();
            if (_Processo != null && _Processo.LogProcesso != null && _Processo.LogProcesso.Count > 0)
            {
               
                foreach (Comum.Clases.LogProcesso c in _Processo.LogProcesso)
                {

                    dgvCores.Rows.Add();

                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colData.Index].Value = c.Data;
                    dgvCores.Rows[dgvCores.Rows.Count - 1].Cells[colLog.Index].Value = c.Log;
                }

                base.PreencherGrid(ExibirMensagem);
            }
            else if (ExibirMensagem)
            {
                base.objNotificacao.ExibirMensagem("Nenhum registro encontrado", Controles.UcNotificacao.TipoImagem.INFORMACAO);

            }

        }

    }
}
