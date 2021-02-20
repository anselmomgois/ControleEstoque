using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Permissao.GravarPermissoesUsuario
{
    public class PeticaoGravarPermissoesUsuario : PeticaoGenerico
    {

        public string IdentificadorFuncionario { get; set; }
        public List<Comum.Clases.Permissao> Permissoes { get; set; }
    }
}