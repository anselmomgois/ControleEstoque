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
    
    public partial class INFM_ADMINISTRADORA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_ADMINISTRADORA()
        {
            this.INFM_DOCUMENTO = new HashSet<INFM_DOCUMENTO>();
        }
    
        public string IDADMINISTRADORA { get; set; }
        public string IDEMPRESA { get; set; }
        public int CODADMINISTRADORA { get; set; }
        public string DESADMINISTRADORA { get; set; }
        public string DESTELADMINISTRADORA { get; set; }
        public string OBSREFADMINISTRADORA { get; set; }
        public Nullable<decimal> NUMTARIFAPERCENT { get; set; }
        public Nullable<decimal> NUMTARIFAVALOR { get; set; }
        public Nullable<decimal> NUMTARIFAANTPERCENT { get; set; }
        public Nullable<decimal> NUMTARIFAANTVALOR { get; set; }
        public Nullable<decimal> NUMDESCONTPERCENT { get; set; }
        public Nullable<decimal> NUMDESCONTVALOR { get; set; }
        public byte[] BITIMGADMINISTRADORA { get; set; }
    
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_DOCUMENTO> INFM_DOCUMENTO { get; set; }
    }
}