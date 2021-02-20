using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarProdutoPromocao.Carregar
{
    public class PeticaoGuardarProdutoPromocaoCarregar : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da filial é obrigatório.")]
        public string IdentificadorFilial { get; set; }

        public string IdentificadorProdutoPromocao { get; set; }

        public string IdentificadorEmpresa { get; set; }


    }
}
