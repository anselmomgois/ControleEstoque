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
    
    public partial class INFM_PRODUTONUMEROSERIE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_PRODUTONUMEROSERIE()
        {
            this.INFM_ITEMVENDA_NUMSERIE = new HashSet<INFM_ITEMVENDA_NUMSERIE>();
        }
    
        public string IDPRODUTONUMEROSERIE { get; set; }
        public string IDDATOSCOMPRAPROD { get; set; }
        public string IDEMPRESA { get; set; }
        public string DESNUMEROSERIE { get; set; }
        public bool BOLVENDIDO { get; set; }
    
        public virtual INFM_DATOSCOMPRAPROD INFM_DATOSCOMPRAPROD { get; set; }
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_ITEMVENDA_NUMSERIE> INFM_ITEMVENDA_NUMSERIE { get; set; }
    }
}
