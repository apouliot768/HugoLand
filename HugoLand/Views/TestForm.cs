using HugoLand.Models;
using HugoLand.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HugoLand
{
    /// <summary>
    /// Auteurs:        Alexandre Pouliot et Joëlle Boyer
    /// Description:    Formulaire pour tester les fonctions 
    ///                 (TO DO: Valider l'utilité avec Joëlle, car des tests unitaires feraient aussi le travail.)
    /// Date:           2019-10-01
    /// </summary>
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        // Tests GestionObjetMonde
        private void BtnObjetMonde_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionMonde gestionMonde = new GestionMonde();

            GestionObjetMonde gestionObjetMonde = new GestionObjetMonde();

            Monde monde = gestionMonde.LstMondes.Last();

            ObjetMonde objMonde = new ObjetMonde
            {
                x = 2,
                y = 2,
                Description = "Objet test!",
                MondeId = monde.Id
            };

            txtTestes.Text += "Création ObjetMonde \r\n";
            gestionObjetMonde.CréerObjetMonde(objMonde);
            txtTestes.Text += "Description = " + objMonde.Description + "\r\n\r\n";

            txtTestes.Text += "Modification ObjetMonde \r\n";
            objMonde = gestionObjetMonde.ModifierObjetMonde(objMonde, "Nouvelle description");
            txtTestes.Text += "Description = " + objMonde.Description + "\r\n\r\n";

            txtTestes.Text += "Supression ObjetMonde \r\n";
            gestionObjetMonde.SupprimerObjetMonde(objMonde);

            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                if (!(contexte.ObjetMondes.Any(x => x.Description == "Nouvelle description")))
                {
                    txtTestes.Text += "Suppression réussie!";
                }
            }
        }

        // Tests GestionCompteJoueur
        private void BtnCompteJoueur_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionCompteJoueur gestionCompteJoueur = new GestionCompteJoueur();

            string Message = gestionCompteJoueur.CréerCompteJoueur("LinkTheHero", "link@thehero.com", "Link", "The Hero", 1, "Abc1234!");

            txtTestes.Text += "Test création CompteJoueur...\r\n";
            txtTestes.Text += "\r\n";
            txtTestes.Text += Message + "\r\n";

            txtTestes.Text += "\r\nTest modification CompteJoueur...\r\n";
            txtTestes.Text += "\r\n";

            CompteJoueur compteJoueur = new CompteJoueur()
            {
                NomJoueur = "Ganon",
                Courriel = "Ganon@zelda.com",
                Prenom = "Ganon",
                Nom = "Bad",
                TypeUtilisateur = 1
            };
            string MotDePasse = "Toto";

            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                List<CompteJoueur> compteJoueurs = contexte.CompteJoueurs.ToList();
                compteJoueur.Id = compteJoueurs.Last().Id;
                gestionCompteJoueur.ModifierCompteJoueur(compteJoueur, MotDePasse);
            }
            txtTestes.Text += "SUCCESS\r\n";

            txtTestes.Text += "\r\nTest connexion CompteJoueur...\r\n";
            txtTestes.Text += "\r\n";

            string testConnexion = "ERROR";
            CompteJoueur compte = gestionCompteJoueur.ConnexionCompteJoueur("Ganon", "Toto");
            if (compte != null)
                testConnexion = "SUCCESS";

            txtTestes.Text += testConnexion + "\r\n";

            txtTestes.Text += "\r\nTest supression CompteJoueur...\r\n";
            txtTestes.Text += "\r\n";

            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                List<CompteJoueur> compteJoueurs = contexte.CompteJoueurs.ToList();
                compteJoueur = compteJoueurs.Last();
                gestionCompteJoueur.SupprimerCompteJoueur(compteJoueur);
            }
            txtTestes.Text += "SUCCESS\r\n";

        }

        // Tests GestionMonde
        private void BtnMonde_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionMonde gMonde = new GestionMonde();

            txtTestes.Text += "Test RetournerMondes: (Affiche les descriptions, limites X et limites Y des mondes)...\r\n";
            txtTestes.Text += "\r\n";
            AfficherInfoMondes(gMonde);

            txtTestes.Text += "\r\n";
            txtTestes.Text += "Test CréerMonde...\r\n";
            txtTestes.Text += "\r\n";

            Monde monde1 = new Monde()
            {
                Description = "test",
                PathTile = "test",
                PathCsv = "test",
                DefaultTile = 1,
                SizeTile = 1
            };

            gMonde.CréerMonde(monde1);
            AfficherInfoMondes(gMonde);

            txtTestes.Text += "\r\n";
            txtTestes.Text += "Test ModifierMonde...\r\n";
            txtTestes.Text += "\r\n";

            gMonde.ModifierMonde(gMonde.LstMondes.Last(), 2, 2, "Modification");
            AfficherInfoMondes(gMonde);

            txtTestes.Text += "\r\n";
            txtTestes.Text += "Test SuprimerMonde...\r\n";
            txtTestes.Text += "\r\n";

            gMonde.SupprimerMonde(gMonde.LstMondes.Last());
            AfficherInfoMondes(gMonde);
        }

        // Tests GestionClasse
        private void BtnClasse_Click(object sender, EventArgs e)
        {

            txtTestes.Clear();
            GestionMonde gestionMonde = new GestionMonde();
            GestionClasse gestionClasse = new GestionClasse();
            gestionClasse.RecevoirClassesMonde(gestionMonde.LstMondes.First().Id);

            txtTestes.Text += "Liste des classes du premier monde  de la base de données: \r\n";
            AfficherInfoClasses(gestionClasse);

            txtTestes.Text += "\r\nCréation d'une classe : \r\n";
            Classe classe = new Classe()
            {
                NomClasse = "test",
                Description = "test",
                StatBaseStr = 3,
                StatBaseDex = 3,
                StatBaseInt = 3,
                StatBaseVitalite = 3,
                MondeId = gestionMonde.LstMondes.First().Id
            };
            classe = gestionClasse.CréerClasse(classe);
            AfficherInfoClasses(gestionClasse);

            txtTestes.Text += "\r\nModification d'une classe : \r\n";
            classe.NomClasse = "Test Modifier";

            classe = gestionClasse.ModifierClasse(classe);
            AfficherInfoClasses(gestionClasse);

            txtTestes.Text += "\r\nSuppression d'une classe : \r\n";
            classe = gestionClasse.SupprimerClasse(classe);

            if (classe.NomClasse == null)
                txtTestes.Text += "Supression réussie!\r\n";

            classe = gestionClasse.LstClasses.First();

            txtTestes.Text += "\r\nTrouver la classe d'un Hero : \r\n";

            Hero hero = new Hero();

            using (EntitiesGEDEquipe1 context = new EntitiesGEDEquipe1())
            {
                hero = context.Heros.FirstOrDefault(x => x.MondeId == classe.MondeId);
            }

            txtTestes.Text += "Numéro de classe du Hero : " + hero.ClasseId.ToString() + " \r\n";

            classe = gestionClasse.TrouverClasseHero(hero);

            txtTestes.Text += "Numéro de classe et nom de classe du Hero : " + classe.Id.ToString() + ", " + classe.NomClasse + " \r\n";
        }

        // Tests GestionItem
        private void BtnItem_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionItem gItem = new GestionItem();
            GestionHeros ghero = new GestionHeros();

            Item item = new Item
            {
                x = 8,
                y = 8,
                MondeId = 3114,
                Nom = "Test",
                Description = "Ceci est un test"
            };

            Hero hero = ghero.LstHeros.First();

            // Création d'un item
            gItem.CréationItem(item);
            AfficherInfoItems(gItem);

            // Modification d'un item
            txtTestes.Text += "\r\nDernier item : " + item.Id + " : " + item.Nom + " - " + item.Description + " - " + item.x + ", " + item.y + " - " + item.MondeId + "\r\n\r\n";

            gItem.ModificationItem(item.Id, hero.Id, -2);
            AfficherInfoItems(gItem);

            // Suppression d'un item
            txtTestes.Text += "\r\nSuppression d\'un item : \r\n";
            txtTestes.Text += "Compte avant (même compte qu\'après, mais heroId n\'existe pas) : " + gItem.LstItems.Count() + "\r\n";
            txtTestes.Text += "Dernier item : " + gItem.LstItems.Last().Id + " - " + gItem.LstItems.Last().Nom + " - " + gItem.LstItems.Last().x.ToString() + ", " + gItem.LstItems.Last().y.ToString() + " - " + gItem.LstItems.Last().IdHero.ToString() + "\r\n";
            gItem.SuppressionItem(item, hero);
            txtTestes.Text += "Compte après (même compte, mais x,y n\'est plus présent) : " + gItem.LstItems.Count() + "\r\n";
            txtTestes.Text += "Dernier item : " + gItem.LstItems.Last().Id + " - " + gItem.LstItems.Last().Nom + " - " + gItem.LstItems.Last().x.ToString() + ", " + gItem.LstItems.Last().y.ToString() + " - " + gItem.LstItems.Last().IdHero.ToString() + "\r\n";
        }

        // Tests GestionEffetItem
        private void BtnEffetItem_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionEffetItem gEffetItem = new GestionEffetItem();

            EffetItem effetItem = new EffetItem
            {
                ItemId = 2160,
                TypeEffet = 0,
                ValeurEffet = -5
            };

            // Ajouter un effet d'item
            txtTestes.Text += "\r\nAjout d\'un effet d\'item : \r\n";
            gEffetItem.AjouterEffetItem(effetItem);
            AfficherInfoEffetsItems(gEffetItem);

            // Modification d'un effet d'item
            txtTestes.Text += "\r\nDernier effet item : " + effetItem.Id.ToString() + " : " + effetItem.ValeurEffet.ToString() + " - " + effetItem.TypeEffet.ToString() + "\r\n";
            gEffetItem.ModifierEffetItem(effetItem, 2151, 7, 4);
            txtTestes.Text += "\r\nEffet item modifié - " + gEffetItem.LstEffetsItem.Last().Id.ToString() + " : "
                + gEffetItem.LstEffetsItem.Last().ValeurEffet.ToString() + " - " + gEffetItem.LstEffetsItem.Last().TypeEffet.ToString() + "\r\n";

            // Suppression d'un effet d'item
            txtTestes.Text += "\r\nSuppression d\'un effet d\'item : \r\n";
            txtTestes.Text += "Compte avant : " + gEffetItem.LstEffetsItem.Count() + "\r\n";
            AfficherInfoEffetsItems(gEffetItem);
            gEffetItem.SupprimerEffetItem(effetItem);
            txtTestes.Text += "Compte après : " + gEffetItem.LstEffetsItem.Count() + "\r\n";
            AfficherInfoEffetsItems(gEffetItem);
        }

        // Tests GestionMonstre
        private void BtnMonstre_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();

            GestionMonstre gMonstre = new GestionMonstre();
            Monstre monstre = new Monstre
            {
                x = 8,
                y = 8,
                MondeId = 3114,
                Nom = "Test",
                Niveau = 17,
                StatPV = 18
            };

            // Création d'un monstre
            gMonstre.CréerMonstre(monstre);
            AfficherInfoMonstres(gMonstre);

            // Modification d'un monstre
            txtTestes.Text += "\r\nModification du monstre créé : \r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";
            gMonstre.ModifierMonstre(monstre, monstre.x, monstre.y, 3111, "Pompom", 1, 8, 8f, 12f, null);
            monstre = gMonstre.LstMonstres.Last();
            txtTestes.Text += "Info du monstre modifié : \r\n";
            txtTestes.Text += monstre.Id + " - " + monstre.x + " - " + monstre.y + " - " + monstre.MondeId + " - " + monstre.Niveau + " - " + monstre.Nom
                + " - " + monstre.StatPV + " - " + monstre.StatDmgMax + " - " + monstre.StatDmgMin + "\r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";

            // Suppression d'un monstre
            txtTestes.Text += "\r\nSuppression de monstre : \r\n";
            txtTestes.Text += "Compte avant : " + gMonstre.LstMonstres.Count() + "\r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";
            gMonstre.SupprimerMonstre(monstre);
            txtTestes.Text += "Compte après : " + gMonstre.LstMonstres.Count() + "\r\n";
            txtTestes.Text += "Dernier monstre : " + gMonstre.LstMonstres.Last().Id + " - " + gMonstre.LstMonstres.Last().Nom + "\r\n";
        }

        // Tests GestionHero
        private void BtnHeros_Click(object sender, EventArgs e)
        {
            txtTestes.Clear();
            GestionHeros gHero = new GestionHeros();
            List<Hero> lstHeros = new List<Hero>();

            Hero hero = new Hero
            {
                x = 8,
                y = 8,
                MondeId = 3114,
                NomHero = "Test",
                Niveau = 17,
                StatVitalite = 18,
                CompteJoueurId = 2091
            };

            // Création d'un héro
            gHero.CréationHero(hero);
            AfficherInfoHeros(gHero);

            // Modification d'un héro
            txtTestes.Text += "\r\nModification du héro créé : \r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";
            gHero.ModifierHero(hero, 11, 15487, hero.x, hero.y, 18, 17, 16, 15, 3111, false);
            hero = gHero.LstHeros.Last();
            txtTestes.Text += "Info du héro modifié : \r\n";
            txtTestes.Text += hero.Id + " - " + hero.x + " - " + hero.y + " - " + hero.MondeId + " - " + hero.Niveau + " - " + hero.Experience + " - " + hero.NomHero
                + " - " + hero.StatVitalite + " - " + hero.StatStr + " - " + hero.StatDex + " - " + hero.StatInt + " - " + hero.EstConnecte + "\r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";

            // Suppression d'un héro
            txtTestes.Text += "\r\nSuppression de héro : \r\n";
            txtTestes.Text += "Compte avant : " + gHero.LstHeros.Count() + "\r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";
            gHero.SuppressionHero(hero);
            txtTestes.Text += "Compte après : " + gHero.LstHeros.Count() + "\r\n";
            txtTestes.Text += "Dernier héro : " + gHero.LstHeros.Last().Id + " - " + gHero.LstHeros.Last().NomHero + "\r\n";

            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                txtTestes.Text += "\r\nRetourner les héros pour le joueur 3093 : " + contexte.CompteJoueurs.First(x => x.Id == 3093).NomJoueur + "\r\n";

                lstHeros = gHero.RetourHerosJoueur(3093);
                if (lstHeros.Count() > 0)
                    foreach (var h in lstHeros)
                        txtTestes.Text += h.Id + " - " + h.NomHero + "\r\n";
                else
                    txtTestes.Text += "\r\nAucun héros trouvés pour le joueur " + contexte.CompteJoueurs.First(x => x.Id == 2091).NomJoueur;
            }

            // Je considère le 200 x 200 comme un multiple de la taille d'une tile (SizeTile) et de la position du héro
            // Si le héro est à la position 8, peu importe en x ou y, la marge sera de 200/monde.SizeTile (si SizeTile = 32, marge = +/- 6.25)
            // Donc dans le 200 x 200, le héros aura comme éléments se situant à 6 tuiles plus haut, plus bas, à gauche et à droite.
            // Donc entre 8-6 et 8+6, entre 2 et 14 autant en x qu'en y.
            hero = gHero.LstHeros.First(x => x.MondeId == 3111);
            txtTestes.Text += "\r\nTous les éléments dans un rayon de 200 x 200 : \r\n" +
                "Position du héro de base : " + hero.x + ", " + hero.y + "\r\n" +
                "Monde de base du héro : " + hero.MondeId.ToString() + "\r\n";
            using (EntitiesGEDEquipe1 contexte = new EntitiesGEDEquipe1())
            {
                gHero.ÉlémentsRayon200x200(hero);
                txtTestes.Text += "\r\nLes héros : \r\n";
                foreach (var h in gHero.lstHero)
                    txtTestes.Text += h.Id + " : " + h.NomHero + " - " + h.x + ", " + h.y + "\r\n";
                txtTestes.Text += "Les monstres : \r\n";
                foreach (var h in gHero.lstMonstres)
                    txtTestes.Text += h.Id + " : " + h.Nom + " - " + h.x + ", " + h.y + "\r\n";
                txtTestes.Text += "Les items : \r\n";
                foreach (var h in gHero.lstItems)
                    txtTestes.Text += h.Id + " : " + h.Nom + " - " + h.x + ", " + h.y + "\r\n";
                txtTestes.Text += "Les objets du monde : \r\n";
                foreach (var h in gHero.lstObjmonde)
                    txtTestes.Text += h.Id + " : " + h.Description + " - " + h.x + ", " + h.y + "\r\n";
            }
        }


        #region Méthodes permettant l'affichage d'informations
        // Méthode permettant d'afifcher les infos des mondes
        public void AfficherInfoMondes(GestionMonde gMonde)
        {
            foreach (Monde monde in gMonde.LstMondes)
            {
                txtTestes.Text += monde.Description.ToString() + " " + monde.LimiteX.ToString() + " " + monde.LimiteY.ToString() + "\r\n";
            }
        }

        // Méthode permettant d'afifcher les infos des classes
        public void AfficherInfoClasses(GestionClasse gestionClasse)
        {
            foreach (Classe classe in gestionClasse.LstClasses)
            {
                txtTestes.Text += classe.Id.ToString() + " " + classe.NomClasse.ToString() + "\r\n";
            }
        }

        // Méthode permettant d'afifcher les infos des monstres
        public void AfficherInfoMonstres(GestionMonstre gMonstre)
        {
            foreach (Monstre monstre in gMonstre.LstMonstres)
                txtTestes.Text += monstre.Id.ToString() + " - " + monstre.Nom.ToString() + "\r\n";
        }

        // Méthode permettant d'afifcher les infos des héros
        public void AfficherInfoHeros(GestionHeros gHeros)
        {
            foreach (Hero hero in gHeros.LstHeros)
                txtTestes.Text += "Joueur : " + hero.CompteJoueurId + " | Héro : " + hero.Id.ToString() + " - " + hero.NomHero + "\r\n";
        }

        // Méthode permettant d'afifcher les infos des items
        public void AfficherInfoItems(GestionItem gItem)
        {
            foreach (Item item in gItem.LstItems)
                txtTestes.Text += item.Id.ToString() + " - " + item.Nom.ToString() + "\r\n";
        }

        // Méthode permettant d'afifcher les infos des effets d'items
        public void AfficherInfoEffetsItems(GestionEffetItem gEffetItem)
        {
            foreach (EffetItem ef in gEffetItem.LstEffetsItem)
                txtTestes.Text += ef.Id.ToString() + " - " + ef.ItemId.ToString() + " - " + ef.ValeurEffet.ToString() + " - " + ef.TypeEffet.ToString() + "\r\n";
        }
        #endregion
    }
}
