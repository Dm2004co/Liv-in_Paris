SELECT * FROM Adresse as ad1,Metro as m1,Client c
WHERE ID_Client IS NOT NULL
SELECT * FROM Adresse as ad2,Metro as m2
WHERE ID_Cuisto IS NOT NULL
AND  m1.ID_Metro = ad1.ID_Metro
AND c.ID_Client = ad1.ID_Client
AND  m2.ID_Metro = ad2.ID_Metro
AND cui.ID_Cuisto = ad2.ID_Cuisto
GROUP BY ad.Id
;

