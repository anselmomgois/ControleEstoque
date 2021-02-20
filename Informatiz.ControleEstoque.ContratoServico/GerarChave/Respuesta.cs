using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.GerarChave
{
    [Serializable]
    [XmlType(Namespace = "urn:GerarChave")]
    [XmlRoot(Namespace = "urn:GerarChave")]
    public class Respuesta : RespostaGenerica
    {

        public string ChaveGerada;
        
    }
}
