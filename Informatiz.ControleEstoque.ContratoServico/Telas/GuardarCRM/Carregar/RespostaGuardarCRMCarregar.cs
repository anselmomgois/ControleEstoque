using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarCRM.Carregar
{

   public class RespostaGuardarCRMCarregar : RespostaGenerica
    {
        public List<Comum.Clases.StatusCrmAgrupador> StatusCRMAgrupador { get; set; }
        public List<Comum.Clases.Pessoa> Funcionarios { get; set; }
        public List<Comum.Clases.TipoCrm> TiposCrm { get; set; }
        public Comum.Clases.CRM CRM { get; set; }
    }
}
