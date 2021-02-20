using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.Administradora.InserirAdministradora
{
    public class PeticaoInserirAdministradora : PeticaoGenerico
    {

        public Comum.Clases.Administradora Administradora { get; set; }
        public string IdentificadorEmpresa { get; set; }      
      
    }
}
