using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Informatiz.ControleEstoque.Comum.Clases
{

   public class Usuario
    {

        public string Identificador { get; set; }
        public int Codigo { get; set; }
        public Boolean Consultor { get; set; }
        public List<Permissao> Permissoes { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public List<Empresa> Empresas { get; set; }
        public Boolean AlterarSenha { get; set; }
        public Empresa EmpresaSelecionada { get; set; }
        public Filiais FilialSelecionada { get; set; }
        public Boolean Supervisor { get; set; }
        public Boolean ResponsavelFinanceiro { get; set; }
        public Boolean Entregador { get; set; }
        public Boolean Gerente { get; set; }
        public string EnderecoEmpresa { get; set; }
    }
}
