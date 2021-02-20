using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class OperacaoCaixa
    {
        public string Identificador { get; set; }
        public Comum.Clases.Pessoa FuncionarioCaixa { get; set; }
        public Decimal Saldo { get; set; }
        public Decimal ValorAbertura { get; set; }
        public DateTime DataInicioOperacao { get; set; }
        public Nullable<DateTime> DataFimOperacao { get; set; }
        public List<Venda> Vendas { get; set; }
    }
}
