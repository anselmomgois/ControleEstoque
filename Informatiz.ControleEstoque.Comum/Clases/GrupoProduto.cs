using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class GrupoProduto
    {
        public string Identificador { get; set; }
        public Boolean Deletar { get; set; }
        public string IdentificadorProvisorio { get; set; }
        public string Descricao { get; set; }
        public Int32 Codigo { get; set; }
        public List<GrupoProduto> SubGrupos { get; set; }

    }
}
