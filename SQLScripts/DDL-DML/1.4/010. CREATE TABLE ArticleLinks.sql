USE [SparkServer]
GO

CREATE TABLE [ArticleLinks] (
	
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

	[ArticleID] INT NOT NULL,
	CONSTRAINT [FK_ArticleLinks_ArticleSource] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID]),
	
	[Name] VARCHAR(250) NOT NULL,
	
	[HREF] VARCHAR(2400) NOT NULL,

	[Active] BIT NOT NULL DEFAULT 1,

	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE()

)