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
    
    public partial class INFM_ACAO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_ACAO()
        {
            this.INFM_GRUPOPERMISSAOACAO = new HashSet<INFM_GRUPOPERMISSAOACAO>();
            this.INFM_PERMISSAOACAO = new HashSet<INFM_PERMISSAOACAO>();
            this.INFM_USUPERMISSAOACAO = new HashSet<INFM_USUPERMISSAOACAO>();
        }
    
        public string IDACAO { get; set; }
        public string CODACAO { get; set; }
        public string DESACAO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_GRUPOPERMISSAOACAO> INFM_GRUPOPERMISSAOACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PERMISSAOACAO> INFM_PERMISSAOACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_USUPERMISSAOACAO> INFM_USUPERMISSAOACAO { get; set; }
    }
}
