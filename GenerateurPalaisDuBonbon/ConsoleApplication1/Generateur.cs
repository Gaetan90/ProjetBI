using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Generateur
    {
        public static Random rnd = new Random();

        public static List<Commande> PoolCreation ()
        {
            List<Commande> pool = new List<Commande>();
            int idcommandes = 1000; // TODO : Définir comment choisir les ID des commandes

            for (int i = 0; i < 10; i++)
            {
                pool.Add(CommandeCreation(idcommandes + i));
            }

            Console.Read();
            return pool;
        }

        public static Commande CommandeCreation (int idcommande)
        {

            int nombre, nom, couleur, variante, texture, conditionnement;
            Commande commande = new Commande(idcommande);
            LigneDeCommande temp;

            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                nombre = rnd.Next(1, 501);
                nom = rnd.Next(27); // On ajoute un nom aléatoire (int de 0 à 26)
                couleur = rnd.Next(8);
                variante = rnd.Next(3);
                texture = rnd.Next(2);
                conditionnement = rnd.Next(3);

                temp = new LigneDeCommande(idcommande, nom, couleur, variante, texture, conditionnement);

                Console.WriteLine("[" + idcommande + "," + nom + "," + couleur + "," + variante + "," + texture + 
                                                                            "," + conditionnement + "]\n");

                commande.ajouterLigne(temp);
            }
            return commande;
        }

    }
}
