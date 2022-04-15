using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XSystem.Security.Cryptography;

namespace LMALP.Models.Person
{
    public class Dal : IDal
    {
		private BddContext _bddContext;

		public Dal()
		{
			this._bddContext = new BddContext();
		}

		public void Dispose()
		{
			this._bddContext.Dispose();
		}

		public static string EncodeMD5(string motDePasse)
		{
			string motDePasseSel = "LMALP" + motDePasse + "ASP.NET MVC";
			return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
		}

		public Personne ObtenirPersonne(int id)
		{
			return this._bddContext.Personnes.FirstOrDefault(u => u.Id == id);
		}

		// addeed for authentification
		public Personne AjouterPersonne(string nom, string prenom, string ville, string mail, DateTime dateDeNaissance, string telephone, string password, Role role = Role.Adherent)
		{
			string motDePasse = EncodeMD5(password);
			Personne personne = new Personne() { Nom = nom, Prenom = prenom, Ville = ville, Email=mail, Telephone = telephone, Password = motDePasse, Role = role };
			this._bddContext.Personnes.Add(personne);
			this._bddContext.SaveChanges();

			return personne;
		}

		public void ModifierPersonne(int id, string nom, string prenom, string ville, string mail, DateTime dateDeNaissance, string telephone, string password)
		{
			Personne personne = _bddContext.Personnes.Find(id);
			if (personne != null)
			{
				personne.Nom = nom;
				personne.Prenom = prenom;
				personne.DateDeNaissance = dateDeNaissance;
				personne.Email = mail;
				personne.Ville = ville;
				personne.Telephone = telephone;
				personne.Password = password;	
				_bddContext.SaveChanges();
			}
		}

		[Authorize(Roles = "Admin")]
		public void SupprimerPersonne(int id)
		{
			Personne personne = _bddContext.Personnes.Find(id);
			if (personne != null)
			{
				_bddContext.Personnes.Remove(personne);
				_bddContext.SaveChanges();
			}
		}

		[Authorize(Roles = "Admin")]
		public List<Personne> ObtientToutesLesPersonnes()
		{
			return _bddContext.Personnes.ToList();
		}

	}
}
