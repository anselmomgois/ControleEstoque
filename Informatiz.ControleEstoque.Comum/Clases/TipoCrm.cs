using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class TipoCrm
    {
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public string IdentificadorStatusCrmAgrup { get; set; }
        public string IdentificadorStatusPadrao { get; set; }
        public string DescricaoStatusCrmAgrup { get; set; }
        public string DescricaoStatusPadrao { get; set; }
        public List<TipoCrmConfig> TiposCrmConfig { get; set; }
    }
}
