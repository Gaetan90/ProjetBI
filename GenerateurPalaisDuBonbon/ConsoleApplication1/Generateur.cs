using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Generateur
    {
        // Date de la commande qui est directement mise par défaut au 30 juin 2017
        public static String dateCommande = "30/06/2017";

        // Objet random
        public static Random rnd = new Random();

        /**
         * Création d'une "pool" de commandes pour le simulateur. (Liste de commandes)
         */
        public static List<Commande> PoolCreation ()
        {
            List<Commande> pool = new List<Commande>();
            int idcommandes = 1000; // On démarre les ID par 1000

            for (int i = 0; i < 10; i++)
            {
                pool.Add(CommandeCreation(idcommandes + i));
            }

            Console.Read(); // Pour les tests
            return pool;
        }

        public static Commande CommandeCreation (int idcommande)
        {
            int nombre, nomBonbon, couleur, variante, texture, conditionnement, pays;

            pays = rnd.Next(1, 35);

            Commande commande = new Commande(idcommande, dateCommande, pays);
            LigneDeCommande temp;

            // On génère aléatoirement entre une et dix lignes par commandes
            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                // On génère les valeurs aléatoirement
                nombre = rnd.Next(1, 501);
                nomBonbon = rnd.Next(1, 28);
                couleur = rnd.Next(1, 9);
                variante = rnd.Next(1, 4);
                texture = rnd.Next(1, 3);
                conditionnement = rnd.Next(1, 4);
                

                temp = new LigneDeCommande(idcommande, nomBonbon, couleur, variante, texture, conditionnement);

                Console.WriteLine("[" + idcommande + "," + nomBonbon + "," + couleur + "," + variante + "," + texture + 
                                                                            "," + conditionnement + "]\n"); // Pour les tests

                commande.ajouterLigne(temp);
            }
            return commande;
        }

    }
}
