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
    
    public partial class INFM_MESA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_MESA()
        {
            this.INFM_MESAAGRUPAR = new HashSet<INFM_MESAAGRUPAR>();
            this.INFM_MESAAGRUPAR1 = new HashSet<INFM_MESAAGRUPAR>();
            this.INFM_MESAVENDA = new HashSet<INFM_MESAVENDA>();
            this.INFM_PESSOAMESAXMESA = new HashSet<INFM_PESSOAMESAXMESA>();
        }
    
        public string IDMESA { get; set; }
        public string IDFILIAL { get; set; }
        public string CODMESA { get; set; }
        public int NELQUANTIDADELUGAR { get; set; }
        public string CODESTADO { get; set; }
        public bool BOLATIVA { get; set; }
    
        public virtual INFM_FILIAL INFM_FILIAL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_MESAAGRUPAR> INFM_MESAAGRUPAR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_MESAAGRUPAR> INFM_MESAAGRUPAR1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_MESAVENDA> INFM_MESAVENDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PESSOAMESAXMESA> INFM_PESSOAMESAXMESA { get; set; }
    }
}
