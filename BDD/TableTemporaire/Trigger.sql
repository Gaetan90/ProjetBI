-------------------------------------------------------------------------------
--Trigger après l'exécution d'un insert (récupère les nouvelles données entrées
--et les mets dans les tables temporaires).
-------------------------------------------------------------------------------
CREATE OR REPLACE TRIGGER pull_data_insert_com
AFTER INSERT ON commandes FOR EACH ROW

BEGIN
	INSERT INTO commandesTemp 
	( numCommande,
	  dateCommande,
	  idPays,
	  tempsFabTotal,
	  tempsCondiTotal,
	  tempsPicking
	  )
	VALUES 
	( :new.numCommande,
	  :new.dateCommande,
	  :new.idPays,
	  :new.tempsFabTotal,
	  :new.tempsCondiTotal,
	  :new.tempsPicking
	  );

END;
/



CREATE OR REPLACE TRIGGER pull_data_insert_lignes
AFTER INSERT ON lignesCommandes FOR EACH ROW

BEGIN
	INSERT INTO lignesCommandesTemp 
	( nbContenants,
	  tempsFab,
	  tempsCondi,
	  idCommande,
	  idContenant,
	  idBonbon,
	  idVariante,
	  idTexture,
	  idCouleur,
	  idMachineFab,
	  idMachineCondi
	  )
	VALUES 
	( :new.nbContenants,
	  :new.tempsFab,
	  :new.tempsCondi,
	  :new.idCommande,
	  :new.idContenant,
	  :new.idBonbon,
	  :new.idVariante,
	  :new.idTexture,
	  :new.idCouleur,
	  :new.idMachineFab,
	  :new.idMachineCondi
	  );

END;
/

