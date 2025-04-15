CREATE FUNCTION [dbo].[Nom_Client]
(
	@Nom varchar(50),
	@Prenom varchar(50)
	
)
RETURNS TABLE AS RETURN
(
	SELECT
	@Nom as c1,
	@Prenom as c2
		   
)
