using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Pessoa.TrocarSenhaPessoa
{
    public class PeticaoTrocarSenhaPessoa : PeticaoGenerico
    {

        public string Identificador { get; set; }
        public string Senha { get; set; }
        public Boolean SolicitarTrocarSenha { get; set; }
    }
}