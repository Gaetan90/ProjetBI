using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Simulateur
    {
        // Objet random
        public static Random rnd = new Random();

        public static double simulerProductionCommande(Commande commande)
        {
            double resultat = 0; // temps nécessaire pour produire la commande
            
            IDictionary<int, double> dictionnaire = new Dictionary<int, double>(); // dictionnaire qui contiendra "tempsFabri/idMachine"

            int nbLignes = commande.nbLignes; // Nombre de lignes dans la commande
            List<Machine> machinesAChoisir; // liste qui contiendra les machines viables pour chaque ligne

            int tmp;
            //Machine[] machines = Machine.creationMachines();
            Machine[] machines = Machine.creationMachines();
            List<LigneDeCommande> commandes = commande.lignesDeCommandes;
            
            if (commandes == null)
            {
                return -1;
            }

            // on sélectionne les lignes de commande une par une
            foreach (LigneDeCommande ligne in commandes)
            {
                machinesAChoisir = new List<Machine>();
                // On récupère les machines viables pour cette ligne de commande
                foreach (Machine machine in machines)
                {
                    if(machine.variante == ligne.variante)
                    {
                        machinesAChoisir.Add(machine);
                    }
                }

                // On prend une machine aléatoirement parmi les machinesAChoisir
                tmp = rnd.Next(machinesAChoisir.Count());

                // on set l'attribut "machine" de la ligne de commande en choisissant une machine aléatoire parmi machinesAChoisir 
                ligne.machine = machinesAChoisir[tmp];

                // Ajout de la ligne à la machine
                machinesAChoisir[tmp].ajouterLigne(ligne);

                // TODO La machine "double" doit simplement voire ses 2 temps aditionnés lors du calcul du simulateur

            }
            
            // On parcourt toutes les machines en lisant leurs Queues pour ressortir le temps total
            foreach (Machine machine in machines)
            {
                // On ajoute une clé LinkingID au dictionnaire si elle n'est pas encore présente
                if(!dictionnaire.ContainsKey(machine.idMachine))
                {
                    dictionnaire.Add(machine.idMachine, 0);
                }          
                foreach (LigneDeCommande ligne in machine.machineQueue)
                {
                    resultat += (machine.cadence * ligne.nombreBonbons);
                    if (ligne.nomBonbon != machine.tete)
                    {
                        resultat += machine.delai;
                        machine.tete = ligne.nomBonbon;
                    }
                    dictionnaire[machine.idMachine] += resultat;
                    resultat = 0;
                }              
            }

            // On met le temps du chemin critique dans le resultat
            foreach (KeyValuePair<int, double> kvp in dictionnaire)
            {
                Console.WriteLine("Temps passé dans la machine : " + kvp.Value);
                if (resultat < kvp.Value)
                {
                    resultat = kvp.Value;
                }
            }

            // on clean les lignes associées aux machines
            foreach (Machine machine in machines)
            {
                machine.machineQueue = new List<LigneDeCommande>();
                machine.queueTaille = 0;
            }

            return resultat;
        }
    }
}
