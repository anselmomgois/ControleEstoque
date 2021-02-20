using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios.FechamentoCaixaGeral
{
   public class DadosRelatorio
    {
        public string FuncionarioCaixa { get; set; }
        public Int32 NumeroCaixa { get; set; }
        public decimal SaldoInicialCaixa { get; set; }
        public string NomeEmpresa { get; set; }
    }
}
