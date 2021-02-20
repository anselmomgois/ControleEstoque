using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarProdutoFilial.Carregar
{

   public class RespostaGuardarProdutoFilialCarregar : RespostaGenerica
    {
        public Comum.Clases.ProdutoServico ProdutoServico { get; set; }
        public Comum.Clases.ProdutoFilial ProdutoFilial { get; set; }
        public List<Comum.Clases.ProdutoComissao> Comissoes { get; set; }
        public List<Comum.Clases.UnidadeMedida> UnidadesMedida { get; set; }
        public List<Comum.Clases.SetorEmpresa> SetoresEmpresa { get; set; }

    }
}
