using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Program
    {
        static void Main(string[] args)
        {

            //List<Commande> pool = GenerateurPalaisDuBonbon.Generateur.PoolCreation();

            Commande commande = new Commande(1, "03/07/2017", 1);
            LigneDeCommande ligne = new LigneDeCommande(1, 10, 1, 1, 1, 1, 1);
            LigneDeCommande ligne2 = new LigneDeCommande(1, 10, 2, 1, 1, 1, 1);
            commande.ajouterLigne(ligne);
            commande.ajouterLigne(ligne2);

            Console.WriteLine("Le temps total trouvé est de " + Simulateur.simulerProductionCommande(commande) + " secondes.");
            Console.Read();
        }
    }
}
