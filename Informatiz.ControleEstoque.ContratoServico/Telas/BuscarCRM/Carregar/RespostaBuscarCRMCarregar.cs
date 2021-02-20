using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.BuscarCRM.Carregar
{

    public class RespostaBuscarCRMCarregar : RespostaGenerica
    {
        public List<Comum.Clases.StatusCrmAgrupador> StatusAgrupador { get; set; }
        public List<Comum.Clases.Pessoa> Clientes { get; set; }
        public List<Comum.Clases.Pessoa> Funcionarios { get; set; }
    }
}
