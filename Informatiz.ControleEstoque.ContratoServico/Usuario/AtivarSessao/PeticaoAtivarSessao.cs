using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.ContratoServico.Usuario.AtivarSessao
{
    public class PeticaoAtivarSessao : PeticaoGenerico
    {

        public  string IdentificadorEmpresa {get;set;}
        public string IdentificadorFilial {get;set;}
        public string IdentificadorPessoa {get;set;}
        public Nullable<Int32> QuantidadeSessoes {get;set;}
        public Boolean SessoesIlimitadas { get; set; }     
                    
    }
}
