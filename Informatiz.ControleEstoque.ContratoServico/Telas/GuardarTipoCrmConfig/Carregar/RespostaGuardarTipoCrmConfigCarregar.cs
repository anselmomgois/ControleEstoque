using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarTipoCrmConfig.Carregar
{

   public class RespostaGuardarTipoCrmConfigCarregar : RespostaGenerica
    {
        public List<Comum.Clases.Pessoa> Funcionarios { get; set; }
        public List<Comum.Clases.TipoEmpregado> TiposEmpregado { get; set; }
    }
}
