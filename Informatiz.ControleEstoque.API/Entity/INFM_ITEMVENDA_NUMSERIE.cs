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
    
    public partial class INFM_ITEMVENDA_NUMSERIE
    {
        public string IDITEMVENDA { get; set; }
        public string IDITEMVENDA_NUMSERIE { get; set; }
        public string IDPRODUTONUMEROSERIE { get; set; }
    
        public virtual INFM_ITEMVENDA INFM_ITEMVENDA { get; set; }
        public virtual INFM_PRODUTONUMEROSERIE INFM_PRODUTONUMEROSERIE { get; set; }
    }
}
