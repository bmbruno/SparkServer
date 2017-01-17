USE [SparkServer]
GO

INSERT INTO [dbo].[Article]
           ([Title]
           ,[CategoryID]
           ,[Body]
           ,[SitecoreVersionID]
           ,[PublishDate]
           ,[UniqueURL]
           ,[AuthorID]
           ,[Active]
           ,[CreateDate])
     VALUES
           ('Article Test #1'
           ,1
           ,'<h1>Article Test #1 body goes here</h1>'
           ,1
           ,'2017-01-17'
           ,'article-number-one'
           ,1
           ,1
           ,'2017-01-15')
GO


