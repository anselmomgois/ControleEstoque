using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Filiais
    {

        public string Identificador { get; set; }
        public string IdentificadorProvisorio { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneFax { get; set; }
        public string TelefoneMovel { get; set; }
        public string Email { get; set; }
        public Estado Endereco { get; set; }
        public Boolean Matriz { get; set; }
        public Comum.Clases.Pessoa Gerente { get; set; }
        public Nullable<DateTime> DataAbertura { get; set; }
        public string Observacao { get; set; }
        public Nullable<Decimal> NumPercentualPis { get; set; }
        public Nullable<Decimal> NumPercentualConfins { get; set; }
        public Nullable<Decimal> NumOutrasDespesas { get; set; }
        public Nullable<Decimal> NumContribuicaoSocialPer { get; set; }
        public Nullable<Int32> CodigoTabelaMercadoria { get; set; }
        public Boolean Ativa { get; set; }
        public Boolean Apagar { get; set; }
    }
}
