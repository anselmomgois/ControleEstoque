using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.GrupoPermissao.RecuperarGrupos
{
    public class PeticaoRecuperarGrupos : PeticaoGenerico
    {

       public string Nome { get; set; }
        public string IdentificadorEmpresa { get; set; }
    }
}