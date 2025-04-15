select ID_Livraison,AVG(),(l.Nb_de_Personnes * l.Prix_Unitaire) as Prix_Commande from Livraison l 
group by ID_Livraison
order by ID_Livraison;