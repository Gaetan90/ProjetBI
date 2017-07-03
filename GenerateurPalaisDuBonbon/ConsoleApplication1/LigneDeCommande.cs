using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class LigneDeCommande
    {

        private int nombre, nomBonbon, couleur, variante, texture, conditionnement, machine, idCommande;

        public int Nombre { get; set; }
        public int NomBonbon { get; set; }
        public int Couleur { get; set; }
        public int Variante { get; set; }
        public Machine Machine { get; set; }
        public int Texture { get; set; }
        public int Conditionnement { get; set; }
        public int IdCommande { get; set; }

        public LigneDeCommande(int idCommande, int nomBonbon, int couleur, int variante, int texture, int conditionnement)
        {
            idCommande = this.idCommande;
            nomBonbon = this.nomBonbon;
            couleur = this.couleur;
            variante = this.variante;
            texture = this.texture;
            conditionnement = this.conditionnement;
        }
    }
}
