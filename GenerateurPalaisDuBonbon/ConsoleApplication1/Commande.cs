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
        public int idCommande { get; set; }

        public double tempsFab { get; set; }

        public double tempsCond { get; set; }

        public double tempsPicking { get; set; }

        public int pays { get; set; }

        // date de création de la commande
        public String dateCommande { get; set; }
        
        public List<LigneDeCommande> lignesDeCommandes { get; set; }

        public int nbLignes { get; set; }

        public Commande(int idCommande, String dateCommande, int pays)
        {
            this.nbLignes = 0;
            this.idCommande = idCommande;
            this.dateCommande = dateCommande;
            this.pays = pays;
            lignesDeCommandes = new List<LigneDeCommande>();
        }

        /**
         * Ajoute une ligne de commande à la commande
         */
        public void ajouterLigne(LigneDeCommande ligne)
        {
            lignesDeCommandes.Add(ligne);
            nbLignes++;
        }


    }
}
