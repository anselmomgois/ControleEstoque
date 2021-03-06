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
    
    public partial class INFM_DOCUMENTO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INFM_DOCUMENTO()
        {
            this.INFM_DOCUMENTO1 = new HashSet<INFM_DOCUMENTO>();
            this.INFM_PARCELAMENTO = new HashSet<INFM_PARCELAMENTO>();
            this.INFM_SALDOPESSOA = new HashSet<INFM_SALDOPESSOA>();
            this.INFM_TRANSACOES = new HashSet<INFM_TRANSACOES>();
        }
    
        public string IDDOCUMENTO { get; set; }
        public string IDFILIAL { get; set; }
        public string IDPESSOA { get; set; }
        public string IDTIPODOCUMENTO { get; set; }
        public string IDLOCALDOCUMENTO { get; set; }
        public string IDFORMAPAGAMENTO { get; set; }
        public string IDADMINISTRADORA { get; set; }
        public string IDDOCUMENTOPAI { get; set; }
        public string CODTRANSACAO { get; set; }
        public string DESNUMBOLETOBANCARIO { get; set; }
        public System.DateTime DTHEMISSAO { get; set; }
        public System.DateTime DTHVENCORIGINAL { get; set; }
        public System.DateTime DTHVENCATUAL { get; set; }
        public decimal NUMVALORORIGINAL { get; set; }
        public bool BOLPARCELADO { get; set; }
        public string OBSDOCUMENTO { get; set; }
    
        public virtual INFM_ADMINISTRADORA INFM_ADMINISTRADORA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_DOCUMENTO> INFM_DOCUMENTO1 { get; set; }
        public virtual INFM_DOCUMENTO INFM_DOCUMENTO2 { get; set; }
        public virtual INFM_FILIAL INFM_FILIAL { get; set; }
        public virtual INFM_FORMAPAGAMENTO INFM_FORMAPAGAMENTO { get; set; }
        public virtual INFM_LOCALDOCUMENTO INFM_LOCALDOCUMENTO { get; set; }
        public virtual INFM_PESSOA INFM_PESSOA { get; set; }
        public virtual INFM_TIPODOCUMENTO INFM_TIPODOCUMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_PARCELAMENTO> INFM_PARCELAMENTO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_SALDOPESSOA> INFM_SALDOPESSOA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INFM_TRANSACOES> INFM_TRANSACOES { get; set; }
    }
}
