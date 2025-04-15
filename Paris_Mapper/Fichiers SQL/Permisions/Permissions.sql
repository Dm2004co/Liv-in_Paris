GO
GRANT SELECT
    ON OBJECT::[dbo].[Adresse_Client] TO [C];

    GRANT SELECT,UPDATE,INSERT ON Creation_Adresse to C;
GO
GRANT UPDATE ON Adresse_Client to C;
GO
GRANT SELECT
    ON OBJECT::[dbo].[Menu_Appli] TO [C];
    GO
     GRANT SELECT,UPDATE on Profil_Cuisto to Cui;
 GO 
 GRANT SELECT,UPDATE on Adresse_Cuisto to Cui;
 GO 
 GRANT SELECT,UPDATE,INSERT on Ingredient_Volume to Cui;
 GO
 GRANT SELECT ON Commandes_Annee to Cui;
 GO
 GRANT SELECT ON Commandes_du_Mois to Cui;
 GO
 GRANT SELECT ON Comptes_Clients to Cui;
 GO
 GRANT SELECT ON Moyenne_Prix_Commande to Cui;
 GO
 GRANT SELECT ON Nombre_de_Livraisons to Cui;
 GO
 GRANT SELECT,UPDATE,INSERT,DELETE ON Plat_du_Jour to Cui;
 GO
  GRANT SELECT,UPDATE,INSERT ON Creation_Adresse to Cui;