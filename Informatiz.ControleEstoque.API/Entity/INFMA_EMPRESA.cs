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
    
    public partial class INFMA_EMPRESA
    {
        public string IDEMPRESA { get; set; }
        public string IDLICENCA { get; set; }
        public int CODEMPRESA { get; set; }
        public string DESEMPRESA { get; set; }
    
        public virtual INFMA_LICENCA INFMA_LICENCA { get; set; }
    }
}
