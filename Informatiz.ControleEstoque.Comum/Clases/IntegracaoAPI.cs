using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class IntegracaoAPI
    {
        public string Identificador { get; set; }
        public string Url { get; set; }
        public string IdentificadorTipoCRM { get; set; }
        public string CodigoTipoCrm { get; set; }
        public Nullable<Enumeradores.TipoIntegracao> TipoIntegracao { get; set; }
    }
}
