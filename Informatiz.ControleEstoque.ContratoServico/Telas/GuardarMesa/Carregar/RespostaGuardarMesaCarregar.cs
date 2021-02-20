using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarMesa.Carregar
{

   public class RespostaGuardarMesaCarregar : RespostaGenerica
    {
        public Comum.Clases.Mesa Mesa { get; set; }
        public List<Comum.Clases.MesaProxima> Mesas { get; set; }
        
    }
}
