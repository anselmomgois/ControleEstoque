using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoCompromisso.RecuperarGruposCompromisso
{
     public class PeticaoRecuperarGruposCompromisso : PeticaoGenerico
    {

        public string Descricao { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public string Usuario { get; set; }
        public string IdentificadorGrupoCompromisso { get; set; }
        public Boolean Ordenar { get; set; }
        public Boolean RecuperarSubGrupos { get; set; }
        public Boolean RecuperarPerguntas { get; set; }
    }
}
