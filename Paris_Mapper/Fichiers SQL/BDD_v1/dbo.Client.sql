CREATE TABLE [dbo].[Client] (
    [ID_Client] INT          NOT NULL,
    [Prenom]    VARCHAR (50) NOT NULL,
    [Nom]       VARCHAR (50) NOT NULL,
    [Telephone]       INT          NULL,
    [Email]     VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([ID_Client] ASC),
    UNIQUE NONCLUSTERED ([Email] ASC),
    UNIQUE NONCLUSTERED ([Telephone] ASC), 
    CONSTRAINT [CK_Client_Telephone] CHECK (Telephone LIKE '07%' OR Telephone LIKE '06%')
);


GO

CREATE TRIGGER [dbo].[Trigger_Client]
    ON [dbo].[Client]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
    END