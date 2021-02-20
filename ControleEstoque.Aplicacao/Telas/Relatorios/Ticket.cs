//using Microsoft.Reporting.WinForms;
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

namespace Informatiz.ControleEstoque.Aplicacao.Telas.Relatorios
{
    public partial class Ticket : Form
    {
        public Ticket()
        {
            InitializeComponent();
            //pnlReport.Controls.Add(rvTicket);

            List<Comum.Clases.Relatorios.Ticket> tickets = new List<Comum.Clases.Relatorios.Ticket>();

            //for (int i = 0; i < 5; i++)
            //{
            //    int cont = i + 1;
            //    Comum.Clases.Relatorios.Ticket ticket = new Comum.Clases.Relatorios.Ticket();
            //    ticket.CodigoProduto = "COD_" + cont.ToString();
            //    ticket.DescricaoProduto = "DES_" + cont.ToString();
            //    ticket.Quantidade = cont;
            //    ticket.ValorUnitario = cont + 5;
            //    ticket.SubTotal = ticket.Quantidade * ticket.ValorUnitario;

            //    tickets.Add(ticket);
            //}

           //imprimirTicket(tickets);

        }

        //private void ImprimirTicket(List<Comum.Clases.Relatorios.Ticket> tickets, ref System.Drawing.Printing.PrinterSettings printSettings)
        //{
        //    string CaminhoArquivo = String.Format("{0}{1}", AppDomain.CurrentDomain.BaseDirectory, "Report\\Ticket.rdlc");
        //    DataSet.dsTicket ds = new DataSet.dsTicket();
        //    ds.PopularDataSet(tickets,
        //                      "0001",
        //                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Cnpj,
        //                      DateTime.Now,
        //                      "Debito",
        //                      "Marcel",
        //                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Nome,
        //                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().TelefoneFixo,
        //                      Parametros.Parametros.InformacaoUsuario.EmpresaSelecionada.Filiais.FirstOrDefault().Endereco.Nome);

        //    ReportViewer objReportViewer = new ReportViewer();
        //    objReportViewer.Dock = DockStyle.Fill;
        //    pnlReport.Controls.Add(objReportViewer);
        //    objReportViewer.LocalReport.DataSources.Clear();

        //    for (int i = 0; i <= ds.Tables.Count - 1; i++)
        //    {
        //        objReportViewer.LocalReport.DataSources.Add(new ReportDataSource(ds.Tables[i].TableName, ds.Tables[i]));
        //    }

        //    objReportViewer.LocalReport.ReportPath = CaminhoArquivo;
        //    objReportViewer.RefreshReport();

        //    objReportViewer.LocalReport.SubreportProcessing +=
        //            new SubreportProcessingEventHandler(SubreportProcessingEventHandler);

        //    System.Drawing.Printing.PrintDocument objDocumento = new System.Drawing.Printing.PrintDocument();
        //    objDocumento.DocumentName = CaminhoArquivo;
        //    PrintDialog objPrint = new PrintDialog();
        //    objPrint.Document = objDocumento;

        //    if (printSettings == null)
        //    {
        //        if (objPrint.ShowDialog() == DialogResult.OK)
        //        {
        //            printSettings = objPrint.PrinterSettings;
        //            Aplicacao.Classes.RawPrinterHelper.SendFileToPrinter(printSettings.PrinterName, CaminhoArquivo);
        //        }
        //    }
        //    else
        //    {
        //        Aplicacao.Classes.RawPrinterHelper.SendFileToPrinter(printSettings.PrinterName, CaminhoArquivo);
        //    }
        //}

        //private void SubreportProcessingEventHandler(object sender, SubreportProcessingEventArgs e)
        //{
        //    LocalReport objLocalReport = (LocalReport)sender;
        //    if (objLocalReport != null && objLocalReport.DataSources != null)
        //    {
        //        if (e.DataSourceNames != null)
        //        {
        //            foreach (var dsName in e.DataSourceNames)
        //            {
        //                var dataSource = objLocalReport.DataSources.Where(x => x.Name == dsName).FirstOrDefault();
        //                if (dataSource != null)
        //                {
        //                    e.DataSources.Add(new ReportDataSource(dsName, dataSource.Value));
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
