using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class TipoCrmConfig
    {

        public string Identificador { get; set; }
        public TipoEmpregado TipoEmpregado { get; set; }
        public List<Pessoa> Pessoas { get; set; }
        public Boolean EmpregadoAtual { get; set; }
        public Int32 QuantidadeDiasData { get; set; }
        public Int32 QuantidadeEmpregados { get; set; }
        public Int32 Nivel { get; set; }
        public string DescricaoNivel { get; set; }

    }
}
