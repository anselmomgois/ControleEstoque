using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Informatiz.ControleEstoque.Relatorios.Classes
{
    public class Imprimir
    {
        public static void ImprimirTicket(object objDados, Comum.Enumeradores.TipoRelatorio TipoRelatorio)
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument objReportDocument = Relatorio.Gerar(objDados, TipoRelatorio);

            PrinterSettings m_pageSettings = new PrinterSettings();
            PageSettings objPageSettings = new PageSettings();

            objPageSettings.Margins = new Margins(objReportDocument.PrintOptions.PageMargins.leftMargin,
                                                   objReportDocument.PrintOptions.PageMargins.rightMargin,
                                                   objReportDocument.PrintOptions.PageMargins.topMargin,
                                                   objReportDocument.PrintOptions.PageMargins.bottomMargin);

             objReportDocument.PrintToPrinter(m_pageSettings, objPageSettings, false);
          
        }

        public static void ImprimirRelatorio(object objDados, Comum.Enumeradores.TipoRelatorio TipoRelatorio, string DirecaoImpressora)
        {
            
            CrystalDecisions.CrystalReports.Engine.ReportDocument objReportDocument = Relatorio.Gerar(objDados, TipoRelatorio);

            PrintDialog pd = new PrintDialog();
            pd.PrinterSettings.PrinterName = DirecaoImpressora;
            PageSettings objPageSettings = new PageSettings();


            objPageSettings.Margins = new Margins(objReportDocument.PrintOptions.PageMargins.leftMargin,
                                                   objReportDocument.PrintOptions.PageMargins.rightMargin,
                                                   objReportDocument.PrintOptions.PageMargins.topMargin,
                                                   objReportDocument.PrintOptions.PageMargins.bottomMargin);

            objReportDocument.PrintOptions.PrinterName = DirecaoImpressora;

            objReportDocument.PrintToPrinter(pd.PrinterSettings, objPageSettings, false);
            
        }

        public static Stream ReportToStream(object objDados, Comum.Enumeradores.TipoRelatorio TipoRelatorio)
        {

            CrystalDecisions.CrystalReports.Engine.ReportDocument objReportDocument = Relatorio.Gerar(objDados, TipoRelatorio);


            return objReportDocument.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);

        }


    }
}
