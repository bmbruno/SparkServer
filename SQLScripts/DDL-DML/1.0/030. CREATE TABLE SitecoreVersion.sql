USE [SparkServer]
GO

CREATE TABLE [SitecoreVersion] (
	
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),

	[Version] VARCHAR(25) NOT NULL, -- "8.2.1" 

	[Revision] VARCHAR(25) NOT NULL, -- "rev. 15602"

	[Description] VARCHAR(250) NOT NULL, -- "Sitecore 8.2 Update 1, rev. 15602"

	[Active] BIT NOT NULL DEFAULT 1,

	[CreateDate] DATETIME NOT NULL DEFAULT GETDATE()
)