INSERT INTO Application_Site(ID_Client,ID_Cuisto,ID_Menu)
SELECT cui.ID_Cuisto ,c.ID_Client,menu.ID_Menu FROM Application_Site as app 
 INNER JOIN Cuisto cui on cui.ID_Cuisto = app.ID_Cuisto 
JOIN Contenu_du_Menu menu on menu.ID_Menu = app.ID_Menu
INNER JOIN Client c on c.ID_Client = app.ID_Client;

@ID_Client = 1
@ID_Cuisto = 7
@Nombre_de_Personnes = 2
@Pays_d_origine = 'France'
@Date_Depart = 01/04/2025 10:00:00
@Date_Arrivee = 01/04/2025 15:00:00
@Prix_Unitaire  = 3.5
@Regime = 'Vegan'
INSERT INTO Commandes(ID_Commandes,ID_Menu,ID_Client,ID_Cuisto,Nb_de_Personnes,Pays_d_origine,Date_Depart,Date_Arrivee,Prix_Unitaire,Regime)
VALUES(ROW_NUMBER()OVER(ORDER BY ID_Menu),ID_Menu,@ID_Client,@ID_Cuisto,@Nombre_de_Personnes,@Pays_d_origine,@Date_Depart,@Date_Arrivee,@Prix_Unitaire,@Regime);
