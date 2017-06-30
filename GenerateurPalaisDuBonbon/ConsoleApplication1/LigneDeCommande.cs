using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateurPalaisDuBonbon
{
    class LigneDeCommande
    {
        
        private int nombre, nom, couleur, variante, texture, conditionnement, idCommande;

        public int Nombre { get; set; }
        public int Nom { get; set; }
        public int Couleur { get; set; }
        public int Variante { get; set; }
        public int Texture { get; set; }
        public int Conditionnement { get; set; }
        public int IdCommande { get; set; }

        public LigneDeCommande(int idCommande, int nom, int couleur, int variante, int texture, int conditionnement)
        {
            idCommande = this.idCommande;
            nom = this.nom;
            couleur = this.couleur;
            variante = this.variante;
            texture = this.texture;
            conditionnement = this.conditionnement;
        }
        


    }
}
