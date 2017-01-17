USE [SparkServer]
GO

INSERT INTO [dbo].[Category]
           ([Name]
           ,[SortOrder]
           ,[Active]
           ,[CreateDate])
     VALUES
           ('Test Category'
           ,1
           ,1
           ,GETDATE())
GO


