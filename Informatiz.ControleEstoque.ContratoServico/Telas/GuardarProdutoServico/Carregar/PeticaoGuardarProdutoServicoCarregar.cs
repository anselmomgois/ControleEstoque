using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarProdutoServico.Carregar
{
    public class PeticaoGuardarProdutoServicoCarregar : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorProdutoServico { get; set; }


    }
}
