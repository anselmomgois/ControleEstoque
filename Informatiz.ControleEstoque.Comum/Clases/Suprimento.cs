using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Suprimento
    {

        public string Identificador { get; set; }
        public string Observacao { get; set; }
        public decimal Valor { get; set; }
        public string IdentificadorSupervisor { get; set; }
        public string NomeSupervisor { get; set; }
        public string IdentificadorResponsavelCaixa { get; set; }
    }
}
