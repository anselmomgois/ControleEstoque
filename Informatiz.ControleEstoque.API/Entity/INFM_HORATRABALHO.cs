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
    
    public partial class INFM_HORATRABALHO
    {
        public string IDHORATRABALHO { get; set; }
        public string IDPESSOA { get; set; }
        public int CODDIASEMANA { get; set; }
        public string DTHINICIO { get; set; }
        public string DTHFIM { get; set; }
    
        public virtual INFM_PESSOA INFM_PESSOA { get; set; }
    }
}
