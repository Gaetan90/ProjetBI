using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class Dock
    {
        
        public List<int> couleur { get; private set; }
        public int idDock { get; private set; }
        public int numeroBoucle { get; private set; }
        public int positionBoucle { get; private set; }
        public List<int> typeBonbon { get; private set; }
        public List<int> variante { get; private set; }
        
        public Dock(int idDock, int numeroBoucle, int positionBoucle, List<int> typeBonbon, List<int> variante,
            List<int> couleur)
        {
            this.idDock = idDock;
            this.numeroBoucle = numeroBoucle;
            this.positionBoucle = positionBoucle;
            this.typeBonbon = typeBonbon;
            this.variante = variante;
            this.couleur = couleur;
        }

        public List<Dock> genererDocks()
        {
            List<Dock> docks = new List<Dock>();


            return docks;
        }

    }
}
