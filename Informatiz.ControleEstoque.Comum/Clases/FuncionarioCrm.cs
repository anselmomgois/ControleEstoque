using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class FuncionarioCrm
    {
        public FuncionarioCrm()
        {
            Funcionario = new Comum.Clases.Pessoa();
        }

        public Comum.Clases.Pessoa Funcionario { get; set; }
        public Int32 QuantidadeVezesEscolhido { get; set; }
    }
}
