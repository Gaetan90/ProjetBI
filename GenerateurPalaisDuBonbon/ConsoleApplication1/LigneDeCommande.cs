using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class LigneDeCommande
    {
        
        public int nombreConditionnements { get; set; }
        public int nomBonbon { get; set; }
        public int couleur { get; set; }
        public int variante { get; set; }
        public Machine machineFab { get; set; }
        public Machine machineCond { get; set; }
        public int texture { get; set; }
        public int conditionnement { get; set; }
        public int idCommande { get; set; }

        public LigneDeCommande(int idCommande, int nombreConditionnements, int nomBonbon, int couleur, int variante, int texture, int conditionnement)
        {
            this.idCommande = idCommande;
            this.nombreConditionnements = nombreConditionnements;
            this.nomBonbon = nomBonbon;
            this.couleur = couleur;
            this.variante = variante;
            this.texture = texture;
            this.conditionnement = conditionnement;
        }
    }
}
