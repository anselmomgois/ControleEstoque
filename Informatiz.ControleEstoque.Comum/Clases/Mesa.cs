using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Mesa
    {
        public string Identificador { get; set; }
        public string Codigo { get; set; }
        public Int32 QuantidadeLugar { get; set; }
        public Comum.Enumeradores.EstadoMesa Estado { get; set; }
        public Boolean Ativa { get; set; }
        public List<MesaProxima> MesasProximas { get; set; }
    }
}
