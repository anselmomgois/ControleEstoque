using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoPermissao.RecuperarGrupos
{

   public class RespostaRecuperarGrupos : RespostaGenerica
    {
        public List<Comum.Clases.GrupoPermissao> GruposPermissoes { get; set; }
    }
}
