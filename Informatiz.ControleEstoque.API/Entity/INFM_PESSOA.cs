//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Informatiz.ControleEstoque.API.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class INFM_PESSOA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_PESSOA()
        {
            this.INFM_CODIGOBARRASPESSOA = new HashSet<INFM_CODIGOBARRASPESSOA>();
            this.INFM_COMPRA = new HashSet<INFM_COMPRA>();
            this.INFM_CRM = new HashSet<INFM_CRM>();
            this.INFM_CRM1 = new HashSet<INFM_CRM>();
            this.INFM_DOCUMENTO = new HashSet<INFM_DOCUMENTO>();
            this.INFM_EMPRESA = new HashSet<INFM_EMPRESA>();
            this.INFM_FILIAL = new HashSet<INFM_FILIAL>();
            this.INFM_FILIALPESSOA = new HashSet<INFM_FILIALPESSOA>();
            this.INFM_HORATRABALHO = new HashSet<INFM_HORATRABALHO>();
            this.INFM_ITEMVENDA = new HashSet<INFM_ITEMVENDA>();
            this.INFM_ITEMVENDA1 = new HashSet<INFM_ITEMVENDA>();
            this.INFM_PESSOACRMPESSOA = new HashSet<INFM_PESSOACRMPESSOA>();
            this.INFM_PESSOA1 = new HashSet<INFM_PESSOA>();
            this.INFM_PESSOAMESA = new HashSet<INFM_PESSOAMESA>();
            this.INFM_PROPOSTA = new HashSet<INFM_PROPOSTA>();
            this.INFM_PROPOSTA1 = new HashSet<INFM_PROPOSTA>();
            this.INFM_RESPONSAVELCAIXA = new HashSet<INFM_RESPONSAVELCAIXA>();
            this.INFM_SALDOPESSOA = new HashSet<INFM_SALDOPESSOA>();
            this.INFM_SANGRIA = new HashSet<INFM_SANGRIA>();
            this.INFM_SESSAO = new HashSet<INFM_SESSAO>();
            this.INFM_SUPRIMENTO = new HashSet<INFM_SUPRIMENTO>();
            this.INFM_TIPOPESSOA_PESSOA = new HashSet<INFM_TIPOPESSOA_PESSOA>();
            this.INFM_TIPOCRMCONFIGPESSOA = new HashSet<INFM_TIPOCRMCONFIGPESSOA>();
            this.INFM_USUPERMISSAOACAO = new HashSet<INFM_USUPERMISSAOACAO>();
            this.INFM_VENDA = new HashSet<INFM_VENDA>();
            this.INFM_VENDA1 = new HashSet<INFM_VENDA>();
            this.INFM_VENDA2 = new HashSet<INFM_VENDA>();
            this.INFM_VALORFECHAMENTO = new HashSet<INFM_VALORFECHAMENTO>();
            this.INFM_VENDA21 = new HashSet<INFM_VENDA>();
        }
    
        public string IDENDERECO { get; set; }
        public string IDPESSOA { get; set; }
        public string IDSITUACAOPESSOA { get; set; }
        public string IDPESSOARESPONSAVEL { get; set; }
        public string IDSEGMENTOCOMERCIAL { get; set; }
        public string IDENDERECOEMPRESA { get; set; }
        public string IDEMPRESA { get; set; }
        public int CODPESSOA { get; set; }
        public string DESNOME { get; set; }
        public string DESNOMEFANTASIA { get; set; }
        public string DESRG { get; set; }
        public Nullable<System.DateTime> DTHNASCIMENTO { get; set; }
        public string DESCPF { get; set; }
        public string DESCNPJ { get; set; }
        public Nullable<System.DateTime> DTHCADASTRO { get; set; }
        public string DESINSCRICAOESTADUAL { get; set; }
        public string DESTELEFONEFIXO { get; set; }
        public string DESTELEFONEFAX { get; set; }
        public string DESTELEFONECELULAR { get; set; }
        public string DESHABILITACAO { get; set; }
        public Nullable<decimal> NUMCOMISSAO { get; set; }
        public Nullable<decimal> NUMSALARIO { get; set; }
        public Nullable<System.DateTime> DTHADMISSAO { get; set; }
        public string DESCONTATO { get; set; }
        public string OBSPESSOA { get; set; }
        public Nullable<decimal> NUMLIMITE { get; set; }
        public string DESEMAIL { get; set; }
        public string DESNOMEPAI { get; set; }
        public string DESNOMEMAE { get; set; }
        public string DESEMPRESA { get; set; }
        public string DESFONEEMPRESA { get; set; }
        public string DESCARGO { get; set; }
        public string OBSREFPESSOAL { get; set; }
        public string DTHALMOCOINICIO { get; set; }
        public string DTHALMOCOFIM { get; set; }
        public string CODLOGIN { get; set; }
        public string DESSENHA { get; set; }
        public Nullable<int> CODTABMERCADORIA { get; set; }
        public bool BOLALTERARSENHA { get; set; }
        public Nullable<bool> BOLFUNICIONARIOATIVO { get; set; }
        public bool BOLFORNECEDORATIVO { get; set; }
        public Nullable<int> NUMENDERECO { get; set; }
        public string DESCOMPLEMENTOENDER { get; set; }
        public string DESPONTOREFERENCIA { get; set; }
        public Nullable<int> CODTABELAMERCADORIA { get; set; }
        public Nullable<int> NUMENDERECOEMP { get; set; }
        public string DESCOMPLEMENTOENDEREMP { get; set; }
        public string DESPONTOREFERENCIAEMP { get; set; }
        public Nullable<bool> BOLCONSULTOR { get; set; }
        public string IDTIPOEMPREGADO { get; set; }
        public Nullable<bool> BOLPERMITEVENDAPRAZO { get; set; }
        public string DESSENHATOUCH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_CODIGOBARRASPESSOA> INFM_CODIGOBARRASPESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_COMPRA> INFM_COMPRA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_CRM> INFM_CRM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_CRM> INFM_CRM1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_DOCUMENTO> INFM_DOCUMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_EMPRESA> INFM_EMPRESA { get; set; }
        public virtual INFM_EMPRESA INFM_EMPRESA1 { get; set; }
        public virtual INFM_ENDERECO INFM_ENDERECO { get; set; }
        public virtual INFM_ENDERECO INFM_ENDERECO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_FILIAL> INFM_FILIAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_FILIALPESSOA> INFM_FILIALPESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_HORATRABALHO> INFM_HORATRABALHO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ITEMVENDA> INFM_ITEMVENDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ITEMVENDA> INFM_ITEMVENDA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PESSOACRMPESSOA> INFM_PESSOACRMPESSOA { get; set; }
        public virtual INFM_TIPOEMPREGADO INFM_TIPOEMPREGADO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PESSOA> INFM_PESSOA1 { get; set; }
        public virtual INFM_PESSOA INFM_PESSOA2 { get; set; }
        public virtual INFM_SEGMENTOCOMERCIAL INFM_SEGMENTOCOMERCIAL { get; set; }
        public virtual INFM_SITUACAO_PESSOA INFM_SITUACAO_PESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PESSOAMESA> INFM_PESSOAMESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PROPOSTA> INFM_PROPOSTA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PROPOSTA> INFM_PROPOSTA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_RESPONSAVELCAIXA> INFM_RESPONSAVELCAIXA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_SALDOPESSOA> INFM_SALDOPESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_SANGRIA> INFM_SANGRIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_SESSAO> INFM_SESSAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_SUPRIMENTO> INFM_SUPRIMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_TIPOPESSOA_PESSOA> INFM_TIPOPESSOA_PESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_TIPOCRMCONFIGPESSOA> INFM_TIPOCRMCONFIGPESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_USUPERMISSAOACAO> INFM_USUPERMISSAOACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_VENDA> INFM_VENDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_VENDA> INFM_VENDA1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_VENDA> INFM_VENDA2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_VALORFECHAMENTO> INFM_VALORFECHAMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_VENDA> INFM_VENDA21 { get; set; }
    }
}
