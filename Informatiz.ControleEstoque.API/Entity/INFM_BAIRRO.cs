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
    
    public partial class INFM_BAIRRO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_BAIRRO()
        {
            this.INFM_ENDERECO = new HashSet<INFM_ENDERECO>();
            this.INFM_FILIALBAIRRO = new HashSet<INFM_FILIALBAIRRO>();
        }
    
        public string IDBAIRRO { get; set; }
        public string IDCIDADE { get; set; }
        public string DESBAIRRO { get; set; }
        public int CODBAIRRO { get; set; }
        public Nullable<decimal> NUMTAXAENTREGA { get; set; }
    
        public virtual INFM_CIDADE INFM_CIDADE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ENDERECO> INFM_ENDERECO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_FILIALBAIRRO> INFM_FILIALBAIRRO { get; set; }
    }
}