CREATE FUNCTION [dbo].[Filtrage Adresse]
(
	@ID_Client int,
	@Numero int,
	@Lieu varchar(50)
)
RETURNS TABLE AS RETURN
(
	SELECT @ID_Client as ID,
	@Numero as Num,
	@Lieu  as Lieu
)
