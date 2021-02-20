using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarMesa.Carregar
{ 
     public class PeticaoGuardarMesaCarregar : PeticaoGenerico
    {
              
        [Required(ErrorMessage = "O identificador da filial é obrigatório.")]
        public string IdentificadorFilial { get; set; }
        public string IdentificadorMesa { get; set; }
     
    }
}
