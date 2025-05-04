select cui.ID_Cuisto , c.ID_Client , appli.ID_Application ,YEAR(appli.Date_inscription) as Annee_Inscription from Cuisto cui 
join Application_Site appli on appli.ID_Application = cui.ID_Cuisto
join Commandes com on com.ID_Cuisto = cui.ID_Cuisto
join Client c on c.ID_Client = com.ID_Client
group by cui.ID_Cuisto , c.ID_Client , appli.ID_Application,YEAR(appli.Date_inscription)
order by cui.ID_Cuisto , c.ID_Client , appli.ID_Application,YEAR(appli.Date_inscription)
;
select cui.ID_Cuisto , c.ID_Client , appli.ID_Application ,YEAR(GETDATE()) as Annee_en_Cours from Cuisto cui 
join Application_Site appli on appli.ID_Application = cui.ID_Cuisto
join Commandes com on com.ID_Cuisto = cui.ID_Cuisto
join Client c on c.ID_Client = com.ID_Client
group by cui.ID_Cuisto , c.ID_Client , appli.ID_Application
order by cui.ID_Cuisto , c.ID_Client , appli.ID_Application,YEAR(GETDATE())
;

;
select cui.ID_Cuisto , c.ID_Client , appli.ID_Application ,appli.Date_inscription from Cuisto cui 
join Application_Site appli on appli.ID_Application = cui.ID_Cuisto
join Commandes com on com.ID_Cuisto = cui.ID_Cuisto
join Client c on c.ID_Client = com.ID_Client
where  appli.Date_inscription < com.Date_depart
group by cui.ID_Cuisto , c.ID_Client , appli.ID_Application,appli.Date_inscription
order by cui.ID_Cuisto , c.ID_Client , appli.ID_Application;




select cui.ID_Cuisto , c.ID_Client , appli.ID_Application ,MONTH(GETDATE()) as Mois_en_Cours from Cuisto cui 
join Application_Site appli on appli.ID_Application = cui.ID_Cuisto
join Commandes com on com.ID_Cuisto = cui.ID_Cuisto
join Client c on c.ID_Client = com.ID_Client
group by cui.ID_Cuisto , c.ID_Client , appli.ID_Application
order by cui.ID_Cuisto , c.ID_Client , appli.ID_Application,MONTH(GETDATE());



select cui.ID_Cuisto , c.ID_Client , appli.ID_Application ,DAY(GETDATE()) as Jour from Cuisto cui 
join Application_Site appli on appli.ID_Application = cui.ID_Cuisto
join Commandes com on com.ID_Cuisto = cui.ID_Cuisto
join Client c on c.ID_Client = com.ID_Client
group by cui.ID_Cuisto , c.ID_Client , appli.ID_Application
order by cui.ID_Cuisto , c.ID_Client , appli.ID_Application,DAY(GETDATE());

select cui.ID_Cuisto , com.ID_Commandes ,com.Nb_de_Personnes,com.Date_depart,com.Date_arrivee,com.Nom_Menu,com.Prix_Unitaire,com.Regime, com.Pays_d_origine from Commande as com 
join Cuisto cui on cui.ID_Cuisto = com.ID_Cuisto
group by com.Pays_d_origine,cui.ID_Cuisto,com.ID_Commandes,com.Date_depart,com.Date_arrivee,com.Nom_Menu,com.Prix_Unitaire,com.Regime,com.Nb_de_Personnes
ORDER BY  com.Pays_d_origine;


