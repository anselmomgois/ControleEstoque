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
    
    public partial class INFM_CAIXA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_CAIXA()
        {
            this.INFM_RESPONSAVELCAIXA = new HashSet<INFM_RESPONSAVELCAIXA>();
        }
    
        public string IDCAIXA { get; set; }
        public string IDEMPRESA { get; set; }
        public string IDFILIAL { get; set; }
        public bool BOLABERTO { get; set; }
        public int CODCAIXA { get; set; }
        public string DESHOST { get; set; }
    
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        public virtual INFM_EMPRESA INFM_EMPRESA1 { get; set; }
        public virtual INFM_FILIAL INFM_FILIAL { get; set; }
        public virtual INFM_FILIAL INFM_FILIAL1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_RESPONSAVELCAIXA> INFM_RESPONSAVELCAIXA { get; set; }
    }
}
