using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Telas.GuardarFuncionario.Carregar
{
    public class PeticaoGuardarFuncionarioCarregar : PeticaoGenerico
    {

        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public string IdentificadorFuncionario { get; set; }


    }
}
