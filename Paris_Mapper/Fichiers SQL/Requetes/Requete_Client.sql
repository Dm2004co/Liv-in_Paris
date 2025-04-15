select c.Prenom,c.Nom from Client c 
group by c.Nom,c.Prenom
order by c.Nom,c.Prenom;

select c.ID_Client , a.Id ,a.Numero,a.Lieu,a.Ville,a.Code_Postal,a.Region from Client c
JOIN Adresse a  on  a.Id = c.ID_Client
group by c.ID_Client,a.Id,a.Numero,a.Lieu,a.Ville,a.Code_Postal,a.Region
order by c.ID_Client,a.Id,a.Numero,a.Lieu,a.Ville,a.Code_Postal,a.Region;



select c.ID_Client,(SUM(com.Nb_de_Personnes * com.Prix_Unitaire)) as Montant from Client c
join Commandes com on com.ID_Client = c.ID_Client
group by c.ID_Client
order by c.ID_Client;







