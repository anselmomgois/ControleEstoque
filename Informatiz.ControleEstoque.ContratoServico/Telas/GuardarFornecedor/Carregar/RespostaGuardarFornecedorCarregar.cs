using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarFornecedor.Carregar
{

    public class RespostaGuardarFornecedorCarregar : RespostaGenerica
    {
     
        public List<Comum.Clases.SegmentoComercial> SegmentosComerciais { get; set; }
        public Comum.Clases.Pessoa Fornecedor { get; set; }

    }
}
