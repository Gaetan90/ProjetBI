using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
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
        public static List<Commande> PoolAleatoireCreation()
        {
            List<Commande> pool = new List<Commande>();
            int idcommandes = 1000; // On démarre les ID par 1000

            for (int i = 0; i < 10; i++)
            {
                pool.Add(commandeAleatoireCreation(idcommandes + i));
            }
            
            return pool;
        }

        /**
         * Création d'une "pool" de commandes pour le simulateur. (Liste de commandes)
         */
        public static List<Commande> PoolCreation()
        {
            List<Commande> pool = new List<Commande>();
            int idcommandes = 1000; // On démarre les ID par 1000

            for (int i = 0; i < 10; i++)
            {
                pool.Add(commandeCreation(idcommandes + i));
            }

            return pool;
        }

        /**
         * Renvoie l'ID d'un pays générée aléatoirement à l'aide des pondérations
         * présentes dans le fichier de configuration
         */
        public static int genererPays()
        {

            int ratioTotal;
            double resultatProba;
            double trancheLimite;
            IDictionary<int, double> dictionnaire = new Dictionary<int, double>();
            int paysMax = int.Parse(ConfigurationManager.AppSettings["paysMax"]);

            for (int j = 1; j < (paysMax + 1); j++)
            {
                dictionnaire.Add(j, double.Parse(ConfigurationManager.AppSettings[("probaPays" + j).ToString()]));
            }

            ratioTotal = 100; // on travaille en pourcentage
            resultatProba = rnd.NextDouble() * ratioTotal;
            trancheLimite = 0;
            foreach (KeyValuePair<int, double> kvp in dictionnaire)
            {
                trancheLimite += kvp.Value;
                if (resultatProba <= trancheLimite)
                {
                    return kvp.Key;
                }
            }
            return paysMax; // retourne la dernière valeur au cas où aucune de celles d'avant n'aient été retournées
        }

        public static Commande commandeCreation(int idcommande)
        {
            int nombreBonbons, nomBonbon, couleur, variante, texture, conditionnement;

            int nomBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreTypesBonbons"]);
            int couleurBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreCouleursBonbons"]);
            int varianteBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreVariantesBonbons"]);
            int textureBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreTexturesBonbons"]);
            int conditionnementBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreConditionnementsBonbons"]);
            
            
            Commande commande = new Commande(idcommande, dateCommande, genererPays());
            LigneDeCommande temp;

            // On génère aléatoirement entre une et dix lignes par commandes
            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                // On génère les valeurs aléatoirement
                nombreBonbons = rnd.Next(1, 51);
                nomBonbon = rnd.Next(1, nomBonbonMax + 1);
                couleur = rnd.Next(1, couleurBonbonMax + 1);
                variante = rnd.Next(1, varianteBonbonMax + 1);
                texture = rnd.Next(1, textureBonbonMax + 1);
                conditionnement = rnd.Next(1, conditionnementBonbonMax + 1);


                temp = new LigneDeCommande(idcommande, nombreBonbons, nomBonbon, couleur, variante, texture, conditionnement);

                //Console.WriteLine("[" + idcommande + "," + nombreBonbons + "," + nomBonbon + "," + couleur + "," + variante + "," + texture +
                //                                                            "," + conditionnement + "]\n"); // Pour les tests

                commande.ajouterLigne(temp);
            }

            return commande;
        }

        public static Commande commandeAleatoireCreation(int idcommande)
        {
            int nombreBonbons, nomBonbon, couleur, variante, texture, conditionnement, pays;

            int nomBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreTypesBonbons"]);
            int couleurBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreCouleursBonbons"]);
            int varianteBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreVariantesBonbons"]);
            int textureBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreTexturesBonbons"]);
            int conditionnementBonbonMax = int.Parse(ConfigurationManager.AppSettings["nombreConditionnementsBonbons"]);

            pays = rnd.Next(1, 35);

            Commande commande = new Commande(idcommande, dateCommande, pays);
            LigneDeCommande temp;

            // On génère aléatoirement entre une et dix lignes par commandes
            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                // On génère les valeurs aléatoirement
                nombreBonbons = rnd.Next(1, 51);
                nomBonbon = rnd.Next(1, nomBonbonMax + 1);
                couleur = rnd.Next(1, couleurBonbonMax + 1);
                variante = rnd.Next(1, varianteBonbonMax + 1);
                texture = rnd.Next(1, textureBonbonMax + 1);
                conditionnement = rnd.Next(1, conditionnementBonbonMax + 1);


                temp = new LigneDeCommande(idcommande, nombreBonbons, nomBonbon, couleur, variante, texture, conditionnement);

                //Console.WriteLine("[" + idcommande + "," + nombreBonbons + "," + nomBonbon + "," + couleur + "," + variante + "," + texture +
                //                                                            "," + conditionnement + "]\n"); // Pour les tests

                commande.ajouterLigne(temp);
            }
            return commande;
        }

        /**
            * Push un pool de commandes dans la base de données Oracle
            * Ainsi que les lignes de commandes associées
            */
        public static void pushPool(List<Commande> pool)
        {
            COMMANDES tmpCommande;
            LIGNESCOMMANDES tmpLigne;
            ICollection<LIGNESCOMMANDES> tmpLignes;

            using (var cnx = new Entities())
            {

                foreach (Commande commande in pool)
                {
                    tmpLignes = new Collection<LIGNESCOMMANDES>();
                    tmpLigne = new LIGNESCOMMANDES();
                    tmpCommande = new COMMANDES();

                    // On rentre les données des commandes
                    tmpCommande.NUMCOMMANDE = commande.idCommande.ToString();
                    tmpCommande.DATECOMMANDE = commande.dateCommande;
                    tmpCommande.IDPAYS = commande.pays;
                    tmpCommande.TEMPSFABTOTAL = (decimal) commande.tempsFab;
                    tmpCommande.TEMPSCONDITOTAL = (decimal) commande.tempsCond;

                    // push
                    cnx.COMMANDES.Add(tmpCommande);
                    // commit
                    cnx.SaveChanges();

                    foreach (LigneDeCommande ligne in commande.lignesDeCommandes)
                    {
                        // On rentre les données de chaque ligne de commande
                        tmpLigne.NBCONTENANTS = ligne.nombreConditionnements;
                        tmpLigne.IDMACHINEFAB = ligne.machineFab.idMachine;
                        tmpLigne.IDMACHINECONDI = ligne.machineCond.idMachine;
                        tmpLigne.IDCONTENANT = ligne.conditionnement;
                        tmpLigne.IDBONBON = ligne.nomBonbon;
                        tmpLigne.IDVARIANTE = ligne.variante;
                        tmpLigne.IDTEXTURE = ligne.texture;
                        tmpLigne.IDCOULEUR = ligne.couleur;
                        tmpLigne.IDCOMMANDE = tmpCommande.IDCOMMANDE;
                        // TODO TEMPSFAB et TEMPSCONDI
                        // commit
                        cnx.LIGNESCOMMANDES.Add(tmpLigne);
                        // push
                        cnx.SaveChanges();
                    }                  
                }
            }
        }
    }
}
