CREATE TABLE [dbo].[Dessert] (
    [Nom_Dessert]   VARCHAR (50) NULL,
	[ID_Dessert]    INT          NOT NULL,
    [ID_Ingredient] INT          NOT NULL,
    [ID_Volume]     INT          NOT NULL,
    [ID_Menu]       INT          NULL,
    PRIMARY KEY CLUSTERED ([ID_Dessert] ASC),
    FOREIGN KEY ([ID_Ingredient]) REFERENCES [dbo].[Ingredient] ([ID_Ingredient]),
    FOREIGN KEY ([ID_Volume]) REFERENCES [dbo].[Volume] ([ID_Volume]),
    FOREIGN KEY ([ID_Menu]) REFERENCES [dbo].[Contenu_du_Menu] ([ID_Menu])
);


GO

CREATE TRIGGER  [dbo].[Trigger_Dessert]
    ON [dbo].[Dessert]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
		INSERT INTO Dessert
		VALUES
('Salade de Fruit',1,5,5,1),
('Salade de Fruit',2,6,6,1),
('Salade de Fruit',3,7,7,1);
    END