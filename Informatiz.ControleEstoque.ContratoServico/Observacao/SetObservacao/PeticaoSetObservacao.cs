using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Observacao.SetObservacao
{
    public class PeticaoSetObservacao : PeticaoGenerico
    {

       public string IdentificadorEmpresa { get; set; }
        public Comum.Clases.ProdutoObservacao Observacao { get; set; }
    }
}