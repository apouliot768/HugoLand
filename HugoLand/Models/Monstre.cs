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
    
    public partial class Monstre
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int Niveau { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int StatPV { get; set; }
        public float StatDmgMin { get; set; }
        public float StatDmgMax { get; set; }
        public int MondeId { get; set; }
        public Nullable<int> ImageId { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual Monde Monde { get; set; }
    }
}
