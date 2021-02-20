using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarFuncionario.Carregar
{

   public class RespostaGuardarFuncionarioCarregar : RespostaGenerica
    {
        public List<Comum.Clases.Filiais> Filiais { get; set; }
        
        public List<Comum.Clases.TipoEmpregado> TiposEmpregado { get; set; }

        public Comum.Clases.Pessoa Funcionario { get; set; }
    }
}
