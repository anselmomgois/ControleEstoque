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
    
    public partial class INFM_PROPOSTA
    {
        public string IDPROPOSTA { get; set; }
        public string IDCRM { get; set; }
        public string IDEMPRESA { get; set; }
        public string DESPROPOSTA { get; set; }
        public Nullable<decimal> NUMPROPOSTAVENDA { get; set; }
        public Nullable<decimal> NUMPROPOSTAMANUTENCAO { get; set; }
        public Nullable<decimal> NUMCONTRAPROPOSTAVENDA { get; set; }
        public Nullable<decimal> NUMCONTRAPROPOSTAMANUT { get; set; }
        public string DESOPNIAO { get; set; }
        public string DESDUVIDA { get; set; }
        public Nullable<bool> BOLATENDENECESSIDADE { get; set; }
        public Nullable<System.DateTime> DTINSTALACAO { get; set; }
        public bool BOLATIVA { get; set; }
        public int CODPROPOSTA { get; set; }
        public string IDPESSOA { get; set; }
        public string IDPESSOACLIENTE { get; set; }
    
        public virtual INFM_CRM INFM_CRM { get; set; }
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        public virtual INFM_PESSOA INFM_PESSOA { get; set; }
        public virtual INFM_PESSOA INFM_PESSOA1 { get; set; }
    }
}
