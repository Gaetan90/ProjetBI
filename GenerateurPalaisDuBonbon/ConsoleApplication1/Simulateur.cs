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

        public int simulerProductionCommande(Commande commande)
        {
            int nbLignes = commande.NbLignes; // Nombre de lignes dans la commande
            List<Machine> machinesAChoisir = new List<Machine>(); // liste qui contiendra les machines viables pour chaque ligne
            
            Machine[] machines;
            machines = Machine.creationMachines();
            List<LigneDeCommande> commandes = commande.LignesDeCommandes;

            // on sélectionne les lignes de commande une par une
            foreach (LigneDeCommande ligne in commandes)
            {
                // On récupère les machines viables pour cette ligne de commande
                foreach (Machine machine in machines)
                {
                    if(machine.Variante == ligne.Variante)
                    {
                        machinesAChoisir.Add(machine);
                    }
                }

                // TODO : sélection d'une machine parmi la liste
                // ajout de la machine à la ligne de commande, et de la ligne de commande à la machine;

                // on set l'attribut "machine" de la ligne de commande en choisissant une machine aléatoire parmi machinesAChoisir 
                ligne.Machine = machinesAChoisir[rnd.Next(0,machinesAChoisir.Count()-1)];

                // TODO nécessaire d'ajouter des id aux machines afin de savoir laquelle est choisie ?



            }

            return 1;
        }
    }
}
