using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.Permissoes.Carregar
{
    public class PeticaoPermissoesCarregar : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFuncionario { get; set; }
        public string IdentificadorGrupo { get; set; }


    }
}
