//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRIX
    {
        public decimal IDPRIX { get; set; }
        public decimal PRIX1 { get; set; }
        public decimal IDCONTENANT { get; set; }
        public decimal IDBONBON { get; set; }
    
        public virtual BONBONS BONBONS { get; set; }
        public virtual CONTENANTS CONTENANTS { get; set; }
    }
}
