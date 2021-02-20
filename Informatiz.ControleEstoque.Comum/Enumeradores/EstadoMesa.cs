using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Atributos;

namespace Informatiz.ControleEstoque.Comum.Enumeradores
{
    public enum EstadoMesa
    {
        [ValorEnum("LI")]
        Livre,
        [ValorEnum("OC")]
        Ocupada,
        [ValorEnum("AL")]
        AguardandoLimpeza,
        [ValorEnum("RE")]
        Reservada
    }
}
