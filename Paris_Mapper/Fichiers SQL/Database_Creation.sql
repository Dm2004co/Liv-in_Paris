CREATE TABLE [dbo].[Contenu_du_Menu] (
    [Nom_Menu]    VARCHAR (50) NOT NULL,
    [ID_Menu]     INT          NOT NULL,
    [ID_Entree]   INT          NULL,
    [ID_Plat]     INT          NULL,
    [ID_Dessert]  INT          NULL, 
    CONSTRAINT [PK_Contenu_du_Menu] PRIMARY KEY ([ID_Menu]),
	FOREIGN KEY ([ID_Entree]) REFERENCES [dbo].[Entree] ([ID_Entree]),
    FOREIGN KEY ([ID_Dessert]) REFERENCES [dbo].[Dessert] ([ID_Dessert]),
    FOREIGN KEY ([ID_Plat]) REFERENCES [dbo].[Plat] ([ID_Plat])
);



CREATE TABLE [dbo].[Entree](
   Nom_Entree VARCHAR(50),
   Ingredient VARCHAR(50),
   Volume DECIMAL(15,2),
   ID_Menu int,
   ID_Entree int , 
   PRIMARY KEY(ID_Entree),
   FOREIGN KEY(ID_Menu) REFERENCES Contenu_du_Menu_(ID_Menu)
);

CREATE TABLE [dbo].[Plat] (
    [Nom_Plat]      VARCHAR (50) NULL,
    [ID_Ingredient] INT          NOT NULL,
    [ID_Volume]     INT          NOT NULL,
    [ID_Plat] INT NOT NULL, 
    [ID_Menu] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID_Plat]),
    FOREIGN KEY ([ID_Menu]) REFERENCES Contenu_du_Menu(ID_Menu),
    FOREIGN KEY ([ID_Ingredient]) REFERENCES [dbo].[Ingredient] ([ID_Ingredient]),
    FOREIGN KEY ([ID_Volume]) REFERENCES [dbo].[Volume] ([ID_Volume])
);


CREATE TABLE [dbo].[Dessert] (
    [Nom_Dessert]   VARCHAR (50) NULL,
    [ID_Ingredient] INT          NOT NULL,
    [ID_Volume]     INT          NOT NULL,
    [ID_Dessert] INT NOT NULL, 
    [ID_Menu] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID_Dessert]),
    FOREIGN KEY ([ID_Ingredient]) REFERENCES [dbo].[Ingredient] ([ID_Ingredient]),
    FOREIGN KEY ([ID_Volume]) REFERENCES [dbo].[Volume] ([ID_Volume]),
    FOREIGN KEY ([ID_Menu]) REFERENCES Contenu_du_Menu(ID_Menu)
);




CREATE TABLE [dbo].[Cuisto](
   ID_Personne INT,
   Fonction VARCHAR(50),
   Prenom VARCHAR(50),
   Nom VARCHAR(50),
   Tel INT,
   Email VARCHAR(50),
   UNIQUE(Tel),
   UNIQUE(Email),
   PRIMARY KEY(ID_Personne),
   FOREIGN KEY(ID_Personne) REFERENCES Personne(ID_Personne)
);

CREATE TABLE [dbo].[Client](
   ID_Personne INT,
   Prenom VARCHAR(50),
   Nom VARCHAR(50),
   Tel INT,
   Email VARCHAR(50),
   UNIQUE(Tel),
   UNIQUE(Email),
   PRIMARY KEY(ID_Personne),
   FOREIGN KEY(ID_Personne) REFERENCES Personne(ID_Personne)
);

CREATE TABLE [dbo].[Application_Site] (
    [ID_Application]   INT          NOT NULL,
    [ID_Personne]      INT          NOT NULL,
    [Mdp]              VARCHAR (50) NOT NULL,
    [Pays_d_origine]   VARCHAR (50) NULL,
    [Regime]           VARCHAR (50) NULL,
    [Date_inscription] DATETIME     NULL,
    [ID_Menu] INT NOT NULL, 
    PRIMARY KEY CLUSTERED ([ID_Application] ASC),
    FOREIGN KEY ([ID_Menu]) REFERENCES [dbo].[Contenu_du_Menu] ([ID_Menu]),
    FOREIGN KEY ([ID_Personne]) REFERENCES [dbo].[Client] ([ID_Client]),
    FOREIGN KEY ([ID_Personne]) REFERENCES [dbo].[Cuisto] ([ID_Cuisto])
);


CREATE TABLE [dbo].[Commandes] (
    [ID_Client]       INT            NOT NULL,
    [ID_Cuisto]       INT            NOT NULL,
    [Nom_Menu]        VARCHAR (50)   NOT NULL,
    [ID_Commandes]    INT            NOT NULL,
    [Nb_de_Personnes] INT            NULL,
    [Pays_d_origine]  VARCHAR (50)   NULL,
    [Regime]          VARCHAR (50)   NULL,
    [Date_depart]     DATETIME       NULL,
    [Date_arrivee]    DATETIME       NULL,
    [Prix_Unitaire]   DECIMAL (5, 2) NULL,
    PRIMARY KEY CLUSTERED ([ID_Commandes] ASC),
    FOREIGN KEY ([Nom_Menu]) REFERENCES [dbo].[Contenu_du_Menu] ([Nom_Menu]),
    FOREIGN KEY ([ID_Client]) REFERENCES [dbo].[Client] ([ID_Client]),
    FOREIGN KEY ([ID_Cuisto]) REFERENCES [dbo].[Cuisto] ([ID_Cuisto])
);


CREATE TABLE [dbo].[Catalogue] (
    [ID_Catalogue] INT          NOT NULL,
    [ID_Client]    INT          NOT NULL,
    [ID_Cuisto]    INT          NOT NULL,
    [ID_Commandes] INT          NOT NULL,
    [Nom_Menu]     VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([ID_Catalogue] ASC),
    FOREIGN KEY ([ID_Commandes]) REFERENCES [dbo].[Commandes] ([ID_Commandes]),
    FOREIGN KEY ([ID_Client]) REFERENCES [dbo].[Client] ([ID_Client]),
    FOREIGN KEY ([ID_Cuisto]) REFERENCES [dbo].[Cuisto] ([ID_Cuisto]),
    FOREIGN KEY ([Nom_Menu]) REFERENCES [dbo].[Contenu_du_Menu] ([Nom_Menu])
);

CREATE TABLE [dbo].[Adresse] (
    [Id]          INT          NOT NULL,
    [ID_Personne] INT          NULL,
    [Ville]       VARCHAR (50) NULL DEFAULT 'Paris',
    [Numero]      VARCHAR (50) NULL,
    [Lieu]        VARCHAR (50) NULL,
    [Region]      VARCHAR (50) NULL DEFAULT 'Ile_de_France',
    [Code_Postal] INT          NULL DEFAULT 75,
    [Dept]        INT          NULL DEFAULT 'Paris',
    [ID_Metro]    INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ID_Personne]) REFERENCES [dbo].[Cuisto] ([ID_Cuisto]),
    FOREIGN KEY ([ID_Personne]) REFERENCES [dbo].[Client] ([ID_Client])
);

CREATE TABLE [dbo].[Ingredient] (
    [ID_Ingredient]      INT          NOT NULL,
    [Ingredient]         VARCHAR (50) NULL,
    [Date_2_Fabrication] DATETIME     NULL,
    [Date_2_Peremption]  DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([ID_Ingredient] ASC)
);


CREATE TABLE [dbo].[Volume] (
    [ID_Volume] INT            NOT NULL,
    [Volume]    DECIMAL (5, 3) NOT NULL,
    PRIMARY KEY CLUSTERED ([ID_Volume] ASC)
);






