using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HugoLand.Models
{
    public class Constantes
    {
        // Requêtes SQL importantes
        public const string ConnectionString = "Data Source=172.16.2.246;Initial Catalog=GED-Equipe1-2019;User ID=Equipe1;Password=maison;MultipleActiveResultSets=True;Application Name=EntityFramework";

        public const string RequeteDeleteItem = "DELETE FROM EffetItem Where ItemId = @ItemId; DELETE FROM [dbo].[InventaireHero] WHERE ItemId = @ItemId; DELETE FROM [dbo].[Item] WHERE Id = @ItemId;";

        public const string RequeteDeleteDependancesMonde = "DELETE FROM [dbo].[Heros] WHERE MondeId = @MondeId; DELETE FROM [dbo].[Classe] WHERE MondeId = @MondeId;DELETE FROM [dbo].[Monstre] WHERE MondeId = @MondeId;DELETE FROM [dbo].[ObjetMonde] WHERE MondeId = @MondeId;DELETE FROM [dbo].[Monde] WHERE Id = @MondeId;";

        public const string RequeteDeleteHeroDuCompteJoueur = "DELETE FROM [dbo].[Heros] WHERE CompteJoueurId = @CompteJoueurId; DELETE FROM [dbo].[CompteJoueur] WHERE Id = @CompteJoueurId;";

        public const string RequeteDeleteHeroClasse = "DELETE FROM [dbo].[Heros] WHERE ClasseId = @ClasseId; DELETE FROM [dbo].[Classe] WHERE Id = @ClasseId;";
        // Rôles des utilisateurs
        public enum Role
        {
            Admin,
            Player,
            Default
        }
        public enum ContextChat
        {
            Editor
        }
    }
}
