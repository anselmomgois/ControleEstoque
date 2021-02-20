using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.Usuario.DeletarSessao
{
     public class PeticaoDeletarSessao : PeticaoGenerico
    {

        public string Usuario { get; set; }
        public string IdentificadorSessao { get; set; }
                    
    }
}
