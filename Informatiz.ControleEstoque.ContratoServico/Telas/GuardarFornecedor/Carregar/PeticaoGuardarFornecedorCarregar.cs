using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarFornecedor.Carregar
{
    public class PeticaoGuardarFornecedorCarregar : PeticaoGenerico
    {

        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFornecedor { get; set; }
    }
}
