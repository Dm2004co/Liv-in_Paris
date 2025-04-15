CREATE FUNCTION [dbo].[Plat_du_Jour]
(
	@ID_Cuisto int ,
	@Date_depart datetime,
	@Nom_Menu varchar(50)
)
RETURNS TABLE AS RETURN
(
	SELECT @ID_Cuisto AS c1,
		   @Date_depart AS c2,
		   @Nom_Menu as c3
)
