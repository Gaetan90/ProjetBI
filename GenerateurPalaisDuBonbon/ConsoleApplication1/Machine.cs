using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Machine
    {
        public int queueTaille { get; set; }

        public int tete { get; set; }

        public int variante { get; set; }

        public double cadence { get; set; }

        public int delai { get; set; }

        public int idMachine { get; set; }
        
        public int type { get; set; }

        // contiendra la liste des lignes de commandes qui sont dans la queue de la machine
        public List<LigneDeCommande> machineQueue { get; set; }

        public Machine(double cadence, int delai, int tete, int variante, int idMachine, int type)
        {
            queueTaille = 0;
            this.cadence = cadence;
            this.delai = delai;
            this.type = type;
            this.tete = tete;
            this.idMachine = idMachine;
            this.variante = variante;
            machineQueue = new List<LigneDeCommande>();
        }

        public static Machine[] creationMachines()
        {
            Machine[] machines = {
                new Machine(2.93, 2700, 1, 1, 1, 0),
                new Machine(5.76, 1500, 1, 2, 2, 0),
                new Machine(2.93, 1500, 1, 3, 3, 0),
                new Machine(2.93, 2700, 1, 1, 4, 0),
                new Machine(5.76, 1500, 1, 2, 4, 0)
            };

            return machines;
        }

        public void ajouterLigne(LigneDeCommande ligne)
        {
            machineQueue.Add(ligne);
            queueTaille++;
        }
    }
}