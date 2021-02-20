using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Informatiz.ControleEstoque.Comum.Atributos;

namespace Informatiz.ControleEstoque.Comum.Enumeradores
{
    public enum TipoIntegracao
    {
        [ValorEnum("0800")]
        ZERO800,
        [ValorEnum("SMS")]
        SMS,
        [ValorEnum("SHORT")]
        SHORT,
        [ValorEnum("SHORT2")]
        SHORT2
    }
}
