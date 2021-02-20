using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Observacao.BuscarObservacao
{
    public class PeticaoBuscarObservacao : PeticaoGenerico
    {

        public string IdentificadorEmpresa { get; set; }
        public string Descricao { get; set; }
    }
}