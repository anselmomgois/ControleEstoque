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
    
    public partial class INFM_INTEGRACAOAPI
    {
        public string IDINTEGRACAOAPI { get; set; }
        public string IDEMPRESA { get; set; }
        public string CODINTEGRACAOAPI { get; set; }
        public string DESURLINTEGRACAOAPI { get; set; }
        public string IDTIPOCRM { get; set; }
    
        public virtual INFM_EMPRESA INFM_EMPRESA { get; set; }
        public virtual INFM_TIPOCRM INFM_TIPOCRM { get; set; }
    }
}
