USE [SparkServer]
GO

INSERT INTO [dbo].[Author]
           ([FirstName]
           ,[LastName]
           ,[Email]
           ,[Active]
           ,[CreateDate])
     VALUES
           ('Brandon'
           ,'Bruno'
           ,'bmbruno@gmail.com'
           ,1
           ,GETDATE())
GO


