USE [SparkServer]
GO

CREATE TABLE [RelatedArticle] (
	
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

	[ArticleID] INT NOT NULL,
	CONSTRAINT [FK_RelatedArticle_ArticleSource] FOREIGN KEY ([ArticleID]) REFERENCES [Article]([ID]),
	
	[RelatedArticleID] INT NOT NULL,
	CONSTRAINT [FK_RelatedArticle_ArticleRelated] FOREIGN KEY ([RelatedArticleID]) REFERENCES [Article]([ID]),

	[Active] BIT NOT NULL DEFAULT 1,

	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE()

)