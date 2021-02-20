using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.IntegracaoAPI.BuscaIntegracoesAPI
{
    public class PeticaoBuscaIntegracoesAPI : PeticaoGenerico
    {

       public string IdentificadorEmpresa { get; set; }
    }
}