using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Geral
    {
        public string Identificador { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string CodigoDescricao
        {
            get
            {
                return string.Format("{0} - {1}", Codigo, Descricao);
            }
        }
    }
}
