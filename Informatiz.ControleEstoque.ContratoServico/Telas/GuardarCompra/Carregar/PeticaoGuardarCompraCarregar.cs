using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarCompra.Carregar
{
    public class PeticaoGuardarCompraCarregar : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorCompra { get; set; }


    }
}
