//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HugoLandEditeur
{
    using System;
    using System.Collections.Generic;
    
    public partial class ChatMessage
    {
        public int MessageID { get; set; }
        public int CompteJoueurId { get; set; }
        public string MessageText { get; set; }
        public System.DateTime DatePost { get; set; }
        public string ContextPost { get; set; }
    
        public virtual CompteJoueur CompteJoueur { get; set; }
    }
}
