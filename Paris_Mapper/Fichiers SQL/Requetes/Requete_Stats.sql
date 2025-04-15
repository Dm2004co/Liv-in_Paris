select com.ID_Commandes , AVG(com.Nb_de_Personnes * com.Prix_Unitaire) as Moyenne_Prix_Commande from Catalogue cat 
 inner join Commandes com on com.ID_Commandes = cat.ID_Commandes
 group by com.ID_Commandes
 order by com.ID_Commandes;


select SUM(Moyenne_Prix_Commande) as Compte_Client from 
(
select c.ID_Client, com.ID_Commandes,AVG(com.Nb_de_Personnes * com.Prix_Unitaire) as Moyenne_Prix_Commande from Catalogue cat
inner join Commandes com on com.ID_Commandes = cat.ID_Commandes
inner join Client c on c.ID_Client = cat.ID_Client
 group by c.ID_Client,com.ID_Commandes) as Moyenne_Comptes_Clients
 ;

 select cui.ID_Cuisto , count(com.ID_Commandes)as Nombre_de_Livraisons from Cuisto cui 
 join Commandes com on  com.ID_Cuisto  = cui.ID_Cuisto
 group by cui.ID_Cuisto
 order by cui.ID_Cuisto;



 select com.ID_Commandes , WEEK(GETDATE()) as Semaine_en_cours from Commandes com , Cuisto
 where WEEK(com.Date_depart) =  WEEK(GETDATE())
 AND Cuisto.ID_Cuisto = com.ID_Cuisto
 group by Cuisto.ID_Cuisto,com.ID_Commandes;

 select c.ID_Client , com.ID_Commandes , com.Pays_d_origine ,com.Date_depart  from Client c 
 join Commandes com on com.ID_Client = c.ID_Client
 group by c.ID_Client , com.ID_Commandes , com.Pays_d_origine ,com.Date_depart
 order by c.ID_Client , com.ID_Commandes ; 

 

 
 

 
 

