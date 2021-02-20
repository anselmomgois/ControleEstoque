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
    
    public partial class INFM_RESPONSAVELCAIXA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_RESPONSAVELCAIXA()
        {
            this.INFM_SANGRIA = new HashSet<INFM_SANGRIA>();
            this.INFM_SUPRIMENTO = new HashSet<INFM_SUPRIMENTO>();
            this.INFM_VENDA = new HashSet<INFM_VENDA>();
            this.INFM_VALORFECHAMENTO = new HashSet<INFM_VALORFECHAMENTO>();
            this.INFM_PAGAMENTO = new HashSet<INFM_PAGAMENTO>();
        }
    
        public string IDRESPONSAVELCAIXA { get; set; }
        public string IDCAIXA { get; set; }
        public string IDPESSOARESPONSAVEL { get; set; }
        public decimal NUMVALORINICIAL { get; set; }
        public decimal NUMSALDO { get; set; }
        public System.DateTime DTHINICIOOPERACAO { get; set; }
        public Nullable<System.DateTime> DTHFIMOPERACAO { get; set; }
    
        public virtual INFM_CAIXA INFM_CAIXA { get; set; }
        public virtual INFM_PESSOA INFM_PESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_SANGRIA> INFM_SANGRIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_SUPRIMENTO> INFM_SUPRIMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_VENDA> INFM_VENDA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_VALORFECHAMENTO> INFM_VALORFECHAMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PAGAMENTO> INFM_PAGAMENTO { get; set; }
    }
}