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
    
    public partial class INFM_PRODUTOMARCA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_PRODUTOMARCA()
        {
            this.INFM_PRODUTOSERVICO = new HashSet<INFM_PRODUTOSERVICO>();
        }
    
        public string IDPRODUTOMARCA { get; set; }
        public string IDEMPRESA { get; set; }
        public int CODPRODUTOMARCA { get; set; }
        public string DESPRODUTOMARCA { get; set; }
    
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PRODUTOSERVICO> INFM_PRODUTOSERVICO { get; set; }
    }
}
