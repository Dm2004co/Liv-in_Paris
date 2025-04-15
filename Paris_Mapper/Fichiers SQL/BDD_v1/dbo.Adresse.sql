CREATE TABLE [dbo].[Adresse] (
    [Id]            INT          NOT NULL,
    [ID_Personne]   INT          NULL,
    [Ville]         VARCHAR (50) NULL,
    [Numero]        VARCHAR (50) NULL,
    [Lieu]          VARCHAR (50) NULL,
    [Region]        VARCHAR (50) NULL,
    [Code_Postal]   INT          NULL,
    [Dept]          INT          NULL,
    [ID_Metro]      INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ID_Personne]) REFERENCES [dbo].[Client] ([ID_Client]),
    FOREIGN KEY ([ID_Personne]) REFERENCES [dbo].[Cuisto] ([ID_Cuisto]),
    FOREIGN KEY ([ID_Metro]) REFERENCES [dbo].[Metro] ([ID_Metro]), 
    
);


GO

CREATE TRIGGER [dbo].[Trigger_Adresse]
    ON [dbo].[Adresse]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON

    END