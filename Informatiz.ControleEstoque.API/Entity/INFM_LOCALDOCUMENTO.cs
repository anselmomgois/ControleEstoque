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
    
    public partial class INFM_LOCALDOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_LOCALDOCUMENTO()
        {
            this.INFM_DOCUMENTO = new HashSet<INFM_DOCUMENTO>();
        }
    
        public string IDLOCALDOCUMENTO { get; set; }
        public string CODLOCALDOCUMENTO { get; set; }
        public string DESLOCALDOCUMENTO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_DOCUMENTO> INFM_DOCUMENTO { get; set; }
    }
}
