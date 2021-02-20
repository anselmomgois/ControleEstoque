using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Permissao.GravarGrupoPermissao
{
    public class PeticaoGravarGrupoPermissao : PeticaoGenerico
    {

        public Comum.Clases.GrupoPermissao GrupoPermissao { get; set; }
        public string IdentificadorGrupo { get; set; }
    }
}