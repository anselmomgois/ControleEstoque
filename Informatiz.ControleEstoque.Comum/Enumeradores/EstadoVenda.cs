using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Atributos;

namespace Informatiz.ControleEstoque.Comum.Enumeradores
{
    public enum EstadoVenda
    {
        [ValorEnum("EC")]
        EmCurso,
        [ValorEnum("FI")]
        Finalizada,
        [ValorEnum("CA")]
        Cancelada
    }
}
