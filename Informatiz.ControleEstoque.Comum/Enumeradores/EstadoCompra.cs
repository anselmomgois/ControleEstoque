using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Atributos;

namespace Informatiz.ControleEstoque.Comum.Enumeradores
{
    public enum EstadoCompra
    {
        [ValorEnum("OE")]
        OrdemEmitida,
        [ValorEnum("CF")]
        CompraFinalizada,
        [ValorEnum("CG")]
        CompraGerada
    }
}
