CREATE TABLE [dbo].[Catalogue] (
    [ID_Catalogue]       INT          NOT NULL,
    [ID_Client]        INT          NOT NULL,
    [ID_Cuisto]      INT          NOT NULL,
    [ID_Commandes]        INT          NOT NULL,
    [Nom_Menu]           VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID_Catalogue] ASC),
    FOREIGN KEY ([ID_Commandes]) REFERENCES [dbo].[Commandes] ([ID_Commandes]),
    FOREIGN KEY ([ID_Client]) REFERENCES [dbo].[Client] ([ID_Client]),
    FOREIGN KEY ([ID_Cuisto]) REFERENCES [dbo].[Cuisto] ([ID_Cuisto]),
    FOREIGN KEY ([Nom_Menu]) REFERENCES [dbo].[Contenu_du_Menu] ([Nom_Menu])
);


GO

CREATE TRIGGER [dbo].[Trigger_Catalogue]
    ON [dbo].[Catalogue]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
    END