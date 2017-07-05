-- ============================================================
--   Table : FABRICATION                                      
-- ============================================================

CREATE TABLE Fabrication(
        idMachineFab      NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomMachineFab     Varchar (25) NOT NULL ,
        cadenceMachineFab NUMBER NOT NULL ,
        delaiMachineFab   NUMBER NOT NULL ,
        idVariante        NUMBER NOT NULL ,
        CONSTRAINT PK_FABRICATION PRIMARY KEY (idMachineFab )
)

/


-- ============================================================
--   Table : VARIANTES                                    
-- ============================================================

CREATE TABLE Variantes(
        idVariante  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomVariante Varchar (25) NOT NULL ,
        CONSTRAINT PK_VARIANTES PRIMARY KEY (idVariante )
)

/
-- ============================================================
--   Table : TEXTURES                                     
-- ============================================================

CREATE TABLE Textures(
        idTexture  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomTexture Varchar (25) NOT NULL ,
        CONSTRAINT PK_TEXTURES PRIMARY KEY (idTexture )
)

/
-- ============================================================
--   Table : CONTENANTSPARCARTON                                     
-- ============================================================

CREATE TABLE ContenantsParCarton(
        idContenantpCarton NUMBER GENERATED ALWAYS AS IDENTITY ,
        nbContenantpCarton NUMBER NOT NULL ,
        idContenant        NUMBER NOT NULL ,
        CONSTRAINT PK_CONTENANTSPARCARTON PRIMARY KEY (idContenantpCarton )
)

/
-- ============================================================
--   Table : CONDITIONNEMENT                                     
-- ============================================================

CREATE TABLE Conditionnement(
        idMachineCondi      NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomMachineCondi     Varchar (25) NOT NULL ,
        cadenceMachineCondi NUMBER NOT NULL ,
        delaiMachineCondi   NUMBER NOT NULL ,
        idContenant         NUMBER NOT NULL ,
        CONSTRAINT PK_CONDITIONNEMENT PRIMARY KEY (idMachineCondi )
)

/
-- ============================================================
--   Table : CARTONSPARPALETTE                                      
-- ============================================================

CREATE TABLE CartonsParPalette(
        idCartonPalette  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nbCartonpPalette NUMBER NOT NULL ,
        idTransport      NUMBER NOT NULL ,
        CONSTRAINT PK_CARTONSPARPALETTE PRIMARY KEY (idCartonPalette )
)

/
-- ============================================================
--   Table : BONBONS                                      
-- ============================================================

CREATE TABLE Bonbons(
        idBonbon         NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomBonbon        Varchar (40) NOT NULL ,
        additifsBonbon   NUMBER NOT NULL ,
        enrobageBonbon   NUMBER NOT NULL ,
        aromeBonbon      NUMBER NOT NULL ,
        gelifiantsBonbon NUMBER NOT NULL ,
        sucreBonbon      NUMBER NOT NULL ,
        coutFabrication      NUMBER NULL ,
        coutConditionnement      NUMBER NULL ,
        fraisExpedition      NUMBER NULL ,
        fraisGeneraux      NUMBER NULL ,
        lastRepartitionBonbon      FLOAT NULL ,
        CONSTRAINT PK_BONBONS PRIMARY KEY (idBonbon )
)
/
-- ============================================================
--   Table : LIGNESCOMMANDES                                 
-- ============================================================

CREATE TABLE LignesCommandes(
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
        CONSTRAINT PK_CONTENUCOMMANDES PRIMARY KEY (idContenuCommande )
)

/
-- ============================================================
--   Table : CONTENANTS                                      
-- ============================================================

CREATE TABLE Contenants(
        idContenant  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomContenant Varchar (25) NOT NULL ,
        nbBonbons    NUMBER NOT NULL ,
        CONSTRAINT PK_CONTENANTS PRIMARY KEY (idContenant )
)
/
-- ============================================================
--   Table : COULEURS                                      
-- ============================================================

CREATE TABLE Couleurs(
        idCouleur  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomCouleur Varchar (25) NOT NULL ,
        CONSTRAINT PK_COULEURS PRIMARY KEY (idCouleur )
)
/

-- ============================================================
--   Table : COMMANDES                                      
-- ============================================================

CREATE TABLE Commandes(
        idCommande   NUMBER GENERATED ALWAYS AS IDENTITY ,
        numCommande  Varchar (25) NOT NULL ,
        dateCommande Varchar (25) NOT NULL ,
        idPays       NUMBER NOT NULL ,
        tempsFabTotal      NUMBER NULL ,
        tempsCondiTotal      NUMBER NULL ,
        tempsPicking      NUMBER NULL ,
        CONSTRAINT PK_COMMANDES PRIMARY KEY (idCommande )
)
/
-- ============================================================
--   Table : PAYS                                      
-- ============================================================

CREATE TABLE Pays(
        idPays      NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomPays     Varchar (25) NOT NULL ,
        lastRepartitionPays FLOAT NULL ,
        idTransport NUMBER NOT NULL ,
        CONSTRAINT PK_PAYS PRIMARY KEY (idPays )
)
/

-- ============================================================
--   Table : TRANSPORTS                                     
-- ============================================================

CREATE TABLE Transports(
        idTransport         NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomTransport        Varchar (25) NOT NULL ,
        coutTransport       FLOAT NOT NULL ,
        contenanceTransport NUMBER NOT NULL ,
        CONSTRAINT PK_TRANSPORTS PRIMARY KEY (idTransport )
)

/
-- ============================================================
--   Table : PRIX                                      
-- ============================================================

CREATE TABLE Prix(
        idPrix        NUMBER GENERATED ALWAYS AS IDENTITY ,
        prix FLOAT NOT NULL ,
        idContenant NUMBER NOT NULL ,
        idBonbon    NUMBER NOT NULL ,
        CONSTRAINT PK_PRIX PRIMARY KEY (idContenant ,idBonbon )
)
/

ALTER TABLE Fabrication ADD CONSTRAINT FK_Fabrication_idVariante FOREIGN KEY (idVariante) REFERENCES Variantes(idVariante);
/
ALTER TABLE ContenantsParCarton ADD CONSTRAINT FK_ContenantsParCarton_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant);
/
ALTER TABLE Conditionnement ADD CONSTRAINT FK_Conditionnement_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant);
/
ALTER TABLE CartonsParPalette ADD CONSTRAINT FK_CartonsParPalette_idTransport FOREIGN KEY (idTransport) REFERENCES Transports(idTransport);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idCommande FOREIGN KEY (idCommande) REFERENCES Commandes(idCommande);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idBonbon FOREIGN KEY (idBonbon) REFERENCES Bonbons(idBonbon);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idVariante FOREIGN KEY (idVariante) REFERENCES Variantes(idVariante);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idTexture FOREIGN KEY (idTexture) REFERENCES Textures(idTexture);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idCouleur FOREIGN KEY (idCouleur) REFERENCES Couleurs(idCouleur);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idMachineFab FOREIGN KEY (idMachineFab) REFERENCES Fabrication(idMachineFab);
/
ALTER TABLE LignesCommandes ADD CONSTRAINT FK_LignesCommandes_idMachineCondi FOREIGN KEY (idMachineCondi) REFERENCES Conditionnement(idMachineCondi);
/
ALTER TABLE Commandes ADD CONSTRAINT FK_Commandes_idPays FOREIGN KEY (idPays) REFERENCES Pays(idPays);
/
ALTER TABLE Pays ADD CONSTRAINT FK_Pays_idTransport FOREIGN KEY (idTransport) REFERENCES Transports(idTransport);
/
ALTER TABLE Prix ADD CONSTRAINT FK_Prix_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant);
/
ALTER TABLE Prix ADD CONSTRAINT FK_Prix_idBonbon FOREIGN KEY (idBonbon) REFERENCES Bonbons(idBonbon);
/