using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Atributos;

namespace Informatiz.ControleEstoque.Comum.Enumeradores
{
    public enum TipoPagamento
    {
        [ValorEnum("CA")]
        Cartao,
        [ValorEnum("PP")]
        PrePago,
        [ValorEnum("EF")]
        Efetivo,
        [ValorEnum("NU")]
        Nulo
    }
}
