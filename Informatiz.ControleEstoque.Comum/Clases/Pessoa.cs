using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Informatiz.ControleEstoque.Comum.Clases
{
    public class Pessoa
    {

        public string Identificador { get; set; }
        public int Codigo { get; set; }
        public string NomeCodigo
        {
            get
            {
                return string.Format("{0} - {1}", Codigo, DesNome);
            }
        }
        public string DesNome { get; set; }
        public string Usuario { get; set; }
        public string DesNomeFantasia { get; set; }
        public string cpf { get; set; }
        public string cnpj { get; set; }
        public string RG { get; set; }
        public string InscricaoEstadual { get; set; }
        public string DesContato { get; set; }
        public Comum.Clases.TipoEmpregado TipoEmpregado { get; set; }
        public Comum.Clases.Endereco Endereco { get; set; }
        public Comum.Clases.Estado EnderecoCompleto { get; set; }
        public Comum.Clases.Pessoa PessoaResponsavel { get; set; }
        public Comum.Clases.SegmentoComercial SegmentoComercial { get; set; }
        public Comum.Clases.Endereco EnderecoEmpresa { get; set; }
        public Comum.Clases.Empresa Empresa { get; set; }
        public string DesPontoReferencia { get; set; }
        public Int32 NumeroEndereco { get; set; }
        public string DesComplemento { get; set; }
        public Nullable<DateTime> DataNascimento { get; set; }
        public string DesCarteiraHabilitacao { get; set; }
        public Nullable<decimal> NumSalario { get; set; }
        public Nullable<decimal> NumComissao { get; set; }
        public Nullable<decimal> NumLimite { get; set; }
        public Boolean FuncionarioAtivo { get; set; }
        public Boolean FornecedorAtivo { get; set; }
        public Boolean Consultor { get; set; }
        public Nullable<DateTime> DataAdmissao { get; set; }
        public string DesTelefoneFixo { get; set; }
        public string DesTelefoneCelular { get; set; }
        public string DesTelefoneFax { get; set; }
        public string DesEmpresaAnterior { get; set; }
        public string DesTelefoneEmpresaAnterior { get; set; }
        public string DesEmail { get; set; }
        public string DesNomePai { get; set; }
        public string DesNomeMae { get; set; }
        public string Observacao { get; set; }
        public string ObservacaoRefPessoa { get; set; }
        public string DesCargo { get; set; }
        public string DesSenha { get; set; }
        public string DesConfirmarSenha { get; set; }
        public string DesSenhaTouch { get; set; }
        public string DesHoraAlmocoInicio { get; set; }
        public string DesHoraAlmocoFim { get; set; }
        public Nullable<Int32> NumeroTabelaMercadoria { get; set; }
        public Int32 TabelaVendas { get; set; }
        public List<Comum.Clases.Filiais> Filiais { get; set; }
        public List<TipoPessoa> TiposPessoa { get; set; }
        public List<HorarioTrabalho> HorarioTrabalho { get; set; }
        public SituacaoPessoa SituacaoPessoa { get; set; }
        public Comum.Clases.Estado EnderecoCompletoEmpresa { get; set; }

    }
}
