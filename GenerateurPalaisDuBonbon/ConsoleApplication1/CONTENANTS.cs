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
    
    public partial class CONTENANTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CONTENANTS()
        {
            this.CONDITIONNEMENT = new HashSet<CONDITIONNEMENT>();
            this.CONTENANTSPARCARTON = new HashSet<CONTENANTSPARCARTON>();
            this.PRIX = new HashSet<PRIX>();
            this.LIGNESCOMMANDES = new HashSet<LIGNESCOMMANDES>();
        }
    
        public decimal IDCONTENANT { get; set; }
        public string NOMCONTENANT { get; set; }
        public decimal NBBONBONS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONDITIONNEMENT> CONDITIONNEMENT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTENANTSPARCARTON> CONTENANTSPARCARTON { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRIX> PRIX { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LIGNESCOMMANDES> LIGNESCOMMANDES { get; set; }
    }
}
