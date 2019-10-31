using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HugoLandEditeur.Models;

namespace HugoLandEditeur.ViewModels
{
    public class CompteCréation
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid Email")]
        public string Email { get; set; }
        [Required]
        public Constantes.Role Role { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string PasswordConfirm { get; set; }

        public Dictionary<string, string> IsValid()
        {
            Dictionary<string, string> dicErrors = new Dictionary<string, string>();
            ValidationContext context = new ValidationContext(this, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(this, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    //string MemberName = result.MemberNames.First() is string ? result.MemberNames.First() : "PasswordConfirm";
                    dicErrors.Add(result.ErrorMessage, result.MemberNames.FirstOrDefault());
                }
            }
            return dicErrors;
        }

    }
}
