CREATE TABLE [dbo].[Contenu_du_Menu] (
    [Nom_Menu]   VARCHAR (50) NOT NULL,
    [ID_Menu]    INT          NOT NULL,
    [ID_Entree]  INT          NULL,
    [ID_Plat]    INT          NULL,
    [ID_Dessert] INT          NULL,
    CONSTRAINT [PK_Contenu_du_Menu] PRIMARY KEY CLUSTERED ([ID_Menu] ASC),
    FOREIGN KEY ([ID_Dessert]) REFERENCES [dbo].[Dessert] ([ID_Dessert]),
    FOREIGN KEY ([ID_Plat]) REFERENCES [dbo].[Plat] ([ID_Plat]),
    FOREIGN KEY ([ID_Entree]) REFERENCES [dbo].[Entree] ([ID_Entree])
);


GO

CREATE TRIGGER [dbo].[Trigger_Contenu_du_Menu]
    ON [dbo].[Contenu_du_Menu]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
		DELETE FROM Contenu_du_Menu;
		INSERT INTO Contenu_du_Menu
		VALUES
		
('Grrr, chauffons la raclette',1)
    END