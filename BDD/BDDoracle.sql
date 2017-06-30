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


-- ============================================================
--   Table : TEXTURES                                     
-- ============================================================

CREATE TABLE Textures(
        idTexture  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomTexture Varchar (25) NOT NULL ,
        CONSTRAINT PK_TEXTURES PRIMARY KEY (idTexture )
)


-- ============================================================
--   Table : CONTENANTSPARCARTON                                     
-- ============================================================

CREATE TABLE ContenantsParCarton(
        idContenantpCarton NUMBER GENERATED ALWAYS AS IDENTITY ,
        nbContenantpCarton Int NOT NULL ,
        idContenant        Int NOT NULL ,
        CONSTRAINT PK_CONTENANTSPARCARTON PRIMARY KEY (idContenantpCarton )
)


-- ============================================================
--   Table : CONDITIONNEMENT                                     
-- ============================================================

CREATE TABLE Conditionnement(
        idMachineCondi      NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomMachineCondi     Varchar (25) NOT NULL ,
        cadenceMachineCondi Int NOT NULL ,
        delaiMachineCondi   Int NOT NULL ,
        idContenant         Int NOT NULL ,
        CONSTRAINT PK_CONDITIONNEMENT PRIMARY KEY (idMachineCondi )
)


-- ============================================================
--   Table : CARTONSPARPALETTE                                      
-- ============================================================

CREATE TABLE CartonsParPalette(
        idCartonPalette  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nbCartonpPalette Int NOT NULL ,
        idTransport      Int NOT NULL ,
        CONSTRAINT PK_CARTONSPARPALETTE PRIMARY KEY (idCartonPalette )
)


-- ============================================================
--   Table : BONBONS                                      
-- ============================================================

CREATE TABLE Bonbons(
        idBonbon         NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomBonbon        Varchar (40) NOT NULL ,
        additifsBonbon   Int NOT NULL ,
        enrobageBonbon   Int NOT NULL ,
        aromeBonbon      Int NOT NULL ,
        gelifiantsBonbon Int NOT NULL ,
        sucreBonbon      Int NOT NULL ,
        CONSTRAINT PK_BONBONS PRIMARY KEY (idBonbon )
)

-- ============================================================
--   Table : CONTENUCOMMANDES                                 
-- ============================================================

CREATE TABLE ContenuCommandes(
        idContenuCommande NUMBER GENERATED ALWAYS AS IDENTITY ,
        nbContenants      Int NOT NULL ,
        idCommande        Int NOT NULL ,
        idContenant       Int NOT NULL ,
        idBonbon          Int NOT NULL ,
        idVariante        Int NOT NULL ,
        idTexture         Int NOT NULL ,
        idCouleur         Int NOT NULL ,
        idMachineFab      Int NOT NULL ,
        idMachineCondi    Int NOT NULL ,
        CONSTRAINT PK_CONTENUCOMMANDES PRIMARY KEY (idContenuCommande )
)


-- ============================================================
--   Table : CONTENANTS                                      
-- ============================================================

CREATE TABLE Contenants(
        idContenant  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomContenant Varchar (25) NOT NULL ,
        nbBonbons    Int NOT NULL ,
        CONSTRAINT PK_CONTENANTS PRIMARY KEY (idContenant )
)

-- ============================================================
--   Table : COULEURS                                      
-- ============================================================

CREATE TABLE Couleurs(
        idCouleur  NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomCouleur Varchar (25) NOT NULL ,
        CONSTRAINT PK_COULEURS PRIMARY KEY (idCouleur )
)


-- ============================================================
--   Table : COMMANDES                                      
-- ============================================================

CREATE TABLE Commandes(
        idCommande   NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomCommande  Varchar (25) NOT NULL ,
        dateCommande Date NOT NULL ,
        idPays       Int NOT NULL ,
        CONSTRAINT PK_COMMANDES PRIMARY KEY (idCommande )
)


-- ============================================================
--   Table : PAYS                                      
-- ============================================================

CREATE TABLE Pays(
        idPays      NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomPays     Varchar (25) NOT NULL ,
        idTransport Int NOT NULL ,
        CONSTRAINT PK_PAYS PRIMARY KEY (idPays )
)


-- ============================================================
--   Table : TRANSPORTS                                     
-- ============================================================

CREATE TABLE Transports(
        idTransport         NUMBER GENERATED ALWAYS AS IDENTITY ,
        nomTransport        Varchar (25) NOT NULL ,
        coutTransport       Float NOT NULL ,
        contenanceTransport Int NOT NULL ,
        CONSTRAINT PK_TRANSPORTS PRIMARY KEY (idTransport )
)


-- ============================================================
--   Table : PRIX                                      
-- ============================================================

CREATE TABLE Prix(
        prix        NUMBER GENERATED ALWAYS AS IDENTITY ,
        idContenant Int NOT NULL ,
        idBonbon    Int NOT NULL ,
        CONSTRAINT PK_PRIX PRIMARY KEY (idContenant ,idBonbon )
)

ALTER TABLE Fabrication ADD CONSTRAINT FK_Fabrication_idVariante FOREIGN KEY (idVariante) REFERENCES Variantes(idVariante)
/

ALTER TABLE ContenantsParCarton ADD CONSTRAINT FK_ContenantsParCarton_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant)
/

ALTER TABLE Conditionnement ADD CONSTRAINT FK_Conditionnement_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant)
/

ALTER TABLE CartonsParPalette ADD CONSTRAINT FK_CartonsParPalette_idTransport FOREIGN KEY (idTransport) REFERENCES Transports(idTransport)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idCommande FOREIGN KEY (idCommande) REFERENCES Commandes(idCommande)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idBonbon FOREIGN KEY (idBonbon) REFERENCES Bonbons(idBonbon)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idVariante FOREIGN KEY (idVariante) REFERENCES Variantes(idVariante)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idTexture FOREIGN KEY (idTexture) REFERENCES Textures(idTexture)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idCouleur FOREIGN KEY (idCouleur) REFERENCES Couleurs(idCouleur)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idMachineFab FOREIGN KEY (idMachineFab) REFERENCES Fabrication(idMachineFab)
/

ALTER TABLE ContenuCommandes ADD CONSTRAINT FK_ContenuCommandes_idMachineCondi FOREIGN KEY (idMachineCondi) REFERENCES Conditionnement(idMachineCondi)
/

ALTER TABLE Commandes ADD CONSTRAINT FK_Commandes_idPays FOREIGN KEY (idPays) REFERENCES Pays(idPays)
/

ALTER TABLE Pays ADD CONSTRAINT FK_Pays_idTransport FOREIGN KEY (idTransport) REFERENCES Transports(idTransport)
/

ALTER TABLE Prix ADD CONSTRAINT FK_Prix_idContenant FOREIGN KEY (idContenant) REFERENCES Contenants(idContenant)
/

ALTER TABLE Prix ADD CONSTRAINT FK_Prix_idBonbon FOREIGN KEY (idBonbon) REFERENCES Bonbons(idBonbon)
/
