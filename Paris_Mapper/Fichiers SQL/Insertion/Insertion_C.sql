
INSERT INTO Contenu_du_Menu(ID_Menu,ID_Entree,ID_Plat,ID_Dessert,Nom_Menu)
SELECT  ROW_NUMBER()OVER(ORDER BY e.ID_Entree,p.ID_Plat,d.ID_Dessert),e.ID_Entree,p.ID_Plat,d.ID_Dessert,'Grrr, chauffons la raclette'
FROM Entree as e ,Plat as p ,Dessert as d
group by  e.ID_Entree,p.ID_Plat,d.ID_Dessert;

INSERT INTO Commandes(ID_Commandes,ID_Menu,ID_Client,ID_Cuisto,Nb_de_Personnes)
SELECT  ROW_NUMBER()OVER(ORDER BY menu.ID_Menu),ID_Menu,1,1,5
FROM Contenu_du_Menu as menu
group by  menu.ID_Menu;

										


																														

