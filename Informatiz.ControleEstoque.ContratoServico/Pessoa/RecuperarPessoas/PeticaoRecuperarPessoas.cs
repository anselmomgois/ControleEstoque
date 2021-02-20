using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.Pessoa.RecuperarPessoas
{
     public class PeticaoRecuperarPessoas : PeticaoGenerico
    {

        public Int32 Codigo { get; set; }

        public string Descricao { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        [Required(ErrorMessage = "O usuário é obrigatório.")]
        public string Usuario { get; set; }

        public string Cpf { get; set; }
        public string Cnpj { get; set; }
        public string Login { get; set; }
        public Nullable<Boolean> FuncionarioAtivo { get; set; }
        public   Comum.Enumeradores.Enumeradores.TipoPessoaEnum TipoPessoa { get; set; }
    }
}
