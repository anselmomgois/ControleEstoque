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
    
    public partial class INFM_SALDOFILIAL
    {
        public string IDSALDOFILIAL { get; set; }
        public string IDFILIAL { get; set; }
        public decimal NUMSALDO { get; set; }
    
        public virtual INFM_FILIAL INFM_FILIAL { get; set; }
    }
}
