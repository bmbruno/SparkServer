USE [SparkServer]
GO

ALTER TABLE [Author]
ADD
	[SSOID] UNIQUEIDENTIFIER NOT NULL
GO