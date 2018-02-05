USE [SparkServer]
GO

CREATE TABLE [RelatedArticleLinks] (
	
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

	[ArticleID] INT NOT NULL,
	CONSTRAINT [FK_RelatedArticleLinks_ArticleSource] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID]),
	
	[Title] VARCHAR(500) NOT NULL,
	
	[HREF] VARCHAR(2400) NOT NULL,
	
	[SortOrder] INT NOT NULL DEFAULT 0,

	[Active] BIT NOT NULL DEFAULT 1,

	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE()

)