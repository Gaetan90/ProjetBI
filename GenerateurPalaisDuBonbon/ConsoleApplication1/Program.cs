using ConsoleApplication1;
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

            List<Commande> pool = Generateur.PoolCreation();
            foreach (Commande com in pool)
            {
                Simulateur.simulerFabricationCommande(com);
                Simulateur.simulerConditionnementCommande(com);
                Simulateur.simulerPickingCommande(com);
            }
            Generateur.pushPool(pool);
            
            /*
            Commande commande = new Commande(1, "03/07/2017", 1);
            
            LigneDeCommande ligne = new LigneDeCommande(1, 10, 1, 1, 1, 1, 1);
            LigneDeCommande ligne2 = new LigneDeCommande(1, 10, 2, 1, 1, 1, 1);
            LigneDeCommande ligne3 = new LigneDeCommande(1, 20, 2, 1, 1, 1, 2);
            commande.ajouterLigne(ligne);
            commande.ajouterLigne(ligne2);
            commande.ajouterLigne(ligne3);

            Console.WriteLine("Le temps de fabrication trouvé est de " + Simulateur.simulerProductionCommande(commande) + " secondes.");
            Console.WriteLine("Le temps de conditionnement trouvé est de " + Simulateur.simulerConditionnementCommande(commande) + " secondes.");
            Console.Read();
            */
        }
    }
}
