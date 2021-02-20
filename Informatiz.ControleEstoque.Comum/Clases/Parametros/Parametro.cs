using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
   public class Parametro
    {
        public string Identificador;
        public string Codigo;
        public string Descricao;
        public Comum.Enumeradores.Enumeradores.TipoComponente TipoComponente;
        public Boolean NivelFilial;
        public string DesValor;
        public List<ValorPossivel> ValoresPossiveis;

    }
}
