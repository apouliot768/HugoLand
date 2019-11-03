using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HugoLand.Models;

namespace HugoLand.ViewModels
{
    public class CompteRoles
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Constantes.Role Role { get; set; }
        public bool Connection { get; set; }
    }
}
