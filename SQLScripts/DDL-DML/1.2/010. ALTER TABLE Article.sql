USE [SparkServer]
GO

ALTER TABLE [Article]
ADD
	[SortOrder] VARCHAR(500) NULL
GO