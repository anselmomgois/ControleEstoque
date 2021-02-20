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
    public partial class RelatorioVisualizar : TelaBase.BaseCE
    {
        public RelatorioVisualizar()
        {
            InitializeComponent();

            
        }

        #region"Propriedades"

        public System.Data.DataSet FonteDados { get; set; }
        public string Relatorio { get; set; }
        
        #endregion

        #region"Metodos"

        public void CarregarDados()
        {
            
            // string DiretorioRelatorio = "Z:\\Projetos\\ControleEstoque - 2010\\ControleEstoque.Aplicacao\\Report\\" + Relatorio;
            string DiretorioRelatorio = Environment.CurrentDirectory + "\\Report\\"  + Relatorio;
            CrystalDecisions.CrystalReports.Engine.ReportDocument objReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            objReport.Load(DiretorioRelatorio);
            objReport.SetDataSource(FonteDados);

            crvRelatorio.ReportSource = objReport;
            crvRelatorio.ShowGroupTreeButton = false;
            
        }

        #endregion

        private void RelatorioVisualizar_Load(object sender, EventArgs e)
        {
            try
            {

                CarregarDados();
            }
            catch (Exception ex)
            {
                Aplicacao.Classes.Util.LogarErro(new Comum.Clases.Erro { Execao = ex, DesErro = ex.Message, Usuario = ControleEstoque.Parametros.Parametros.InformacaoUsuario.Login });
            }

        }

    }
}
