using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Camion
    {
        public int idCamion { get; private set; }
        public int nbPalettes { get; private set; }
        public int nbPalettesMax { get; private set; }
        public bool parti { get; private set; }
        public int pays { get; private set; }

        public Camion(int idCamion, int nbPalettes, int pays)
        {
            this.idCamion = idCamion;
            this.nbPalettes = nbPalettes;
            this.nbPalettesMax = 20;
            this.pays = pays;
            this.parti = false;
        }
        

    }
}
