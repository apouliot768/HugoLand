using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HugoLandEditeur.Models;

namespace HugoLandEditeur.ViewModels
{
    /// <summary>
    /// Author :        Alexandre Pouliot
    /// Description :   Object used to view users connexion state and manage user's role
    ///                 in the data grid of frmMenuUsers.
    /// Date :
    /// </summary>
    public class CompteRoles
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Constantes.Role Role { get; set; }
        public bool Connection { get; set; }
    }
}
