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
    
    public partial class INFM_PRODUTOSERVICO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_PRODUTOSERVICO()
        {
            this.INFM_ACRESCIMOPRODUTO = new HashSet<INFM_ACRESCIMOPRODUTO>();
            this.INFM_ACRESCIMOPRODUTO1 = new HashSet<INFM_ACRESCIMOPRODUTO>();
            this.INFM_CODIGOBARRASPRODSERV = new HashSet<INFM_CODIGOBARRASPRODSERV>();
            this.INFM_ITEMVENDA = new HashSet<INFM_ITEMVENDA>();
            this.INFM_ITEMVENDAACRESCIMO = new HashSet<INFM_ITEMVENDAACRESCIMO>();
            this.INFM_OBSERVACAOPRODUTO = new HashSet<INFM_OBSERVACAOPRODUTO>();
            this.INFM_PRODUTOFILIAL = new HashSet<INFM_PRODUTOFILIAL>();
            this.INFM_PRODUTOOPCAO = new HashSet<INFM_PRODUTOOPCAO>();
            this.INFM_PRODUTOPROMOCAOPRODF = new HashSet<INFM_PRODUTOPROMOCAOPRODF>();
            this.INFM_UNIDADEMEDPRODUTO = new HashSet<INFM_UNIDADEMEDPRODUTO>();
        }
    
        public string IDPRODUTOSERVICO { get; set; }
        public string IDTIPOPRODUTO { get; set; }
        public string IDGRUPOPRODUTO { get; set; }
        public string IDCOR { get; set; }
        public string IDPRODUTODERIVACAO { get; set; }
        public string IDPRODCATEGORIA { get; set; }
        public string IDPRODUTOMARCA { get; set; }
        public string IDEMPRESA { get; set; }
        public string IDPRODUTONCM { get; set; }
        public string IDPRODUTOCST { get; set; }
        public string IDPRODUTOCFOP { get; set; }
        public int CODPRODUTO { get; set; }
        public string DESPRODUTO { get; set; }
        public string DESCODBARRAS { get; set; }
        public string OBSPRODUTO { get; set; }
        public Nullable<decimal> NUMPESOPRODUTO { get; set; }
        public byte[] BITIMGPRODUTO { get; set; }
        public Nullable<bool> BOLVENDAAGRANEL { get; set; }
        public Nullable<bool> BOLINTERNO { get; set; }
        public Nullable<bool> BOLACRESCIMO { get; set; }
        public Nullable<bool> BOLVENDANUMEROSERIE { get; set; }
        public string IDSETOREMPRESA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ACRESCIMOPRODUTO> INFM_ACRESCIMOPRODUTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ACRESCIMOPRODUTO> INFM_ACRESCIMOPRODUTO1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_CODIGOBARRASPRODSERV> INFM_CODIGOBARRASPRODSERV { get; set; }
        public virtual INFM_COR INFM_COR { get; set; }
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        public virtual INFM_GRUPOPRODUTO INFM_GRUPOPRODUTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ITEMVENDA> INFM_ITEMVENDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ITEMVENDAACRESCIMO> INFM_ITEMVENDAACRESCIMO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_OBSERVACAOPRODUTO> INFM_OBSERVACAOPRODUTO { get; set; }
        public virtual INFM_PRODCATEGORIA INFM_PRODCATEGORIA { get; set; }
        public virtual INFM_PRODUTOCFOP INFM_PRODUTOCFOP { get; set; }
        public virtual INFM_PRODUTOCST INFM_PRODUTOCST { get; set; }
        public virtual INFM_PRODUTODERIVACAO INFM_PRODUTODERIVACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PRODUTOFILIAL> INFM_PRODUTOFILIAL { get; set; }
        public virtual INFM_PRODUTOMARCA INFM_PRODUTOMARCA { get; set; }
        public virtual INFM_PRODUTONCM INFM_PRODUTONCM { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PRODUTOOPCAO> INFM_PRODUTOOPCAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PRODUTOPROMOCAOPRODF> INFM_PRODUTOPROMOCAOPRODF { get; set; }
        public virtual INFM_TIPOPRODUTO INFM_TIPOPRODUTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_UNIDADEMEDPRODUTO> INFM_UNIDADEMEDPRODUTO { get; set; }
        public virtual INFM_SETOREMPRESA INFM_SETOREMPRESA { get; set; }
    }
}