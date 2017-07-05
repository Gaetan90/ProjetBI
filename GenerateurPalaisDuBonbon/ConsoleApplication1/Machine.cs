using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Machine
    {
        public int queueTaille { get; set; }

        public int tete { get; set; }

        // La condition permettant à la ligne de commande de rentrer dans la machine
        // Il s'agit de la variance pour les machines de fabrications, et du conditionnement
        // pour les machines de conditionnements
        public int condition { get; set; } 

        public double cadence { get; set; }

        public int delai { get; set; }

        public int idMachine { get; set; }
        
        public int type { get; set; }

        // contiendra la liste des lignes de commandes qui sont dans la queue de la machine
        public List<LigneDeCommande> machineQueue { get; set; }

        public Machine(double cadence, int delai, int tete, int condition, int idMachine, int type)
        {
            queueTaille = 0;
            this.cadence = cadence;
            this.delai = delai;
            this.type = type;
            this.tete = tete;
            this.idMachine = idMachine;
            this.condition = condition;
            machineQueue = new List<LigneDeCommande>();
        }

        public static Machine[] creationMachinesFabrication()
        {
            int tete1 = int.Parse(ConfigurationManager.AppSettings["tete1f"]);
            int tete2 = int.Parse(ConfigurationManager.AppSettings["tete2f"]);
            int tete3 = int.Parse(ConfigurationManager.AppSettings["tete3f"]);
            int tete4 = int.Parse(ConfigurationManager.AppSettings["tete4f"]);
            int tete5 = int.Parse(ConfigurationManager.AppSettings["tete5f"]);

            Machine[] machines = {
                new Machine(2.93, 2700, tete1, 1, 1, 0),
                new Machine(5.76, 1500, tete2, 2, 2, 0),
                new Machine(2.93, 1500, tete3, 3, 3, 0),
                new Machine(2.93, 2700, tete4, 1, 4, 0),
                new Machine(5.76, 1500, tete5, 2, 4, 0)
            };

            return machines;
        }
        public static Machine[] creationMachinesConditionnement()
        {
            int tete1 = int.Parse(ConfigurationManager.AppSettings["tete1c"]);
            int tete2 = int.Parse(ConfigurationManager.AppSettings["tete2c"]);
            int tete3 = int.Parse(ConfigurationManager.AppSettings["tete3c"]);
            int tete4 = int.Parse(ConfigurationManager.AppSettings["tete4c"]);
            int tete5 = int.Parse(ConfigurationManager.AppSettings["tete5c"]);
            int tete6 = int.Parse(ConfigurationManager.AppSettings["tete6c"]);

            Machine[] machines = {
                new Machine(7.2, 900, tete1, 1, 1, 1),
                new Machine(7.2, 900, tete2, 1, 2, 1),
                new Machine(4.8, 1500, tete3, 1, 3, 1),
                new Machine(18, 600, tete4, 2, 4, 1),
                new Machine(18, 600, tete5, 2, 5, 1),
                new Machine(24, 900, tete6, 3, 6, 1)
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