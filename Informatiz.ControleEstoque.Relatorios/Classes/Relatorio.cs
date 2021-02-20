using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Extencoes;

namespace Informatiz.ControleEstoque.Relatorios.Classes
{
   public class Relatorio
    {

        public static CrystalDecisions.CrystalReports.Engine.ReportDocument Gerar(object Dados, Comum.Enumeradores.TipoRelatorio TipoRelatorio)
        {

            System.Data.DataSet ds = null;

            switch(TipoRelatorio)
            {
                case Comum.Enumeradores.TipoRelatorio.FechamentoCaixa:

                    ds = new Informatiz.ControleEstoque.Relatorios.DataSet.dsFechamento();
                    ((Informatiz.ControleEstoque.Relatorios.DataSet.dsFechamento)ds).PopularDataSet(Dados);

                    break;
                case Comum.Enumeradores.TipoRelatorio.FechamentoCaixaEmail:

                    ds = new Informatiz.ControleEstoque.Relatorios.DataSet.dsFechamentoCaixa();
                    ((Informatiz.ControleEstoque.Relatorios.DataSet.dsFechamentoCaixa)ds).PopularDataSet(Dados);

                    break;
                case Comum.Enumeradores.TipoRelatorio.VendasCaixa:

                    ds = new Informatiz.ControleEstoque.Relatorios.DataSet.dsVendas();
                    ((Informatiz.ControleEstoque.Relatorios.DataSet.dsVendas)ds).PopularDataSet(Dados);

                    break;
                case Comum.Enumeradores.TipoRelatorio.FechamentoVenda:

                    ds = new Informatiz.ControleEstoque.Relatorios.DataSet.dsTicket();
                    ((Informatiz.ControleEstoque.Relatorios.DataSet.dsTicket)ds).PopularDataSet(Dados);

                    break;
                case Comum.Enumeradores.TipoRelatorio.PedidoSetor:

                    ds = new Informatiz.ControleEstoque.Relatorios.DataSet.dsTicket();
                    ((Informatiz.ControleEstoque.Relatorios.DataSet.dsTicket)ds).PopularDataSet(Dados);

                    break;

            }


            string DiretorioRelatorio = string.Format("{0}\\{1}", Environment.CurrentDirectory, TipoRelatorio.RecuperarValor());
            CrystalDecisions.CrystalReports.Engine.ReportDocument objReport = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            objReport.Load(DiretorioRelatorio);
            objReport.SetDataSource(ds);
            
            return objReport;
        }
    }
}
