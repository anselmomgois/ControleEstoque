using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Processo.RegistrarItemProcesso
{
    public class PeticaoRegistrarItemProcesso : PeticaoGenerico
    {

        public string IdentificadorEmpresa { get; set; }
        public Comum.Clases.ItemProcesso ItemProcesso { get; set; }
    }
}