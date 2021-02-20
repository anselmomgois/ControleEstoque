using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarCompra.Carregar
{

    public class RespostaGuardarCompraCarregar : RespostaGenerica
    {
        public List<Comum.Clases.Filiais> Filiais { get; set; }
        public Comum.Clases.Compra Compra { get; set; }
        public List<Comum.Clases.UnidadeMedida> UnidadesMedidas { get; set; }
        public string NumeroCompra { get; set; }
    }
}

