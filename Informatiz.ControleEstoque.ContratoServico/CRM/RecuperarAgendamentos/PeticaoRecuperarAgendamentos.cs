using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Informatiz.ControleEstoque.ContratoServico.CRM.RecuperarAgendamentos
{
    public class PeticaoRecuperarAgendamentos : PeticaoGenerico
    {

        public string Descricao { get; set; }
        public string IdentificadorFuncionarioCadastro { get; set; }
        public List<string> IdentificadoresFuncionariosResponsaveis { get; set; }
        public string IdentificadorCliente { get; set; }
        [Required(ErrorMessage = "O identificador da empresa é obrigatório.")]
        public string IdentificadorEmpresa { get; set; }
        public Nullable<DateTime> DataInicio { get; set; }
        public Nullable<DateTime> DataFim { get; set; }
        public Nullable<Boolean> Ativo { get; set; }
        public Boolean ValidacoesExpecificas { get; set; }
   
    }
}
