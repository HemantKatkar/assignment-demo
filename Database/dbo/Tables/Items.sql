CREATE TABLE [dbo].[Items] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Name]     VARCHAR (255) NOT NULL,
    [OptionId] INT           NOT NULL,
    CONSTRAINT [PK_Items] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Items_OptionId] FOREIGN KEY ([OptionId]) REFERENCES [dbo].[Options] ([Id])
);

