CREATE TABLE [dbo].[Options] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Options] PRIMARY KEY CLUSTERED ([Id] ASC)
);

