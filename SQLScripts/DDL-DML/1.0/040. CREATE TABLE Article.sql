USE [SparkServer]
GO

CREATE TABLE [Article] (
	
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

	[Title] VARCHAR(500) NOT NULL,

	[CategoryID] INT NOT NULL,
	CONSTRAINT [FK_Article_Category] FOREIGN KEY ([CategoryID]) REFERENCES [Article]([ID]),

	[Body] VARCHAR(MAX) NULL,

	[SitecoreVersionID] INT NOT NULL,
	CONSTRAINT [FK_Article_SitecoreVersion] FOREIGN KEY ([SitecoreVersionID]) REFERENCES [SitecoreVersion]([ID]),

	[PublishDate] DATETIME NULL,

	[UniqueURL] VARCHAR(250) NOT NULL,

	[AuthorID] INT NOT NULL,
	CONSTRAINT [FK_Article_Author] FOREIGN KEY ([AuthorID]) REFERENCES [Author]([ID]),

	[Active] BIT NOT NULL DEFAULT 1,

	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE()
)