using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoCompromisso.RecuperarGrupoCompromisso
{

   public class RespostaRecuperarGrupoCompromisso : RespostaGenerica
    {
        public Comum.Clases.GrupoCompromisso GrupoCompromisso { get; set; }
    }
}
