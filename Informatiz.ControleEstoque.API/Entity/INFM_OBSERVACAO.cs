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
    
    public partial class INFM_OBSERVACAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_OBSERVACAO()
        {
            this.INFM_ITEMVENDAOBSERVACAO = new HashSet<INFM_ITEMVENDAOBSERVACAO>();
            this.INFM_OBSERVACAOPRODUTO = new HashSet<INFM_OBSERVACAOPRODUTO>();
        }
    
        public string IDOBSERVACAO { get; set; }
        public string IDEMPRESA { get; set; }
        public string DESOBSERVACAO { get; set; }
    
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ITEMVENDAOBSERVACAO> INFM_ITEMVENDAOBSERVACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_OBSERVACAOPRODUTO> INFM_OBSERVACAOPRODUTO { get; set; }
    }
}
