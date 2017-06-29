using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Commande
    {
        private int id;

        private List<LigneDeCommande> LignesDeCommandes;
        
        public Commande(int id)
        {
            id = this.id;
            LignesDeCommandes = new List<LigneDeCommande>();
        }

        public void ajouterLigne(LigneDeCommande ligne)
        {
            LignesDeCommandes.Add(ligne);
        }


    }
}
