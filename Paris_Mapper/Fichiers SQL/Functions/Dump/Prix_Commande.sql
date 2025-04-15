CREATE FUNCTION [dbo].[Prix]
(
	@Nb_2_Personnes int,
	@Prix_Unitaire decimal(3,2)
)
RETURNS decimal(3,2)
AS
BEGIN
	RETURN @Nb_2_Personnes * @Prix_Unitaire
END
