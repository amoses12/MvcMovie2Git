CREATE TABLE [dbo].[Movies] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [MovieName]   NVARCHAR (50) NOT NULL,
    [ReleaseDate] DATETIME      NULL,
	[Rating]	  NVARCHAR (50) NULL,
    [Genre]       NVARCHAR (50) NULL,
    [Price]       FLOAT (53)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

