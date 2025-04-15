CREATE TABLE [dbo].[Metro] (
    [ID_Metro]       INT              NOT NULL,
    [Ligne]          INT              NOT NULL,
    [Correspondance] XML              NOT NULL,
    [Station]        VARCHAR (50)     NOT NULL,
    [Longitude]      DECIMAL (20, 20) NOT NULL,
    [Latitude]       DECIMAL (20, 20) NOT NULL,
    [Commune]        VARCHAR (50)     NULL,
    [Code_Postal]    INT              NULL,
    PRIMARY KEY CLUSTERED ([ID_Metro] ASC),
    CONSTRAINT [CK_Métro_Correspondance] CHECK (Correspondance in ('1','2','3','4','5','6','7','8','9','10','11','12','13','14','3bis','7bis')),
	CONSTRAINT [CK_Métro_Ligne] CHECK (Ligne in ('1','2','3','4','5','6','7','8','9','10','11','12','13','14','3bis','7bis'))
);


GO

CREATE TRIGGER [dbo].[Trigger_Métro]
    ON [dbo].[Metro]
    FOR DELETE, INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
    END