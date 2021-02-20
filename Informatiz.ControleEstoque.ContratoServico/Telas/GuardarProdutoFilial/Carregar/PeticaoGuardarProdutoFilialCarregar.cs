using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarProdutoFilial.Carregar
{
    public class PeticaoGuardarProdutoFilialCarregar : PeticaoGenerico
    {

        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFilial { get; set; }

        public string IdentificadorProdutoServico { get; set; }


    }
}
