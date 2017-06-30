using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Machine
    {
        private int cadence, delai, type, tete, variante, linkingID;
        // linkingID est l'ID qui, s'il est différent de 0, lie deux machines entre elles 
        // (il s'agit en réalité d'une seule et même machine)

        // contiendra la liste des lignes de commandes qui sont dans la queue de la machine
        private List<LigneDeCommande> machineQueue = new List<LigneDeCommande>();

        public int Tete { get; set; }

        public int Variante { get; set; }

        public List<LigneDeCommande> MachineQueue { get; set; }

        public Machine(double cadence, int delai, int tete, int variante, int linkingID, int type)
        {
            cadence = this.cadence;
            delai = this.delai;
            type = this.type;
            tete = this.tete;
            linkingID = this.linkingID;
            variante = this.variante;
        }

        public static Machine[] creationMachines()
        {
            Machine[] machines = {
                new Machine(2.93, 2700, 1, 1, 0, 0),
                new Machine(5.76, 1500, 1, 2, 0, 0),
                new Machine(2.93, 1500, 1, 3, 0, 0),
                new Machine(2.93, 2700, 1, 1, 0, 1),
                new Machine(5.76, 1500, 1, 2, 0, 1)
            };

            return machines;
        }
    }
}
l