using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class GrupoCompromisso
    {

        public string Identificador { get; set; }
        public Int32 Codigo { get; set; }
        public string Descricao { get; set; }
        public Boolean Deletar { get; set; }
        public string IdentificadorProvisorio { get; set; }
        public List<Pergunta> Perguntas { get; set; }
        public List<GrupoCompromisso> SubGrupos { get; set; }

    }
}
