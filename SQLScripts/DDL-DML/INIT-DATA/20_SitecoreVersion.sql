USE [SparkServer]
GO

INSERT INTO [dbo].[SitecoreVersion]
           ([Version]
           ,[Revision]
           ,[Description]
           ,[Active]
           ,[CreateDate])
     VALUES
           ('8.2.1'
           ,'123456'
           ,'Sitecore 8.2 Update 1'
           ,1
           ,GETDATE())
GO