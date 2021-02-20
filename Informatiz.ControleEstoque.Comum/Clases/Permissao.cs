using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Permissao
    {
        public string Identificador { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string IdentificadorGrupoPermissao { get; set; }
        public Boolean Obrigatoria { get; set; }
        public List<Acao> Acoes { get; set; }

    }
}
