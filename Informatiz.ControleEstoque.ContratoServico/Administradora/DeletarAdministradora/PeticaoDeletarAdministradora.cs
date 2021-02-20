using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.Administradora.DeletarAdministradora
{
   public class PeticaoDeletarAdministradora : PeticaoGenerico
    {

        public string IdentificadorAdministradora { get; set; }
        public string Usuario { get; set; }             
      
    }
}
