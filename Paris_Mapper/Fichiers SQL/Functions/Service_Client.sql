CREATE FUNCTION [dbo].[Function]
(
	@ID_Cuisto int , 
	@Date_inscritpion datetime,
	@Date_depart datetime,
	@ID_Client int
)
RETURNS @Client_Servi TABLE
(
	Client int ,
	Cuisinier int ,
	date_service datetime
)
AS
BEGIN
	
	SELECT  @ID_Client,@ID_Cuisto,@Date_depart 
	where @Date_inscritpion <= @Date_depart 
	RETURN
END
