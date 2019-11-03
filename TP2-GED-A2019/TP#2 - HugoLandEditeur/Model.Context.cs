﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class EntitiesGEDEquipe1 : DbContext
    {
        public EntitiesGEDEquipe1()
            : base("name=EntitiesGEDEquipe1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<CompteJoueur> CompteJoueurs { get; set; }
        public virtual DbSet<EffetItem> EffetItems { get; set; }
        public virtual DbSet<Hero> Heros { get; set; }
        public virtual DbSet<InventaireHero> InventaireHeroes { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Monde> Mondes { get; set; }
        public virtual DbSet<Monstre> Monstres { get; set; }
        public virtual DbSet<ObjetMonde> ObjetMondes { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
    
        public virtual int Connexion(string pNomJoueur, string pMotDePasse, ObjectParameter message)
        {
            var pNomJoueurParameter = pNomJoueur != null ?
                new ObjectParameter("pNomJoueur", pNomJoueur) :
                new ObjectParameter("pNomJoueur", typeof(string));
    
            var pMotDePasseParameter = pMotDePasse != null ?
                new ObjectParameter("pMotDePasse", pMotDePasse) :
                new ObjectParameter("pMotDePasse", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Connexion", pNomJoueurParameter, pMotDePasseParameter, message);
        }
    
        public virtual int CreerCompteJoueur(string pNomUtilisateur, string pCourriel, string pPrenom, string pNom, Nullable<int> pTypeUtilisateur, string pMotDePasse, ObjectParameter message)
        {
            var pNomUtilisateurParameter = pNomUtilisateur != null ?
                new ObjectParameter("pNomUtilisateur", pNomUtilisateur) :
                new ObjectParameter("pNomUtilisateur", typeof(string));
    
            var pCourrielParameter = pCourriel != null ?
                new ObjectParameter("pCourriel", pCourriel) :
                new ObjectParameter("pCourriel", typeof(string));
    
            var pPrenomParameter = pPrenom != null ?
                new ObjectParameter("pPrenom", pPrenom) :
                new ObjectParameter("pPrenom", typeof(string));
    
            var pNomParameter = pNom != null ?
                new ObjectParameter("pNom", pNom) :
                new ObjectParameter("pNom", typeof(string));
    
            var pTypeUtilisateurParameter = pTypeUtilisateur.HasValue ?
                new ObjectParameter("pTypeUtilisateur", pTypeUtilisateur) :
                new ObjectParameter("pTypeUtilisateur", typeof(int));
    
            var pMotDePasseParameter = pMotDePasse != null ?
                new ObjectParameter("pMotDePasse", pMotDePasse) :
                new ObjectParameter("pMotDePasse", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreerCompteJoueur", pNomUtilisateurParameter, pCourrielParameter, pPrenomParameter, pNomParameter, pTypeUtilisateurParameter, pMotDePasseParameter, message);
        }
    }
}
