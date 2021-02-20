using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.AtivarChave
{
    [Serializable]
    [XmlType(Namespace = "urn:AtivarChave")]
    [XmlRoot(Namespace = "urn:AtivarChave")]
    public class Respuesta : RespostaGenerica
    {

        public Comum.Clases.Chave ChaveAcesso;

    }
}
