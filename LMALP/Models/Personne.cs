using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LMALP.Models
{
    public class Personne
    {   
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Ce champ doit être rempli")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ doit être rempli")]
        [DisplayName("Prénom")]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Ce champ doit être rempli")]
        public string Ville { get; set; }

        [Required(ErrorMessage = "Ce champ doit être rempli")]
        [DataType(DataType.Date)]
        public DateTime DateDeNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ doit être rempli")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Ce champ doit être rempli")]
        [DisplayName("Téléphone")]
        [MaxLength(10)]
        public string Telephone { get; set; }

        public string Password { get; set; }
        public Role Role { get; set; }

    }

    public enum Role
        {
            Admin,
            Adherent,
            Visiteur
        }
}
