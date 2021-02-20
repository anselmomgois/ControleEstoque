using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class ItemProcesso
    {
        public string Identificador { get; set; }
        public string Valor { get; set; }
        public Nullable<DateTime> InicioExecucao { get; set; }
        public Nullable<DateTime> FimExecucao { get; set; }
        public DateTime DataExecucaoProgramada { get; set; }
        public string CodigoTipoCrm { get; set; }
        public Enumeradores.TipoIntegracao TipoIntegracao { get; set; }
        public List<LogProcesso> LogProcesso { get; set; }
        public Comum.Enumeradores.TipoProcesso Tipo { get; set; }
        public object Parametros { get; set; }
        public Boolean EmExecucao { get; set; }
    }
}
