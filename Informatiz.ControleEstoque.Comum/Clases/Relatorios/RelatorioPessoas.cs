using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases.Relatorios
{
    [Serializable]
   public class RelatorioPessoas
    {

        public string Nome;
        public string Email;
        public string Endereco;
        public Nullable<Int32> Numero;
        public string Bairro;
        public string Cidade;
        public string Estado;
        public string RG;
        public string CPF;
        public string CNPJ;
        public string TelefoneCelular;
        public string TelefoneFixo;
        public string Fax;
        public string EmpresaTrabalha;
        public string Cargo;
        public Nullable<decimal> Salario;
        public Nullable<decimal> Comissao;
        public Nullable<DateTime> DataAdmissao;
        public string NomeFantasia;
        public Nullable<DateTime> DataNascimento;
        public Nullable<decimal> LimiteCredito;
        public string SituacaoCliente;
        public string SegmentoComercial;
        public Boolean FuncionarioAtivo;
        public Boolean FornecedorAtivo;
        public string Usuario;
        public string CEP;

    }
}
