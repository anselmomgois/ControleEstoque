using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Informatiz.ControleEstoque.Comum.Atributos;

namespace Informatiz.ControleEstoque.Comum.Enumeradores
{
    public class Enumeradores
    {

        public enum TipoPessoaEnum
        {
            [ValorEnum("1")]
            FUNCIONARIO = 1,
            [ValorEnum("2")]
            CLIENTE = 2,
            [ValorEnum("3")]
            FORNECEDOR = 3,
            [ValorEnum("4")]
            PERMISSAO = 4
        }

        public enum TipoHelper
        {
            CIDADE = 1,
            BAIRRO = 2,
            ENDERECO = 3,
            CLIENTE = 4,
            FUNCIONARIO = 5,
            FORNECEDOR = 6

        }

        public enum CodigoDiaSemana
        {
            DOMINGO = 1,
            SEGUNDA = 2,
            TERCA = 3,
            QUARTA = 4,
            QUINTA = 5,
            SEXTA = 6,
            SABADO = 7
        }

        public enum TipoAcao
        {
            INSERIR = 1,
            MODIFICAR = 2,
            CONSULTAR = 3,
            EXCLUIR = 4
        }

        public enum TipoComponente
        {
            TEXTBOX = 1,
            COMBOBOX = 2,
            CHECKBOX = 3,
            SIMONAO = 4,
            NUMERICO = 5
        }

        public enum TipoCodigoBarras
        {
            [ValorEnum("4POSICOES")]
            QUATRO_POSICOES,
            [ValorEnum("5POSICOES")]
            CINCO_POSICOES,
            [ValorEnum("6POSICOES")]
            SEIS_POSICOES
        }

        public enum TipoEmpregado
        {
            SUPERVISOR = 1,
            RESPFINANCEIRO = 2,
            ENTREGADOR = 3,
            GERENTE = 4
        }

        public enum DiasSemana
        {
            Domingo = 0,
            Segunda = 1,
            Terça = 2,
            Quarta = 3,
            Quinta = 4,
            Sexta = 5,
            Sábado = 6
        }

        public enum TipoSaldoCaixa
        {
            Sangria = 1,
            Suprimento = 2
        }

    }
}
