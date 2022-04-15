using System;
using System.Collections.Generic;

namespace LMALP.Models
{
    public interface IDal
    {
        Personne AjouterPersonne(string nom, string prenom, string ville, string mail, DateTime dateDeNaissance, string telephone, string password, Role role = Role.Adherent);

        void ModifierPersonne(int id, string nom, string prenom, string ville, string mail, DateTime dateDeNaissance, string telephone, string password);

        void SupprimerPersonne(int id);

        List<Personne> ObtientToutesLesPersonnes();
    }
}
