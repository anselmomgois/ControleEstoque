using System;
using System.Collections.Generic;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Empresa
    {

        public string Identificador { get; set; }
        public string Nome { get; set; }
        public int Codigo { get; set; }
        public string Cnpj { get; set; }
        public string InscricaoEstadual { get; set; }
        public string CodAcesso { get; set; }
        public string ChaveAcesso { get; set; }
        public Nullable<Int32> QuantidadeSessoes { get; set; }
        public Nullable<Int32> QuantidadeAcessada { get; set; }
        public Nullable<Int32> QuantidadeAcessos { get; set; }
        public Boolean SessoesIlimitadas { get; set; }
        public Boolean ValidadeIlimitada { get; set; }
        public Boolean EmpresaMestre { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Smtp { get; set; }
        public Nullable<Int32> Porta { get; set; }
        public Boolean Ssl { get; set; }
        public List<Filiais> Filiais { get; set; }
    }
}
