using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class TipoEmpregado
    {
        public string Identificador { get; set; }
        public string Descricao { get; set; }
        public bool Supervisor { get; set; }
        public bool ResponsavelFinanceiro { get; set; }
        public bool Entregador { get; set; }
        public bool Gerente { get; set; }
        public bool EnviarEmailFechamento { get; set; }
    }
}
