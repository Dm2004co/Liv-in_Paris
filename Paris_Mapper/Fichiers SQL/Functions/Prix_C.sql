CREATE FUNCTION [dbo].[Prix_C]
(
	@Nb_2_Personnes int ,
	@Prix_Unitaire decimal(3,2),
	@ID_Commande int 
)
RETURNS @Prix TABLE
(
	c1 int,
	c2 decimal(3,2)
)
AS
BEGIN
	INSERT @Prix
	SELECT @ID_Commande, @Nb_2_Personnes*@Prix_Unitaire
	RETURN
END
