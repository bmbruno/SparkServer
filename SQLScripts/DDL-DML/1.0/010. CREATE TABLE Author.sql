USE [SparkServer]
GO

CREATE TABLE [Author] (
	
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

	[FirstName] VARCHAR(250) NOT NULL,

	[LastName] VARCHAR(250) NOT NULL,

	[Email] VARCHAR(250) NULL,

	[Active] BIT NOT NULL DEFAULT 1,

	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE()
)