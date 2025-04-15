CREATE TABLE [dbo].[Entree] (
    [Nom_Entree]    VARCHAR (50) NULL,
	[ID_Entree]     INT          NOT NULL,
    [ID_Ingredient] INT          NOT NULL,
    [ID_Volume]     INT          NOT NULL,
    [ID_Menu]       INT          NULL,
    PRIMARY KEY CLUSTERED ([ID_Entree] ASC),
    FOREIGN KEY ([ID_Menu]) REFERENCES [dbo].[Contenu_du_Menu] ([ID_Menu]),
    FOREIGN KEY ([ID_Ingredient]) REFERENCES [dbo].[Ingredient] ([ID_Ingredient]),
    FOREIGN KEY ([ID_Menu]) REFERENCES [dbo].[Volume] ([ID_Volume])
);


GO

CREATE TRIGGER [dbo].[Trigger_Entree]
    ON [dbo].[Entree]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
		DELETE FROM Entree;
		INSERT INTO Entree
		VALUES
('Aubergeons les chevres',1,8,8,1),
('Aubergeons les chevres',2	,9,9,1),
('Aubergeons les chevres',3,10,10,1)
    END