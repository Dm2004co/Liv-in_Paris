CREATE TABLE [dbo].[Commandes] (
    [ID_Client]     INT            NOT NULL,
    [ID_Cuisto]   INT            NOT NULL,
    [Nom_Menu]        VARCHAR (50)   NOT NULL,
    [ID_Commandes]    INT            NOT NULL,
    [Nb_de_Personnes] INT            NULL,
    [Pays_d_origine]  VARCHAR (50)   NULL,
    [Regime]          VARCHAR (50)   NULL,
    [Date_depart]     DATETIME       NULL,
    [Date_arrivee]    DATETIME       NULL,
    [Prix_Unitaire]   DECIMAL (5, 2) NULL,
    PRIMARY KEY CLUSTERED ([ID_Commandes] ASC),
    FOREIGN KEY ([ID_Client]) REFERENCES [dbo].[Client] ([ID_Client]),
    FOREIGN KEY ([ID_Cuisto]) REFERENCES [dbo].[Cuisto] ([ID_Cuisto]),
    FOREIGN KEY ([Nom_Menu]) REFERENCES [dbo].[Contenu_du_Menu] ([Nom_Menu])
);


GO

CREATE TRIGGER [dbo].[Trigger_Commandes]
    ON [dbo].[Commandes]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
    END