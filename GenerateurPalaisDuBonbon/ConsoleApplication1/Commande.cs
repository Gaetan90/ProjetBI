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
        // id de la commande ainsi que pays où la commande devra être livrée
        private int idCommande, pays;

        // date de création de la commande
        private String dateCommande;

        // contiendra les "lignes de commandes" de la commande
        private List<LigneDeCommande> LignesDeCommandes;
        
        public Commande(int idCommande, String dateCommande, int pays)
        {
            idCommande = this.idCommande;
            dateCommande = this.dateCommande;
            pays = this.pays;
            LignesDeCommandes = new List<LigneDeCommande>();
        }

        /**
         * Ajoute une ligne de commande à la commande
         */
        public void ajouterLigne(LigneDeCommande ligne)
        {
            LignesDeCommandes.Add(ligne);
        }


    }
}
