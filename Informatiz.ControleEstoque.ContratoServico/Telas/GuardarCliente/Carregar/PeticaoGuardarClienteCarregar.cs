using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarCliente.Carregar
{ 
     public class PeticaoGuardarClienteCarregar : PeticaoGenerico
    {
              
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public string Usuario { get; set; }
        public string IdentificadorCiente { get; set; }

  
    }
}
