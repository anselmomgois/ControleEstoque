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
    
    public partial class INFM_SESSAO
    {
        public string IDSESSAO { get; set; }
        public string IDPESSOA { get; set; }
        public string IDFILIAL { get; set; }
        public System.DateTime DTHINICIO { get; set; }
        public Nullable<System.DateTime> DTHFIM { get; set; }
        public System.DateTime DTHULTIMOUSO { get; set; }
    
        public virtual INFM_FILIAL INFM_FILIAL { get; set; }
        public virtual INFM_PESSOA INFM_PESSOA { get; set; }
    }
}
