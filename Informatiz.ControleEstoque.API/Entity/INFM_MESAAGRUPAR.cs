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
    
    public partial class INFM_MESAAGRUPAR
    {
        public string IDMESAAGRUPAR { get; set; }
        public string IDMESAPRINCIPAL { get; set; }
        public string IDMESAAUXILIAR { get; set; }
    
        public virtual INFM_MESA INFM_MESA { get; set; }
        public virtual INFM_MESA INFM_MESA1 { get; set; }
    }
}
