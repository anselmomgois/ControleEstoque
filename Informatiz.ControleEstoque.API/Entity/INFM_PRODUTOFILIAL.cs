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
    
    public partial class INFM_PRODUTOFILIAL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_PRODUTOFILIAL()
        {
            this.INFM_DATOSCOMPRAPROD = new HashSet<INFM_DATOSCOMPRAPROD>();
            this.INFM_PRODUTOVALORDINAMICO = new HashSet<INFM_PRODUTOVALORDINAMICO>();
            this.INFM_PRODUTOVALORDINAMICO1 = new HashSet<INFM_PRODUTOVALORDINAMICO>();
            this.INFM_PRODUTOPROMOCAOPRODF = new HashSet<INFM_PRODUTOPROMOCAOPRODF>();
        }
    
        public string IDPRODUTOFILIAL { get; set; }
        public string IDPRODUTOSERVICO { get; set; }
        public string IDFILIAL { get; set; }
        public string IDPRODUTOCOMISSAO { get; set; }
        public string IDUNIDADEMEDIDAESTOQUE { get; set; }
        public string IDUNIDADEMEDIDAVENDA { get; set; }
        public string DESPRATELEIRA { get; set; }
        public Nullable<decimal> NUMESTOQUEMINIMO { get; set; }
        public Nullable<decimal> NUMMINIMOVENDA { get; set; }
        public Nullable<decimal> NUMIPIPER { get; set; }
        public Nullable<decimal> NUMEMBALAGEMPER { get; set; }
        public Nullable<decimal> NUMFRETEPER { get; set; }
        public Nullable<decimal> NUMOUTDESPPER { get; set; }
        public string IDPRODUTOOPCAO { get; set; }
        public Nullable<decimal> NUMESTOQUE { get; set; }
        public string IDUNIDADEMEDIDAMINESTOQUE { get; set; }
        public string IDUMVALORVENDAVAREJO { get; set; }
        public string IDUMVENDAATACADO { get; set; }
        public string IDUMVALORVENATACADO { get; set; }
        public Nullable<decimal> NUMVALORVENDAVAREJO { get; set; }
        public Nullable<decimal> NUMVALORVENDAATACADO { get; set; }
        public Nullable<int> NUMQUANTVENDAATACADO { get; set; }
        public Nullable<decimal> NUMPERCENTDESCONTATAC { get; set; }
        public string IDSETOREMPRESA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_DATOSCOMPRAPROD> INFM_DATOSCOMPRAPROD { get; set; }
        public virtual INFM_FILIAL INFM_FILIAL { get; set; }
        public virtual INFM_PRODUTOCOMISSAO INFM_PRODUTOCOMISSAO { get; set; }
        public virtual INFM_PRODUTOSERVICO INFM_PRODUTOSERVICO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PRODUTOVALORDINAMICO> INFM_PRODUTOVALORDINAMICO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PRODUTOVALORDINAMICO> INFM_PRODUTOVALORDINAMICO1 { get; set; }
        public virtual INFM_PRODUTOOPCAO INFM_PRODUTOOPCAO { get; set; }
        public virtual INFM_UNIDADEMEDIDA INFM_UNIDADEMEDIDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PRODUTOPROMOCAOPRODF> INFM_PRODUTOPROMOCAOPRODF { get; set; }
        public virtual INFM_UNIDADEMEDIDA INFM_UNIDADEMEDIDA1 { get; set; }
        public virtual INFM_UNIDADEMEDIDA INFM_UNIDADEMEDIDA2 { get; set; }
        public virtual INFM_SETOREMPRESA INFM_SETOREMPRESA { get; set; }
    }
}
