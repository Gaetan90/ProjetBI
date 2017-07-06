-- ============================================================
--   Table : LIGNESCOMMANDESTEMP                                
-- ============================================================

CREATE TABLE LignesCommandesTemp(
        idContenuCommande NUMBER GENERATED ALWAYS AS IDENTITY ,
        nbContenants      NUMBER NOT NULL ,
        tempsFab	      NUMBER NULL ,
        tempsCondi	      NUMBER NULL ,
        idCommande        NUMBER NOT NULL ,
        idContenant       NUMBER NOT NULL ,
        idBonbon          NUMBER NOT NULL ,
        idVariante        NUMBER NOT NULL ,
        idTexture         NUMBER NOT NULL ,
        idCouleur         NUMBER NOT NULL ,
        idMachineFab      NUMBER NULL ,
        idMachineCondi    NUMBER NULL ,
        CONSTRAINT PK_LIGNESCOMMANDESTEMP PRIMARY KEY (idContenuCommande )
)

/

-- ============================================================
--   Table : COMMANDESTEMP                                    
-- ============================================================

CREATE TABLE CommandesTemp(
        idCommande   NUMBER GENERATED ALWAYS AS IDENTITY ,
        numCommande  Varchar (25) NOT NULL ,
        dateCommande Varchar (25) NOT NULL ,
        idPays       NUMBER NOT NULL ,
        tempsFabTotal      NUMBER NULL ,
        tempsCondiTotal      NUMBER NULL ,
        tempsPicking      NUMBER NULL ,
        CONSTRAINT PK_COMMANDESTEMP PRIMARY KEY (idCommande )
)
/