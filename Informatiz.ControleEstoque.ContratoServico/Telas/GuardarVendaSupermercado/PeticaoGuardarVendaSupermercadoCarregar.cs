using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarVendaSupermercado.Carregar
{
    public class PeticaoGuardarVendaSupermercadoCarregar : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O identificador da filial é obrigatório.")]
        public string IdentificadorFilial { get; set; }
        public bool RecuperarImagensProduto { get; set; }
        public DateTime DataAtual { get; set; }
        [Required(ErrorMessage = "O identificador responsável caixa obrigatório.")]
        public string IdentificadorResponsavelCaixa { get; set; }

    }
}
