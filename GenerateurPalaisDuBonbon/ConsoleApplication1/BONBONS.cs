//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class BONBONS
    {
        public BONBONS()
        {
            this.LIGNESCOMMANDES = new HashSet<LIGNESCOMMANDES>();
        }
    
        public decimal IDBONBON { get; set; }
        public string NOMBONBON { get; set; }
        public decimal ADDITIFSBONBON { get; set; }
        public decimal ENROBAGEBONBON { get; set; }
        public decimal AROMEBONBON { get; set; }
        public decimal GELIFIANTSBONBON { get; set; }
        public decimal SUCREBONBON { get; set; }
    
        public virtual ICollection<LIGNESCOMMANDES> LIGNESCOMMANDES { get; set; }
    }
}
