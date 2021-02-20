using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios.FechamentoCaixa
{
    public class FechamentoCaixa
    {
        public List<Venda> Vendas { get; set; }
        public List<Sangria> Sangrias { get; set; }
        public List<Suprimento> Suprimentos { get; set; }
        public List<Clases.FechamentoCaixa> Fechamentos { get; set; }
        public decimal ValorTotalSangria
        {
            get
            {
                if (Sangrias != null && Sangrias.Count > 0)
                    return Sangrias.Sum(s => s.Valor);
                else
                    return 0;
            }
        }

        public decimal ValorTotalSuprimento
        {
            get
            {
                if (Suprimentos != null && Suprimentos.Count > 0)
                    return Suprimentos.Sum(s => s.Valor);
                else
                    return 0;
            }
        }
        public decimal SaldoInicialCaixa { get; set; }
        public string Empresa { get; set; }
        public string NomeFuncionario { get; set; }

        public string NomeSupervisor { get; set; }

        public Int32 NumeroCaixa { get; set; }
        public string Endereco { get; set; }
    }
}
