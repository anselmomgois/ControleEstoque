using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarEmpresa.Carregar
{

   public class RespostaGuardarEmpresaCarregar : RespostaGenerica
    {
        public Comum.Clases.Empresa Empresa { get; set; }
        
    }
}
