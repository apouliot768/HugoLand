//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HugoLand.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class InventaireHero
    {
        public int IdHero { get; set; }
        public int ItemId { get; set; }
        public int IdInventaireHero { get; set; }
    
        public virtual Hero Hero { get; set; }
        public virtual Item Item { get; set; }
    }
}
