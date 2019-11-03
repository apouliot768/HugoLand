﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HugoLandEditeur.Models;

namespace HugoLandEditeur.ViewModels
{
    public class CompteRoles
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Constantes.Role Role { get; set; }
        public bool Connection { get; set; }
    }
}